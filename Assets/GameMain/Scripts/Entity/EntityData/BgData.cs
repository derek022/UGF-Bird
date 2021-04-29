using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class BgData : EntityData
    {
        public float MoveSpeed { get; private set; }
        public float SpawnTarget { get; private set; }
        public float HideTarget { get; private set; }
        public float StartPosition { get; private set; }


        public BgData(int entityId, int typeId,float moveSpeed,float startPosition) : base(entityId, typeId)
        {
            this.MoveSpeed = moveSpeed;
            this.SpawnTarget = -1f;
            this.HideTarget = -15f;
            this.StartPosition = startPosition;
        }
    }
}