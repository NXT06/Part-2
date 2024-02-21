using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCounter : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider targetsLeft;
    // Start is called before the first frame update
    public void Targets(float targets)
    {
        targetsLeft.value += targets;
        UnityEngine.Debug.Log(targets);
    }
}
