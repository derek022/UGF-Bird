using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{


    public class PipeData : EntityData
    {
        public float MoveSpeed { get; private set; }

        public float OffsetUp { get; private set; }
        public float OffsetDown { get; private set; }

        public float HideTarget { get; private set; }
        public PipeData(int entityId, int typeId,float moveSpeed) : base(entityId, typeId)
        {
            this.MoveSpeed = moveSpeed;
            this.OffsetUp = Random.Range(4.1f, 7f);
            this.OffsetDown = Random.Range(-3.1f, -4.5f);
            this.HideTarget = -9.4f;
        }
    }
}