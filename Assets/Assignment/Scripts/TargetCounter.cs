using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounter : MonoBehaviour
{
  
    public Slider targetsLeft;
 
    public void Targets(float targets)
    {
        targetsLeft.value += targets;  //recieves message from targets and updates the target counter slider to display remaining targets 
       
    }
}
