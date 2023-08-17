using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// �ܵ�ʵ���߼��ű�
    /// </summary>
    public class Pipe : Entity
    {
        /// <summary>
        /// �ܵ�ʵ������
        /// </summary>
        private PipeData m_PipeData = null;

        /// <summary>
        /// �Ϲܵ�λ��
        /// </summary>
        private Transform m_UpPipe = null;
        
        /// <summary>
        /// �¹ܵ�λ��
        /// </summary>
        private Transform m_DownPipe = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_PipeData = (PipeData)userData;

            //���ó�ʼλ��
            CachedTransform.SetPositionX(10f);

            if(m_UpPipe == null || m_DownPipe == null)
            {
                m_UpPipe = transform.Find("UpPipe");
                m_DownPipe = transform.Find("DownPipe");
            }

            //���ùܵ�������ƫ��
            m_UpPipe.SetPositionY(m_PipeData.OffsetUp);
            m_DownPipe.SetPositionY(m_PipeData.OffsetDown);

            //�������¿�ʼ�¼�
            GameEntry.Event.Subscribe(RestartEventArgs.EventId, OnRestart);
        }

        

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.left * m_PipeData.MoveSpeed * elapseSeconds, Space.World);
            if(CachedTransform.position.x <= m_PipeData.HideTarget)
            {
                //��������
                GameEntry.Entity.HideEntity(this);
            }
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);
            m_UpPipe.gameObject.SetActive(false );
            m_DownPipe.gameObject.SetActive(false);

            //ȡ���������¿�ʼ�¼�
            GameEntry.Event.Unsubscribe(RestartEventArgs.EventId, OnRestart);
        }
        private void OnRestart(object sender, GameEventArgs e)
        {
            //��������
            GameEntry.Entity.HideEntity(this);
        }
    }
}
