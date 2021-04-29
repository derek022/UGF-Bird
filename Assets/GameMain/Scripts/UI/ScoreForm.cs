using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using GameFramework.Event;
using UnityGameFramework.Runtime;

namespace FlappyBird
{
    public class ScoreForm : UGuiForm
    {
        [SerializeField]
        private Text scoreText;

        private int m_Score = 0;

        private float m_ScoreTimer = 0;

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            GameEntry.Event.Subscribe(BirdDeadEventArgs.EventId, OnBirdDead);
            GameEntry.Event.Subscribe(AddScoreEventArgs.EventId, OnAddScore);
        }

        protected override void OnPause()
        {
            base.OnPause();

            m_ScoreTimer = 0;
            m_Score = 0;

            this.RefreshScoreText();
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            m_ScoreTimer += elapseSeconds;

            if(m_ScoreTimer >= 2f)
            {
                m_ScoreTimer = 0f;
                m_Score += 1;
                this.RefreshScoreText();
            }

        }

        private void RefreshScoreText()
        {
            scoreText.text = string.Format("总分：{0}", m_Score);
        }

        private void OnBirdDead(object sender,GameEventArgs e)
        {
            GameEntry.DataNode.GetOrAddNode("Score").SetData<VarInt32>(m_Score);
            GameEntry.UI.OpenUIForm(UIFormId.GameOverForm);
        }

        private void OnAddScore(object sender,GameEventArgs e)
        {
            AddScoreEventArgs ase = (AddScoreEventArgs)e;
            m_Score += ase.AddCount;

            this.RefreshScoreText();
        }
    }
}
