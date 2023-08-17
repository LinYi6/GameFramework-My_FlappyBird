using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameFramework;
using UnityEngine.UI;
using GameFramework.Event;
using System;

namespace FlappyBird
{
    /// <summary>
    /// ��Ϸ��ͣ������ű�
    /// </summary>
    public class GameStateForm : UGuiForm
    {
        public Text stateText;//��ǰ��Ϸ״̬�ı�

        public void OnButtonClick()
        {
            GameEntry.Sound.PlayUISound(1);//������Ч
            if (stateText.text == "��ͣ")
            {
                Time.timeScale = 0;
                stateText.text = "����";
            }
            else
            {
                Time.timeScale = 1;
                stateText.text = "��ͣ";
            }
        }
    }
}

