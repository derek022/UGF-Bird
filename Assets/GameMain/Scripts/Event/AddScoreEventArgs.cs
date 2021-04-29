using GameFramework.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlappyBird
{
    public class AddScoreEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(AddScoreEventArgs).GetHashCode();
        public override int Id => EventId;

        public int AddCount { get; private set; }

        public AddScoreEventArgs Fill(int addCount)
        {
            this.AddCount = addCount;
            return this;
        }

        public override void Clear()
        {
            this.AddCount = 0;
        }
    }
}
