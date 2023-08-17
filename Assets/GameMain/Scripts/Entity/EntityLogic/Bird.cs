using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// С��ʵ���߼��ű�
    /// </summary>
    public class Bird : Entity
    {
        /// <summary>
        /// С��ʵ������
        /// </summary>
        private BirdData m_BirdData = null;

        /// <summary>
        /// ���ʱ��
        /// </summary>
        private float m_ShootTime = 10f;

        /// <summary>
        /// �����ʱ��
        /// </summary>
        private float m_ShootTimer = 0f;

        private Rigidbody2D m_Rigidbody = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_BirdData = (BirdData)userData;

            //�޸�����
            CachedTransform.localScale = Vector2.one * 2;
            //��ʼ��С������λ��
            CachedTransform.position = new Vector2(0, 3);
            if(m_Rigidbody == null)
            {
                m_Rigidbody = GetComponent<Rigidbody2D>();
            }

            //������ȴʱ��
            m_ShootTimer = 10f;
        }
        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            //��������
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameEntry.Sound.PlaySound(2);
                m_Rigidbody.velocity = new Vector2(0, m_BirdData.FlyForce);
            }

            //�������
            m_ShootTimer += elapseSeconds;
            if(m_ShootTimer >= m_ShootTime && Input.GetKeyDown(KeyCode.J))
            {
                m_ShootTimer = 0f;
                GameEntry.Sound.PlaySound(3);
                GameEntry.Entity.ShowBullet(new BulletData(GameEntry.Entity.GenerateSerialId(),4, CachedTransform.position + CachedTransform.right, 6f));
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            GameEntry.Sound.PlaySound(1);//����
            GameEntry.Entity.HideEntity(this);

            //�ɷ�С�������¼�
            GameEntry.Event.Fire(this, ReferencePool.Acquire<BirdDeadEventArgs>());
        }
    }
}

