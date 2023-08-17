using GameFramework;
using GameFramework.Event;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace FlappyBird
{
    /// <summary>
    /// 子弹实体逻辑脚本
    /// </summary>
    public class Bullet : Entity
    {
        /// <summary>
        /// 子弹实体数据
        /// </summary>
        public BulletData m_BulletData = null;

        protected override void OnShow(object userData)
        {
            base.OnShow(userData);
            m_BulletData = (BulletData)userData;

            //修改缩放
            CachedTransform.SetLocalScaleX(1.8f);
            //设置射击位置
            CachedTransform.position = m_BulletData.ShootPosition;

            //监听小鸟死亡事件
            GameEntry.Event.Subscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }       

        protected override void OnHide(object userData)
        {
            base.OnHide(userData);
            //取消监听小鸟死亡事件
            GameEntry.Event.Unsubscribe(BirdDeadEventArgs.EventId, OnBirdDead);
        }
        private void OnBirdDead(object sender, GameEventArgs e)
        {
            //小鸟死亡后立即隐藏子弹自己
            GameEntry.Entity.HideEntity(this);
        }

        protected override void OnUpdate(float elapseSeconds, float realElapseSeconds)
        {
            base.OnUpdate(elapseSeconds, realElapseSeconds);

            CachedTransform.Translate(Vector2.right * m_BulletData.FlySpeed * elapseSeconds, Space.World);

            //如已达到最大飞行距离则隐藏自身
            if(CachedTransform.position.x >= 9f)
            {
                GameEntry.Entity.HideEntity(this);
            }
        }
        private void OnTriggerEnter2D(Collider2D collision)
        {
            //当子弹碰撞到管道后隐藏子弹和管道
            GameEntry.Sound.PlaySound(1);
            GameEntry.Entity.HideEntity(this);//隐藏子弹自身
            collision.gameObject.SetActive(false);

            //击中后派发加分事件
            AddScoreEventArgs e = ReferencePool.Acquire<AddScoreEventArgs>();
            GameEntry.Event.Fire(this, e.Fill(10));
        }

    }
}

