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
    /// 游戏暂停与继续脚本
    /// </summary>
    public class GameStateForm : UGuiForm
    {
        public Text stateText;//当前游戏状态文本

        public void OnButtonClick()
        {
            GameEntry.Sound.PlayUISound(1);//播放音效
            if (stateText.text == "暂停")
            {
                Time.timeScale = 0;
                stateText.text = "继续";
            }
            else
            {
                Time.timeScale = 1;
                stateText.text = "暂停";
            }
        }
    }
}

