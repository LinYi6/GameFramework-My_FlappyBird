using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FlappyBird
{
    /// <summary>
    /// �ӵ�ʵ���߼��ű�
    /// </summary>
    public class Bullet : Entity
    {
        /// <summary>
        /// �ӵ�ʵ������
        /// </summary>
        public BulletData m_BulletData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_BulletData = (BulletData)userData;

            //�޸�����
            CachedTransform.SetLocalScaleX(1.8f);
            //�������λ��
            CachedTransform.position = m_BulletData.ShootPosition;

            //����С�������¼�
            GameEntry.Event.Subscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }       

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);
            //ȡ������С�������¼�
            GameEntry.Event.Unsubscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }
        private void OnBirdDead(object sender, GameEventArgs e)
        {
            //С�����������������ӵ��Լ�
            GameEntry.Entity.HideEntity(this);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector2.right * m_BulletData.FlySpeed * elapseSeconds, Space.World);

            //���Ѵﵽ�����о�������������
            if(CachedTransform.position.x >= 9f)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //���ӵ���ײ���ܵ��������ӵ��͹ܵ�
            GameEntry.Sound.PlaySound(1);
            GameEntry.Entity.HideEntity(this);//�����ӵ�����
            collision.gameObject.SetActive(false);

            //���к��ɷ��ӷ��¼�
            AddScoreEventArgs e = ReferencePool.Acquire<AddScoreEventArgs>();
            GameEntry.Event.Fire(this, e.Fill(10));
        }

    }
}

