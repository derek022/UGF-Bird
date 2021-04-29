using GameFramework;
using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;

namespace FlappyBird
{
    public class Bullet : Entity
    {
        private BulletData m_BulletData = null;
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_BulletData = (BulletData)userData;

            CachedTransform.SetLocalScaleX(1.8f);
            CachedTransform.position = m_BulletData.ShootPosition;

            // 监听小鸟死亡事件
            GameEntry.Event.Subscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector2.right * m_BulletData.FlySpeed * elapseSeconds, Space.World);

            if(CachedTransform.position.x >= 9.1f)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);
            GameEntry.Event.Unsubscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            // 隐藏管道与自身
            GameEntry.Sound.PlaySound(1);
            collision.gameObject.SetActive(false);
            GameEntry.Entity.HideEntity(this);

            // 派发加分事件
            AddScoreEventArgs e = ReferencePool.Acquire<AddScoreEventArgs>();
            GameEntry.Event.Fire(this, e.Fill(10));
        }

        /// <summary>
        /// 小鸟死亡后，不需要再有子弹
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnBirdDead(object sender,GameEventArgs e)
        {
            GameEntry.Entity.HideEntity(this);
        }
    }
}
