using GameFramework.Event;
using GameFramework.Fsm;
using GameFramework.Procedure;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityGameFramework.Runtime;
using GameFramework;

namespace FlappyBird
{
    /// <summary>
    /// ������
    /// </summary>
    public class ProcedureMain : ProcedureBase
    {
        /// <summary>
        /// �ܵ�����ʱ��
        /// </summary>
        private float m_PipeSpawntime = 0f;

        /// <summary>
        /// �ܵ�������ʱ��
        /// </summary>
        private float m_PipeSpawntimer = 0f;

        /// <summary>
        /// ��Ϸ��������ID
        /// </summary>
        private int m_ScoreFormId = -1;

        /// <summary>
        /// ��Ϸ״̬����ID
        /// </summary>
        private int m_GameStateFormId = -1;

        /// <summary>
        /// �Ƿ񷵻����˵�
        /// </summary>
        private bool m_IsReturnMenu = false;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            //��ʾ����
            GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), 1, 1f, -4.6f));//��ʼ��ʾ����λ��
            //��ʾС��
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));

            //���ó�ʼ�ܵ�����ʱ��
            m_PipeSpawntime = Random.Range(3f, 5f);

            //�򿪻��ֽ��棬����ȡ����ID
            m_ScoreFormId = GameEntry.UI.OpenUIForm(UIFormId.ScoreForm).Value;

            //����Ϸ״̬���棬����ȡ����ID
            m_GameStateFormId = GameEntry.UI.OpenUIForm(UIFormId.GameStateForm).Value;

            //���ķ������˵��¼�
            GameEntry.Event.Subscribe(ReturnMenuEventArgs.EventId, OnReturnMenu);
        }
        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            m_PipeSpawntimer += elapseSeconds;
            if(m_PipeSpawntimer >= m_PipeSpawntime)
            {
                m_PipeSpawntimer = 0f;
                m_PipeSpawntime = Random.Range(3f, 5f);//���¶Թܵ�����ʱ�丳ֵ

                //�����ܵ�
                GameEntry.Entity.ShowPipe(new PipeData(GameEntry.Entity.GenerateSerialId(), 2, 1f));
            }

            //����������˵�
            if(m_IsReturnMenu)
            {
                m_IsReturnMenu = false;
                procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Menu"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }

        protected override void OnLeave(IFsm<IProcedureManager> procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);
            
            //��С������ʱ�뿪��Ϸ������״̬���رջ��ֽ������Ϸ״̬����
            GameEntry.UI.CloseUIForm(m_ScoreFormId);
            GameEntry.UI.CloseUIForm(m_GameStateFormId);

            //ȡ�����ķ������˵��¼�
            GameEntry.Event.Unsubscribe(ReturnMenuEventArgs.EventId, OnReturnMenu);
        }

        private void OnReturnMenu(object sender, GameEventArgs e)
        {
            m_IsReturnMenu = true;
        }
    }
}