using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FlappyBird
{
    public class BulletData : EntityData
    {
        public Vector2 ShootPosition { private set; get; }

        public float FlySpeed { get; private set; }

        public BulletData(int entityId, int typeId,Vector2 shootPisition,float flySpeed) : base(entityId, typeId)
        {
            this.ShootPosition = shootPisition;
            this.FlySpeed = flySpeed;
        }
    }
}
