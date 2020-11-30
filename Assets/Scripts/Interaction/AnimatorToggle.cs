using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Interaction{
    public class AnimatorToggle : InteractObject{
        [SerializeField]
        private Animator _animator;
        
        public void DoAction(Transform caller){
            _animator.SetTrigger("Toggle");
        }
        private void Start(){
            _animator = GetComponent<Animator>();
        }
    }
}
