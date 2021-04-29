using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class ReturnMenuEventArgs : GameFramework.Event.GameEventArgs
    {
        public static readonly int EventId = typeof(ReturnMenuEventArgs).GetHashCode();
        public override int Id => EventId;

        public override void Clear()
        {
            
        }
    }
}
