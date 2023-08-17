using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Procedure;
using UnityGameFramework.Runtime;
using ProcedureOwner = GameFramework.Fsm.IFsm<GameFramework.Procedure.IProcedureManager>;
using GameFramework.Event;
using System;

namespace FlappyBird
{
    /// <summary>
    /// 菜单流程
    /// </summary>
    public class ProcedureMenu : ProcedureBase
    {
        public bool IsStartGame { get; set; }

        /// <summary>
        /// 菜单界面脚本
        /// </summary>
        /// <param name="procedureOwner"></param>
        private MenuForm m_MenuForm = null;

        protected override void OnEnter(ProcedureOwner procedureOwner)
        {
            base.OnEnter(procedureOwner);
            IsStartGame = false;

            //订阅UI打开成功事件
            GameEntry.Event.Subscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);

            //打开菜单UI
            GameEntry.UI.OpenUIForm(UIFormId.MenuForm, this);
        }

        protected override void OnLeave(ProcedureOwner procedureOwner, bool isShutdown)
        {
            base.OnLeave(procedureOwner, isShutdown);

            if(m_MenuForm != null)
            {
                m_MenuForm.Close(isShutdown);
                m_MenuForm = null;
            }

            //取消订阅UI打开成功事件
            GameEntry.Event.Unsubscribe(OpenUIFormSuccessEventArgs.EventId, OnOpenUIFormSuccess);
        }

        private void OnOpenUIFormSuccess(object sender, GameEventArgs e)
        {
            OpenUIFormSuccessEventArgs ne = (OpenUIFormSuccessEventArgs)e;
            if(ne.UserData != this)
            {
                return;
            }
            m_MenuForm = (MenuForm)ne.UIForm.Logic;
        }

        protected override void OnUpdate(ProcedureOwner procedureOwner, float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(procedureOwner, elapseSeconds, realElapseSeconds);

            if(IsStartGame)
            {
                //如果开始游戏了，则切换到主要场景
                procedureOwner.SetData<VarInt>(Constant.ProcedureData.NextSceneId, GameEntry.Config.GetInt("Scene.Main"));
                ChangeState<ProcedureChangeScene>(procedureOwner);
            }
        }
    }
}

