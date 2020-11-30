using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseScript : MenuScript
{
    [SerializeField] GameObject player;
    public static bool _paused = false;
    

    void Start(){
        pausedPanel.SetActive(false);  
    }
    
    void Update(){
        if (Input.GetKeyDown(KeyCode.Escape)){
            if (_paused){
                Resume_Btn();
            }else{Pause();}
        }
    }

    public void Resume_Btn(){
        player.GetComponent<PlayerController>().enabled = true;
        pausedPanel.SetActive(false);
        settingsPanel.SetActive(false);
        Time.timeScale = 1.0f;
        _paused = false;
    }
    
    public void Pause(){
        player.GetComponent<PlayerController>().enabled = false;
        pausedPanel.SetActive(true);
        Time.timeScale = 0.0f;
        _paused = true;
    }
    
    public new void Settings_Btn(){
        settingsPanel.SetActive(true);
        pausedPanel.SetActive(false);
    }
    
    public void MainMenu_Btn(){
        SceneManager.LoadSceneAsync("Scenes/MainMenu");
    }
    
    public new void Back_Btn(){
        pausedPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }
}
