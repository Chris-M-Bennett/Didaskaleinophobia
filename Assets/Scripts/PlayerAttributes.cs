using UnityEngine;

namespace DefaultNamespace
{
    //menu in unity UI
    [CreateAssetMenu(fileName = "PlayerAttributes", menuName = "Player/PlayerAttributes", order = 0)]
    
    //simple scriptable object that holds player attributes.
    //this needs to be created in unity using the assets menu.
    //can modify these variables whilst in play mode and they will not change upon exiting play mode.
    public class PlayerAttributes : ScriptableObject
    {

        public float maxHealth;
        public float walkSpeed;
        public float sprintSpeed;
        public float jumpForce;
    }
}