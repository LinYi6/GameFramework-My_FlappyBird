using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    /// <summary>
    /// 管道实体逻辑脚本
    /// </summary>
    public class Pipe : Entity
    {
        /// <summary>
        /// 管道实体数据
        /// </summary>
        private PipeData m_PipeData = null;

        /// <summary>
        /// 上管道位置
        /// </summary>
        private Transform m_UpPipe = null;
        
        /// <summary>
        /// 下管道位置
        /// </summary>
        private Transform m_DownPipe = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_PipeData = (PipeData)userData;

            //设置初始位置
            CachedTransform.SetPositionX(10f);

            if(m_UpPipe == null || m_DownPipe == null)
            {
                m_UpPipe = transform.Find("UpPipe");
                m_DownPipe = transform.Find("DownPipe");
            }

            //设置管道的上下偏移
            m_UpPipe.SetPositionY(m_PipeData.OffsetUp);
            m_DownPipe.SetPositionY(m_PipeData.OffsetDown);

            //监听重新开始事件
            GameEntry.Event.Subscribe(RestartEventArgs.EventId, OnRestart);
        }

        

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector3.left * m_PipeData.MoveSpeed * elapseSeconds, Space.World);
            if(CachedTransform.position.x <= m_PipeData.HideTarget)
            {
                //隐藏自身
                GameEntry.Entity.HideEntity(this);
            }
        }

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);
            m_UpPipe.gameObject.SetActive(false );
            m_DownPipe.gameObject.SetActive(false);

            //取消订阅重新开始事件
            GameEntry.Event.Unsubscribe(RestartEventArgs.EventId, OnRestart);
        }
        private void OnRestart(object sender, GameEventArgs e)
        {
            //隐藏自身
            GameEntry.Entity.HideEntity(this);
        }
    }
}

