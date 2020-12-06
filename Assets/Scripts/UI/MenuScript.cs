using System;
using Saving;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI{
    public class MenuScript : MonoBehaviour
    {
        [Tooltip("Stores last scene loaded")]
        public string lastScene;
    
        public GameObject pausedPanel;
        public GameObject settingsPanel;
        
        [SerializeField] private SettingsScript _settingsScript;

        public void New_Btn(){//Loads first scene of game
            SceneManager.LoadSceneAsync("TestScene");
        }
    
        public void Load_Btn(){//Loads last played scene of game
            SceneManager.LoadSceneAsync(lastScene);
        }
    
        public void Settings_Btn(){
            settingsPanel.SetActive(true);
        }

        public void Quit_Btn(){
            Application.Quit();
        }
    }
}
