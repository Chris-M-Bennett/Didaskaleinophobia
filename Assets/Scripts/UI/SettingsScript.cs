using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
public class SettingsScript : MenuScript{
    private GameObject player;
    private Camera _camera;
    
    public AudioMixer audioMixer;
    public GameObject minBright, maxBright;
    
    public Dropdown resolutionsDropdown;
    private void Start(){
        Screen.fullScreen = true;
        settingsPanel.SetActive(false);
        player = GameObject.FindWithTag("Player");
        _camera = player.GetComponentInChildren<Camera>();
    }
    public void Brightness_Sdr(float level){
        //RenderSettings.ambientLight = new Color(level, level, level, 1.0f);
        minBright.GetComponent<Image>().color = new Color(0f, 0f, 0f, -level);
        maxBright.GetComponent<Image>().color = new Color(1f, 1f, 1f, level);
    }
    
    public void Volume_Sdr(float volume){
        audioMixer.SetFloat("Volume", volume); //Sets master volume to value of volume slider
    }
    
    public void Fov_sdr(float field){
        _camera.fieldOfView = field;
    }
    
    public void Graphic_Drop(int quality){
        QualitySettings.SetQualityLevel(quality);
    }
    
    public void FullScreen (bool toggle){
        Screen.fullScreen = toggle;
    }
}