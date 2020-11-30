using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuScript : MonoBehaviour
{
    [Tooltip("Stores last scene loaded")]
    public string lastScene;
    
    public GameObject pausedPanel;
    public GameObject settingsPanel;

    public void New_Btn(){//Loads first scene of game
        SceneManager.LoadSceneAsync("TestScene");
    }
    
    public void Load_Btn(){//Loads last played scene of game
        SceneManager.LoadSceneAsync(lastScene);
    }
    
    public void Settings_Btn(){
        settingsPanel.SetActive(true);
    }
    
    public void Back_Btn(){
        settingsPanel.SetActive(false);
    }
    
    public void Quit_Btn(){
        Application.Quit();
    }
}
