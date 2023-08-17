using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace FlappyBird
{
    /// <summary>
    /// ���ֽ���ű�
    /// </summary>
    public class ScoreForm : UGuiForm
    {
        public Text scoreText; //�����ı�

        /// <summary>
        /// ����
        /// </summary>
        private int m_Score = 0;

        /// <summary>
        /// ���ּ�ʱ��
        /// </summary>
        private float m_ScoreTimer = 0;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            
            //����С�������¼�
            GameEntry.Event.Subscribe(BirdDeadEventArgs.EventId, OnBirdDead);
            //���ļӷ��¼�
            GameEntry.Event.Subscribe(AddScoreEventArgs.EventId, OnAddScore);
        }


        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            m_ScoreTimer += elapseSeconds;
            if(m_ScoreTimer >= 2f)
            {
                m_Score += 1;
                m_ScoreTimer = 0f;
                scoreText.text = "�ܷ֣�" + m_Score;
            }
        }

        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            //ȡ������С�������¼�
            GameEntry.Event.Unsubscribe(BirdDeadEventArgs.EventId, OnBirdDead);
            //ȡ�����ļӷ��¼�
            GameEntry.Event.Unsubscribe(AddScoreEventArgs.EventId, OnAddScore);
        }

        protected override void OnPause()
        {
            base.OnPause();
            //�������
            m_Score = 0;
            m_ScoreTimer = 0f;
            scoreText.text = "�ܷ֣�" + m_Score;

        }

        private void OnBirdDead(object sender, GameEventArgs e)
        {
            //�����ݽ���������
            GameEntry.DataNode.GetOrAddNode("Score").SetData<VarInt>(m_Score);
            //����Ϸ��������
            GameEntry.UI.OpenUIForm(UIFormId.GameOverForm);
        }
        private void OnAddScore(object sender, GameEventArgs e)
        {
            AddScoreEventArgs addScoreEvent = (AddScoreEventArgs)e;
            m_Score += addScoreEvent.AddCount;
            scoreText.text = "�ܷ֣�" + m_Score;
        }

    }
}

