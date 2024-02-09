using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public Transform spawner;
    public GameObject spearPrefab;
    // Start is called before the first frame update


    public void SpawnSpear()
    {
        Instantiate(spearPrefab, spawner.position, spawner.rotation);
    }
}
