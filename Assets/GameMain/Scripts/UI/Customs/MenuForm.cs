using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Procedure;

namespace FlappyBird
{
    ///<summary>
    ///菜单界面脚本
    ///</summary>
    public class MenuForm : UGuiForm
    {
        ///<summary>
        ///菜单流程
        /// </summary>
        private ProcedureMenu m_ProcedureMenu = null;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            m_ProcedureMenu = (ProcedureMenu)userData;
        }
        protected override void OnClose(object userData)
        {
            m_ProcedureMenu = null;
            base.OnClose(userData);
        }

        /// <summary>
        /// 开始游戏按钮
        /// </summary>
        public void OnStartButtonClick()
        {
            m_ProcedureMenu.IsStartGame = true;
        }
        /// <summary>
        /// 设置按钮
        /// </summary>
        public void OnSettingButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm); //打开设置UI
        }
    }
}
