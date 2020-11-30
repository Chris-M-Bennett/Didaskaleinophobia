using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    [SerializeField] private float _carryDistance = 1.5f;
    [SerializeField] private float _interactionDistance = 2f;
    [SerializeField]private Transform _carriedObject;
    private RaycastHit _hit;
    private Transform _selectedObject;

    public void CarryObject (Transform obj){
        //Checks if player already carrying something
        if (_carriedObject !=null){
            return;
        }
        obj.GetComponent<Rigidbody>().isKinematic = true;
        _carriedObject = obj.transform;
    }
    
    public void DropObject(Transform obj){
        if (_carriedObject == obj){
            obj.GetComponent<Rigidbody>().isKinematic = false;
            _carriedObject = null;
        }
    }
    // Start is called before the first frame update
    private void Start(){
        if (_camera == null){
            _camera = GetComponentInChildren<Camera>();
        }  
    }

    // Update is called once per frame
    private void Update(){
        if(_carriedObject != null){
            if(Input.GetButtonDown("Action")){
                _carriedObject.transform.SendMessageUpwards("DoAction", transform);
            }
            
            UpdateCarriedObject();
            return;
        }
        //Cast ray from centre of viewport
        var ray = _camera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        
        if (Physics.Raycast(ray, out _hit, _interactionDistance,
            LayerMask.GetMask("Interactable"))){
            _selectedObject = _hit.transform;
            _selectedObject.SendMessageUpwards("DisplayDetailUI",
                SendMessageOptions.DontRequireReceiver);
            if (Input.GetButtonDown("Action")){
                _selectedObject.transform.SendMessageUpwards("DoAction", transform);
            }
        }else{_selectedObject = null;}
    }
    
    //Moves carried object towards carry position
    private void UpdateCarriedObject(){
        //Checks if player is carry something
        if (_carriedObject != null){
            //Gets transform of player camera
            var camTransform = _camera.transform;
            //Gets position directly in front of player camera
            var pos = camTransform.position + (camTransform.forward * _carryDistance);
            //Gets look rotation of player camera
            var rot = Quaternion.LookRotation(camTransform.forward, Vector3.up);
            //Gets euler rotation of player camera
            var rot2 = Quaternion.Euler(0, rot.eulerAngles.y, 0); 
            
            //Checks if carried object is affected by physics
            if (_carriedObject.gameObject.GetComponent<Rigidbody>().isKinematic){ 
                //Smoothly moves carried object directly in front of player camera 
                _carriedObject.position = Vector3.Lerp(_carriedObject.position, pos, Time.deltaTime * 100.0f);
                //Smoothly rotates carried object to player camera rotation 
                _carriedObject.rotation = Quaternion.Lerp(_carriedObject.rotation, rot2, Time.deltaTime * 100.0f);
            }
;        }
    }
}
