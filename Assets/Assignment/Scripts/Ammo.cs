using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public Slider ammo;
    // Start is called before the first frame update
    public void Bullets(float bullets)
    {
        ammo.value += bullets; 
        UnityEngine.Debug.Log(bullets);
    }
}
