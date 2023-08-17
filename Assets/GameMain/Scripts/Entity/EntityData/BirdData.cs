using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// С��ʵ�����ݽű�
    /// </summary>
    public class BirdData : EntityData
    {
        /// <summary>
        /// ��������
        /// </summary>
        public float FlyForce { get; private set; }
        public BirdData(int entityId, int typeId, float flyForce) : base(entityId, typeId)
        {
            FlyForce = flyForce;
        }
    }
}

