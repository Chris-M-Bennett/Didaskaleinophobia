using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MannequinRotation : InteractObject
{
    private bool rotating = false;
    private float startRot;
    [SerializeField][Tooltip("Sets speed mannequin rotates at")]
    private float rotateSpeed = 50;
    
    public override void DoAction(Transform caller){
         rotating = true;
         startRot = transform.eulerAngles.y;
    }

    private void Update(){
        if(rotating){
            transform.Rotate(Vector3.up * (rotateSpeed * Time.deltaTime ) );
            if (transform.eulerAngles.y >= startRot+90.0f){
                rotating = false;
            }
        }
    }
}
