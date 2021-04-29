using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class BirdData : EntityData
    {
        public float FlyForce { private set; get; }

        public BirdData(int entityId, int typeId,float flyForce) : base(entityId, typeId)
        {
            this.FlyForce = flyForce;
        }

    }
}
