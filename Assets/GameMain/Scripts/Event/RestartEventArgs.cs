using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class RestartEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RestartEventArgs).GetHashCode();
        public override int Id => EventId;

        public override void Clear()
        {
            
        }

    }
}
