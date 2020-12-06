using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObject : MonoBehaviour
{
    [SerializeField, Tooltip("Describes object")]
    private string desc = "";
    
    [SerializeField, Tooltip("Describes action available for object")]
    public string actionDesc = "";
    
    //Causes game object to perform action
    public virtual void DoAction(Transform caller)
    {
        Debug.Log("Activate Action");
    }
    
}
