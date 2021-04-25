using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityGameFramework.Runtime;

namespace FlappyBird
{


    public class SettingForm : UGuiForm
    {

        public void OnCloseButtonClick()
        {
            Close();
        }

        public void OnMusicVolumeChanged(float volume)
        {
            GameEntry.Sound.SetVolume("Music", volume);
        }

        public void OnSoundVolumeChange(float value)
        {
            GameEntry.Sound.SetVolume("Sound", value);
            GameEntry.Sound.SetVolume("UISound", value);
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            base.OnClose(isShutdown, userData);


        }

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
        }
    }
}