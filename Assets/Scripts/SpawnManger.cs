using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManger : MonoBehaviour
{
    [SerializeField] GameObject _enemyPreab;
    void Start()
    {
        Instantiate(_enemyPreab, new Vector3(0, 5, 0), transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
