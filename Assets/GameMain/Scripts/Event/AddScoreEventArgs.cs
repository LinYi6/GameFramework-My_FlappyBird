using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Event;

namespace FlappyBird
{
    public class AddScoreEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(AddScoreEventArgs).GetHashCode();

        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        /// <summary>
        /// �ӷ�����
        /// </summary>
        public int AddCount { get; private set; }

        /// <summary>
        /// ���ӷ��¼�
        /// </summary>
        /// <param name="addCount"></param>
        /// <returns></returns>
        public AddScoreEventArgs Fill(int addCount)
        {
            AddCount = addCount;
            return this;
        }

        public override void Clear()
        {
            AddCount = 0;
        }
    }
}

