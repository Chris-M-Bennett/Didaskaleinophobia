using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class ShowPaper : InteractObject
{
    [SerializeField] private GameObject _paper;
    [SerializeField] private GameObject _paperText;
    private GameObject player;
    private bool looking;
    
        
    public override void DoAction(Transform caller){
        if (looking){
            //Sets looking Boolean to false
            looking = false;
            //Lets player move
            player.GetComponent<PlayerController>().enabled = true;
            //Hides paper interface element
            _paper.SetActive(false);
            //Hides paper writing interface element
            _paperText.SetActive(false);
        }else{
            //Sets looking Boolean to true
            looking = true;
            //References player
            player = GameObject.FindWithTag("Player");
            //Stops player move
            player.GetComponent<PlayerController>().enabled = false;
            //Shows paper interface element
            _paper.SetActive(true);
            //Shows paper writing interface element
            _paperText.SetActive(true);
        }
    }
}
