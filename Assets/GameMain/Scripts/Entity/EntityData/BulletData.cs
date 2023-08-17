using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// �ӵ�ʵ�����ݽű�
    /// </summary>
    public class BulletData : EntityData
    {
        /// <summary>
        /// �ӵ�����λ��
        /// </summary>
        public Vector2 ShootPosition { get; private set; }

        /// <summary>
        /// �ӵ������ٶ�
        /// </summary>
        public float FlySpeed { get; private set; }

        public BulletData(int entityId, int typeId, Vector2 shootPosition, float flySpeed) : base(entityId, typeId)
        {
            ShootPosition = shootPosition;
            FlySpeed = flySpeed;
        }
    }
}

