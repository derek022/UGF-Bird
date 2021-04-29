using GameFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FlappyBird
{
    public  class Bird : Entity
    {
        private BirdData m_BirdData = null;

        private float m_ShootTime = 1f;

        private float m_ShootTimer = 0;

        private Rigidbody2D m_Rigibody2D = null;

        private bool m_IsDead = false;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_BirdData = (BirdData)userData;

            CachedTransform.localScale = Vector2.one * 2;
            if(m_Rigibody2D == null)
            {
                m_Rigibody2D = GetComponent<Rigidbody2D>();
            }
            m_ShootTimer = 1f;
            m_IsDead = false;
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameEntry.Sound.PlaySound(2);
                m_Rigibody2D.velocity = new Vector2(0, m_BirdData.FlyForce);
            }

            m_ShootTimer += elapseSeconds;

            if(m_ShootTimer >= m_ShootTime && Input.GetKeyDown(KeyCode.J))
            {
                m_ShootTimer = 0;
                GameEntry.Sound.PlaySound(3);
                GameEntry.Entity.ShowBullet(new BulletData(GameEntry.Entity.GenerateSerialId(), 4, CachedTransform.position + CachedTransform.right, 6));

            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (m_IsDead) return;
            m_IsDead = true;

            GameEntry.Sound.PlaySound(1);
            GameEntry.Entity.HideEntity(this);

            // 派发小鸟死亡事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<BirdDeadEventArgs>());
        }
    }
}
