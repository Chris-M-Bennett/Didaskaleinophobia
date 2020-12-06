using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject mannequin1, mannequin2, mannequin3;
    [SerializeField] private Text _completeText;
    

    void Update(){//Checks if mannequins are rotated to solution rotations
        if (mannequin1.transform.rotation.y == 0f &&
            mannequin2.transform.rotation.eulerAngles.y == 180f &&
            mannequin3.transform.rotation.eulerAngles.y == 90f){
            _completeText.text = $"Puzzle Complete";
        }
    }
}
