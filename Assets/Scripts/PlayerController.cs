using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using DefaultNamespace.AudioScriptableObject;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;

using static UnityEngine.Space;

//REQUIRES A CHARACTER CONTROLLER COMPONENT ON THE OBJECT THIS SCRIPT IS ATTACHED TO
[RequireComponent(typeof(CharacterController))]

public class PlayerController : MonoBehaviour
{

    private CharacterController _characterController;
    private Vector3 _characterVelocity;
    private const float Gravity = 9.8f;

    //serialized fields can stay private, but allow for modification in the unity editor
    [SerializeField] private Camera playerCamera;
    
    private float _verticalCameraAngle;

    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioEventWalking _eventWalking;

    //creates a variable for the player attributes, which is a scriptable object 
    //used to get the variables for walking, sprinting, health, etc
    [SerializeField] public PlayerAttributes playerAttributes;
    
    
    [SerializeField] private float _minVerticalCameraAngle = -75f;
    [SerializeField] private float _maxVerticalCameraAngle = 75f;
    //[SerializeField] private float _jumpForce = 1f;
    //[SerializeField] private float _walkSpeed = 2f;
    //[SerializeField] private float _sprintSpeed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        //retrieves the character controller component
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

        HandleCameraMovement();
        
        if (_characterController.isGrounded)
        {
            //ground movement
            //input from movement axes
            HandleGroundMovement();

            if (Input.GetButtonDown("Jump"))
            {
                
                _characterVelocity.y = playerAttributes.jumpForce;
                
            }
        }
        else
        {
            //air movement
            //HandleAirMovement();
        }

        //character velocity downwards is increased each frame, so a character accelerates as it falls
        _characterVelocity += Vector3.down * (Gravity * Time.deltaTime);
        //it is multiplied by Time.deltaTime so it increases each frame
        _characterController.Move(_characterVelocity * Time.deltaTime);

    }

    private void HandleAirMovement()
    {
        //gets input from movement axes
        Vector2 inputAxes = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));

        //gets the movement input for the character
        Vector3 inputSpaceMovement = new Vector3(inputAxes.x, y: _characterVelocity.y , inputAxes.y);
        
        //assigns the world space movement to find a direction to push the player in
        Vector3 worldSpaceMovement = transform.TransformVector(inputSpaceMovement);

        //sets the character velocity to the movement input, so character moves

        if (Input.GetAxisRaw("Sprint") == 1f)
        {
            _characterVelocity = worldSpaceMovement * playerAttributes.sprintSpeed;
        }
        else
        {
            _characterVelocity = worldSpaceMovement * playerAttributes.walkSpeed;
        }
    }

    /// <summary>
    /// This method takes the player's input and transforms it into world space movement,
    /// then uses an if statement to dictate whether the player is holding the sprint button or is just walking.
    /// </summary>
    private void HandleGroundMovement()
    {
        //gets input from movement axes
        Vector2 inputAxes = new Vector2(x: Input.GetAxisRaw("Horizontal"), y: Input.GetAxisRaw("Vertical"));

        //gets the movement input for the character
        Vector3 inputSpaceMovement = new Vector3(inputAxes.x, y: 0f, inputAxes.y);
        
        //assigns the world space movement to find a direction to push the player in
        Vector3 worldSpaceMovement = transform.TransformVector(inputSpaceMovement);

        //sets the character velocity to the movement input, so character moves

        if (Input.GetAxisRaw("Sprint") == 1f)
        {
            _characterVelocity = worldSpaceMovement * playerAttributes.sprintSpeed;
        }
        else
        {
            _characterVelocity = worldSpaceMovement * playerAttributes.walkSpeed;
        }

        //once the player starts walking, a random walking audio clip plays
        if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
        {

            if (!_audioSource.isPlaying)
            {
                
                _eventWalking.Play(_audioSource);
                
            }

        }

    }
    

    /// <summary>
    /// This method takes the input for character movement, and rotates the camera (on X and Y)
    /// and the player model (only on Y) according to the input.
    /// It also clamps the rotation angles so that the player can't flip the camera upside down.
    /// </summary>
    private void HandleCameraMovement()
    {
        //input camera axes
        Vector2 inputAxes = new Vector2(x: Input.GetAxisRaw("Horizontal_Camera"), y: Input.GetAxisRaw("Vertical_Camera"));
        //rotate character on the X axis ONLY
        transform.Rotate(Vector3.up, inputAxes.x, Space.Self);

        //rotate the camera on the Y axis
        
        //retrieves the camera angle
        _verticalCameraAngle -= inputAxes.y;
        
        //clamps the angle so the camera cannot flip upside down in-game

        
        _verticalCameraAngle = Mathf.Clamp(_verticalCameraAngle, _minVerticalCameraAngle, _maxVerticalCameraAngle);
        
        playerCamera.transform.localEulerAngles = new Vector3(_verticalCameraAngle, 0f, 0f);
    }
}
