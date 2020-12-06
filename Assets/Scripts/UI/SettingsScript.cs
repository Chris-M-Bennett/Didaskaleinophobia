using Saving;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace UI{
    [System.Serializable]
    public class SettingsScript : MenuScript
    {
        private GameObject _player;
        private Camera _camera;
    
        public AudioMixer audioMixer;
        public GameObject minBright, maxBright;
        public Slider brightnessSlider, volumeSlider, fovSlider;
        public Dropdown graphicQualityDrop;
        public Toggle fullScreenToggle;
        private void Start()
        {
            SaveData data = SerialiseSystem.LoadData();
            brightnessSlider.value = data.brightness;
            volumeSlider.value = data.volume;
            fovSlider.value = data.cameraFov;
            graphicQualityDrop.value = data.quality;
            fullScreenToggle.isOn = data.fullScreen;
            //Starts with settings panel hidden
            settingsPanel.SetActive(false);
            //References player
            _player = GameObject.FindWithTag("Player");
            //References player camera
            _camera = _player.GetComponentInChildren<Camera>();
        }
        public void Brightness_Sdr(float level)
        {
            //Sets alpha of dark image to inverse of brightness slider level
            minBright.GetComponent<Image>().color = new Color(0f, 0f, 0f, -level);
            //Sets alpha of light image to value of  brightness slider level
            maxBright.GetComponent<Image>().color = new Color(1f, 1f, 1f, level);
        }
    
        public void Volume_Sdr(float volume)
        {
            //Sets volume level of audio mixer to value of volume slider
            audioMixer.SetFloat("Volume", volume);
        }
    
        public void Fov_sdr(float field)
        {
            //Sets camera's field of view to value of FOV slider
            _camera.fieldOfView = field;
        }
        
        public void Sensitivity_Sdr()
        {
            
        }
    
        public void Graphic_Drop(int quality)
        {
            //Sets graphic quality to selection from graphic dropdown
            QualitySettings.SetQualityLevel(quality);
        }
    
        public void FullScreen (bool toggle)
        {
            //Sets full screen Boolean to value of full screen toggle
            Screen.fullScreen = toggle;
        }
        
        public void Back_Btn()
        {
            settingsPanel.SetActive(false);
            SerialiseSystem.SaveData(this);
        }
    }
}