using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForPlanksSpawn : MonoBehaviour
{
    [SerializeField] private GameObject Forplanks;
    
    private Quaternion ownRotation;
    private Vector3 ownPosition;
    
    void Update()
    {
        
        ownRotation = transform.rotation;
        ownPosition = transform.position;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Tree"))
        {
            SpawnForPlanks();
        }
    }

    private void SpawnForPlanks()
    {
            Instantiate(Forplanks, ownPosition, ownRotation);
            DestroySelf();
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
