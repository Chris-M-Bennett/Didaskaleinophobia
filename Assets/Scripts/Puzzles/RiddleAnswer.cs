using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using  UnityEngine.UI;

public class RiddleAnswer : InteractObject
{
    [SerializeField] private Text _completeText;
        
    public override void DoAction(Transform caller){
        _completeText.text = $"Puzzle Complete";
    }
}
