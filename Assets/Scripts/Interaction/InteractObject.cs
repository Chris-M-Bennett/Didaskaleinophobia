using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InteractObject : MonoBehaviour
{
    [SerializeField, Tooltip("Describes object")]
    private string desc = "";
    
    [SerializeField, Tooltip("Describes actions available for object")]
    public string actionDesc = "";
    
    //Display description of object on HUD
    public virtual void DisplayDesc()
    {
       // HUD.instance.SetOutputText($"{desc}\n{actionDesc}");
    }
    public virtual void DoAction(Transform caller)
    {
        Debug.Log("Activate Action");
    }
    
}
