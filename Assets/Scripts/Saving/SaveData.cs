using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Saving{
    [System.Serializable]
    public class SaveData
    {
       // public Slider brightnessSlider, volumeSlider, fovSlider;
       // public Dropdown graphicQualityDrop;
       // public Toggle fullScreenToggle;
        public float brightness, volume, cameraFov;
        public int quality;
        public bool fullScreen;
        public float[] playerPosition;
    
        public SaveData(SettingsScript settingsScript)
        {
            brightness = settingsScript.brightnessSlider.value;
            volume = settingsScript.volumeSlider.value;
            cameraFov = settingsScript.fovSlider.value;
            quality = settingsScript.graphicQualityDrop.value;
            fullScreen = settingsScript.fullScreenToggle.isOn;
        }
    }
}
