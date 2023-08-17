using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FlappyBird
{
    public class SettingForm : UGuiForm
    {
        public void OnCloseButtonClick() //¹Ø±Õ
        {
            Close();
        }
        public void OnMusicButtonChange(float value)
        {
            GameEntry.Sound.SetVolume("Music", value);
        }
        public void OnSoundButtonChange(float value)
        {
            GameEntry.Sound.SetVolume("Sound", value);
            GameEntry.Sound.SetVolume("UISound", value);
        }
    }
}
