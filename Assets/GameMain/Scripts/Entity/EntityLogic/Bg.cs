using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class Bg : Entity
    {
        private BgData m_BgData = null;

        private bool m_IsSpawn = false;

        protected override void OnHide(bool isShutdown, object userData)
        {
            base.OnHide(isShutdown, userData);

            m_IsSpawn = false;
        }

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);

            m_BgData = (BgData)userData;
            CachedTransform.SetLocalPositionX(m_BgData.StartPosition);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.left * m_BgData.MoveSpeed * elapseSeconds, Space.World);

            ////   0   ,  
            ////            this.SpawnTarget = 3.8f;
            ////this.HideTarget = -22.02f;
            if (CachedTransform.position.x <= m_BgData.SpawnTarget && !m_IsSpawn)
            {
                GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), m_BgData.TypeId, m_BgData.MoveSpeed, m_BgData.StartPosition));
                m_IsSpawn = true;
            }

            if (CachedTransform.position.x <= m_BgData.HideTarget)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }
    }
}