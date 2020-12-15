using System;
using UnityEngine;

namespace Interaction{
    public class ReceiveObject : MonoBehaviour
    {
        [SerializeField][Tooltip("Version of object carried by player")]
        private GameObject received;
        [SerializeField][Tooltip("Version of object attached to this object")]
        private GameObject attached;

        private void Start()
        {
          attached.SetActive(false);  
        }

        private void OnCollisionEnter(Collision col)
        {
            if (col.gameObject == received)
            {
                Destroy(received);
                attached.SetActive(true);
            }
        }
    }
}
