using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    public Slider slider;
    
    float damageSave;
    // Start is called before the first frame update

    public void Start()
    {
        
    }
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
       
    }
    public void CurrentHP(float health)
    {
        slider.value = health;
    }
}
