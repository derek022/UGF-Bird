using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{


    public class Pipe : Entity
    {
        private PipeData m_PipeData = null;

        private Transform m_UpPipe = null;

        private Transform m_DownPipe = null;

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            m_UpPipe.gameObject.SetActive(true);
            m_DownPipe.gameObject.SetActive(true);

            GameEntry.Event.Unsubscribe(RestartEventArgs.EventId, OnRestart);
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_PipeData = (PipeData)userData;

            CachedTransform.SetLocalPositionX(10f);

            if(m_UpPipe == null ||　m_DownPipe == null)
            {
                m_DownPipe = transform.Find("DownPipe");
                m_UpPipe = transform.Find("UpPipe");
            }


            // 设置上下管道的偏移

            m_UpPipe.SetLocalPositionY(m_PipeData.OffsetUp);
            m_DownPipe.SetLocalPositionY(m_PipeData.OffsetDown);


            // 订阅事件
            GameEntry.Event.Subscribe(RestartEventArgs.EventId, OnRestart);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.left * m_PipeData.MoveSpeed * elapseSeconds, Space.World);

            if(CachedTransform.position.x <= m_PipeData.HideTarget)
            {
                GameEntry.Entity.HideEntity(this);
            }
            
        }


        private void OnRestart(object sender,GameEventArgs e)
        {
            GameEntry.Entity.HideEntity(this);
        }


    }
}