using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject plane;
    float spawnTime = 1; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
  
      
        
    }

    private void FixedUpdate()
    {

        spawnTime++;
        UnityEngine.Debug.Log(spawnTime);
        if (spawnTime > Random.Range(100, 300))
        {
            
            Instantiate(plane, spawner.position, spawner.rotation);
            spawnTime = 2;
        }
    }

}
