using UnityEngine;

namespace Interaction{
    public class GrabObject : InteractObject
    {
        [SerializeField, Tooltip("Force at which object is thrown upon release")]
        private float ejectionForce = 2f;
        [Tooltip("Transform of player grabbing object")]
        private Transform _grabbedBy;
        [Tooltip("Rigidbody component of object")]
        private Rigidbody _rigidBody;
    
        public override void DoAction(Transform caller)
        {//Checks if object is already being carried by player
            if (_grabbedBy == null)
            {//Calls CarryObject method of PlayerInteraction to pick up object
                _grabbedBy = caller;
                caller.SendMessage("CarryObject", transform);
            }
            else
            {//Calls DropObject method of PlayerInteraction to drop object with slight ejection force
                caller.SendMessage("DropObject", transform);
                _grabbedBy = null;
                _rigidBody.AddForce(transform.forward * ejectionForce);
            }
        }

        private void Start()
        {//References Rigidbody component
            _rigidBody = GetComponent<Rigidbody>();
        }
    }
}
