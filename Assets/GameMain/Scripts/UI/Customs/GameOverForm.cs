using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;
using GameFramework;

namespace FlappyBird
{
    /// <summary>
    /// 游戏结束界面
    /// </summary>
    public class GameOverForm : UGuiForm
    {
        public Text scoreText;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            //获取总分数
            int score = GameEntry.DataNode.GetNode("Score").GetData<VarInt>();
            scoreText.text = "你的总分：" + score;
        }
        protected override void OnClose(object userData)
        {
            base.OnClose(userData);
            scoreText.text = string.Empty;
        }

        /// <summary>
        /// 重新开始按钮
        /// </summary>
        public void OnRestartButtonClick()
        {
            Close(true);
            //派发重新开始游戏事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<RestartEventArgs>());
            //重新生成小鸟
            GameEntry.Entity.ShowBird(new BirdData(GameEntry.Entity.GenerateSerialId(), 3, 6f));
        }

        /// <summary>
        /// 返回主菜单按钮
        /// </summary>
        public void OnMenuButtonClick()
        {
            Close(true);
            //派发返回菜单事件
            GameEntry.Event.Fire(this, ReferencePool.Acquire<ReturnMenuEventArgs>());
           
        }
    }

}
