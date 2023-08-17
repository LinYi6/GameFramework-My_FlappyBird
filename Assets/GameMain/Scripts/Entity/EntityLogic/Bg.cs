using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// ����ʵ���߼��ű�
    /// </summary>
    public class Bg : Entity
    {
        /// <summary>
        /// ����ʵ������
        /// </summary>
        private BgData m_BgData = null;
        private bool m_IsSpawn = false;//�Ƿ������˱���
        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_BgData = (BgData)userData;
            //�޸Ŀ�ʼλ��
            CachedTransform.SetLocalPositionX(m_BgData.StartPosition);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);
            //���Ʊ���ʵ���ƶ�
            CachedTransform.Translate(Vector3.left * m_BgData.MoveSpeed * elapseSeconds, Space.World);
            if(CachedTransform.position.x <= m_BgData.SpawnTarget && m_IsSpawn == false)
            {
                //��ʾ����ʵ��
                GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), m_BgData.TypeId, m_BgData.MoveSpeed, 17f));//���ĸ�����Ϊ������ʾ�����ĳ�ʼλ��
                m_IsSpawn = true;
            }
            if(CachedTransform.position.x <= m_BgData.HideTarget)
            {
                //����ʵ��
                GameEntry.Entity.HideEntity(this);
            }
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);
            m_IsSpawn = false;
        }
    }
}

