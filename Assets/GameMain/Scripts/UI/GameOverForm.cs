using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace FlappyBird
{
    public  class GameOverForm : UGuiForm
    {
        [UnityEngine.SerializeField]
        private Text Score;

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);

            Score.text = string.Empty;
        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);

            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt32>();
            Score.text = $"你的总分：{score}";
        }


        public void OnRestartButtonClick()
        {
            Close(true);

            GameEntry.Event.Fire(this, ReferencePool.Acquire<RestartEventArgs>());

            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5));
        }

        public void OnReturnButtonClick()
        {
            Close(true);

            GameEntry.Event.Fire(this, ReferencePool.Acquire<ReturnMenuEventArgs>());
        }

    }
}
