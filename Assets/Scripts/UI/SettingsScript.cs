using Saving;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI{
    [System.Serializable]
    public class SettingsScript : MenuScript
    {
        public AudioMixer audioMixer;
        public GameObject minBright, maxBright;
        public Slider brightnessSlider, volumeSlider, fovSlider, sensitivitySlider;
        public Dropdown graphicQualityDrop;
        public Toggle fullScreenToggle;
        public  float cameraFov;
        public float cameraSensitivity;
        private void Start()
        {
            SaveData data = SerialiseSystem.LoadData();
            brightnessSlider.value = data.brightness;
            volumeSlider.value = data.volume;
            fovSlider.value = data.cameraFov;
            sensitivitySlider.value = data.sensitivity;
            graphicQualityDrop.value = data.quality;
            fullScreenToggle.isOn = data.fullScreen;
            settingsPanel.SetActive(false);
        }
        
        public void Volume_Sdr(float volume)
        {
            //Sets volume level of audio mixer to value of volume slider
            audioMixer.SetFloat("MasterVolume", volume);
        }
        
        public void Brightness_Sdr(float level)
        {
            //Sets alpha of dark image to inverse of brightness slider level
            minBright.GetComponent<Image>().color = new Color(0f, 0f, 0f, -level);
            //Sets alpha of light image to value of  brightness slider level
            maxBright.GetComponent<Image>().color = new Color(1f, 1f, 1f, level);
        }

        public void Fov_sdr(float field)
        {//Sets camera's field of view to value of FOV slider
            cameraFov = field;
        }
        
        public void Sensitivity_Sdr(float sensitivity)
        {//Sets camera's sensitivity to value of sensitivity slider
           cameraSensitivity = sensitivity;
        }
    
        public void Graphic_Drop(int quality)
        {//Sets graphic quality to selection from graphic dropdown
            QualitySettings.SetQualityLevel(quality);
        }
    
        public void FullScreen (bool toggle)
        {//Sets full screen Boolean to value of full screen toggle
            Screen.fullScreen = toggle;
        }
        
        public void Back_Btn()
        {
            settingsPanel.SetActive(false);
            if (pausedPanel != null)
            {
                pausedPanel.SetActive(true);
            }
            SerialiseSystem.SaveData(this);
        }
    }
}