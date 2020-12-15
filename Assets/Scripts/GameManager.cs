using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private MannequinRotation mannequin1, mannequin2, mannequin3;
    public int manneRot1, manneRot2, manneRot3;

    private void OnValidate(){
        manneRot1 = Mathf.Clamp(manneRot1, 0, 3);
        manneRot2 = Mathf.Clamp(manneRot2, 0, 3);
        manneRot3 = Mathf.Clamp(manneRot3, 0, 3);
    }

    void Update(){//Checks if mannequins are rotated to solution rotations
        if (mannequin1.GetSolutionOrientation() == manneRot1 &&
            mannequin2.GetSolutionOrientation() == manneRot2 &&
            mannequin3.GetSolutionOrientation() == manneRot3){
            Debug.Log("Complete");
        }
    }
}
