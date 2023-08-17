using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class BirdDeadEventArgs : GameEventArgs
    {
        /// <summary>
        /// Ğ¡ÄñËÀÍöÊÂ¼ş
        /// </summary>
        public static readonly int EventId = typeof(BirdDeadEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public override void Clear()
        {
            
        }
    }
}

