using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// ���ز˵������¼�
    /// </summary>
    public class ReturnMenuEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(ReturnMenuEventArgs).GetHashCode();

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

