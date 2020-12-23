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
    private float angleLeft;
    
    [SerializeField] private AudioSource _audioSource;

    private void Start(){
        startRot = transform.eulerAngles.y;
        _audioSource = GetComponent<AudioSource>();
    }

    public override void DoAction(Transform caller){
        if (rotating == false)
        {
        _audioSource.Play();
         rotating = true;
         angleLeft += 90f;
         }
    }

    private void Update()
    {
        if (angleLeft > 0f)
        {
            float rotationThisTick = Time.deltaTime * rotateSpeed;
        
            rotationThisTick = Math.Min(angleLeft, rotationThisTick);
        
            transform.Rotate(Vector3.up * (rotationThisTick));
            angleLeft -= rotationThisTick;
        }else{rotating = false;}
    }
    public int GetSolutionOrientation(){
        return (int)((Mathf.Repeat(Mathf.Round(transform.rotation.eulerAngles.y - startRot), 360f) / 90.0f)%4);
    }
}
