using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// 子弹实体数据脚本
    /// </summary>
    public class BulletData : EntityData
    {
        /// <summary>
        /// 子弹发射位置
        /// </summary>
        public Vector2 ShootPosition { get; private set; }

        /// <summary>
        /// 子弹飞行速度
        /// </summary>
        public float FlySpeed { get; private set; }

        public BulletData(int entityId, int typeId, Vector2 shootPosition, float flySpeed) : base(entityId, typeId)
        {
            ShootPosition = shootPosition;
            FlySpeed = flySpeed;
        }
    }
}

