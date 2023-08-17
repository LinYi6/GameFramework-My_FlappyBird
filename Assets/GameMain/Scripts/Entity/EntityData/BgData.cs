using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{

    public class BgData : EntityData
    {
        /// <summary>
        /// �ƶ��ٶ�
        /// </summary>
        public float MoveSpeed { get; private set; }

        /// <summary>
        /// �����Ŀ��ʱ�����µı���ʵ��
        /// </summary>
        public float SpawnTarget { get; private set; }

        /// <summary>
        /// �����Ŀ��ʱ�������
        /// </summary>
        public float HideTarget { get; private set; }

        /// <summary>
        /// �ƶ���ʼ��
        /// </summary>
        public float StartPosition { get; private set; }
        
        public BgData(int entityId, int typeId, float moveSpeed, float startPosition) : base(entityId, typeId)
        {
            MoveSpeed = moveSpeed;
            SpawnTarget = -8.66f;
            HideTarget = -32f;
            StartPosition = startPosition;
        }
    }
}

