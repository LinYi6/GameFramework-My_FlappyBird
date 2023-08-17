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
    /// 主流程
    /// </summary>
    public class ProcedureMain : ProcedureBase
    {
        /// <summary>
        /// 管道产生时间
        /// </summary>
        private float m_PipeSpawntime = 0f;

        /// <summary>
        /// 管道产生计时器
        /// </summary>
        private float m_PipeSpawntimer = 0f;

        /// <summary>
        /// 游戏结束界面ID
        /// </summary>
        private int m_ScoreFormId = -1;

        /// <summary>
        /// 游戏状态界面ID
        /// </summary>
        private int m_GameStateFormId = -1;

        /// <summary>
        /// 是否返回主菜单
        /// </summary>
        private bool m_IsReturnMenu = false;

        protected override void OnEnter(IFsm<IProcedureManager> procedureOwner)
        {
            base.OnEnter(procedureOwner);
            //显示背景
            GameEntry.Entity.ShowBg(new BgData(GameEntry.Entity.GenerateSerialId(), 1, 1f, -4.6f));//初始显示背景位置
            //显示小鸟
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 5f));

            //设置初始管道产生时间
            m_PipeSpawntime = Random.Range(3f, 5f);

            //打开积分界面，并获取界面ID
            m_ScoreFormId = GameEntry.UI.OpenUIForm(UIFormId.ScoreForm).Value;

            //打开游戏状态界面，并获取界面ID
            m_GameStateFormId = GameEntry.UI.OpenUIForm(UIFormId.GameStateForm).Value;

            //订阅返回主菜单事件
            GameEntry.Event.Subscribe(ReturnMenuEventArgs.EventId, OnReturnMenu);
        }
        protected override void OnUpdate(IFsm<IProcedureManager> procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);
            m_PipeSpawntimer += elapseSeconds;
            if(m_PipeSpawntimer >= m_PipeSpawntime)
            {
                m_PipeSpawntimer = 0f;
                m_PipeSpawntime = Random.Range(3f, 5f);//重新对管道产生时间赋值

                //产生管道
                GameEntry.Entity.ShowPipe(new PipeData(GameEntry.Entity.GenerateSerialId(), 2, 1f));
            }

            //如果返回主菜单
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
            
            //当小鸟死亡时离开游戏主界面状态，关闭积分界面和游戏状态界面
            GameEntry.UI.CloseUIForm(m_ScoreFormId);
            GameEntry.UI.CloseUIForm(m_GameStateFormId);

            //取消订阅返回主菜单事件
            GameEntry.Event.Unsubscribe(ReturnMenuEventArgs.EventId, OnReturnMenu);
        }

        private void OnReturnMenu(object sender, GameEventArgs e)
        {
            m_IsReturnMenu = true;
        }
    }
}