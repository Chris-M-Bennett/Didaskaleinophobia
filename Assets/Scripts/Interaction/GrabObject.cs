using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : InteractObject
{
    [SerializeField, Tooltip("Force at which object is thrown upon release")]
    private float ejectionForce = 2f;
    private Transform _grabbedBy;
    private Rigidbody _rigidBody;
    
    public override void DoAction(Transform caller)
    {
        if (_grabbedBy == null)
        {
            _grabbedBy = caller;
            caller.SendMessage("CarryObject", transform);
        }
        else
        {
            caller.SendMessage("DropObject", transform);
            _grabbedBy = null;
            _rigidBody.AddForce(transform.forward * ejectionForce);
        }
    }

    private void Start(){
        _rigidBody = GetComponent<Rigidbody>();
    }
}
