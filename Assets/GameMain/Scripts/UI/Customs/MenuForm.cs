using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework.Procedure;

namespace FlappyBird
{
    ///<summary>
    ///�˵�����ű�
    ///</summary>
    public class MenuForm : UGuiForm
    {
        ///<summary>
        ///�˵�����
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
        /// ��ʼ��Ϸ��ť
        /// </summary>
        public void OnStartButtonClick()
        {
            m_ProcedureMenu.IsStartGame = true;
        }
        /// <summary>
        /// ���ð�ť
        /// </summary>
        public void OnSettingButtonClick()
        {
            GameEntry.UI.OpenUIForm(UIFormId.SettingForm); //������UI
        }
    }
}
