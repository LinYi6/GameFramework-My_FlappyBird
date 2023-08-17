using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using GameFramework;

namespace FlappyBird
{
    /// <summary>
    /// ��Ϸ��������
    /// </summary>
    public class GameOverForm : UGuiForm
    {
        public Text scoreText;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            //��ȡ�ܷ���
            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt>();
            scoreText.text = "����ܷ֣�" + score;
        }
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            scoreText.text = string.Empty;
        }

        /// <summary>
        /// ���¿�ʼ��ť
        /// </summary>
        public void OnRestartButtonClick()
        {
            Close(true);
            //�ɷ����¿�ʼ��Ϸ�¼�
            GameEntry.Event.Fire(this, ReferencePool.Acquire<RestartEventArgs>());
            //��������С��
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 6f));
        }

        /// <summary>
        /// �������˵���ť
        /// </summary>
        public void OnMenuButtonClick()
        {
            Close(true);
            //�ɷ����ز˵��¼�
            GameEntry.Event.Fire(this, ReferencePool.Acquire<ReturnMenuEventArgs>());
           
        }
    }

}
