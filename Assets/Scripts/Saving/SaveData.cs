using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Saving{
    [System.Serializable]
    public class SaveData
    {
        public float brightness, volume, cameraFov, sensitivity;
        public int quality;
        public bool fullScreen;
        public float[] playerPosition;
    
        public SaveData(SettingsScript settingsScript)
        {
            brightness = settingsScript.brightnessSlider.value;
            volume = settingsScript.volumeSlider.value;
            cameraFov = settingsScript.fovSlider.value;
            sensitivity = settingsScript.sensitivitySlider.value;
            quality = settingsScript.graphicQualityDrop.value;
            fullScreen = settingsScript.fullScreenToggle.isOn;
        }
    }
}
