using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanksSpawn : MonoBehaviour
{
    [SerializeField] private GameObject planks;
    
    private Quaternion ownRotation;
    private Vector3 ownPosition;
    private TrunkHealth health;
    private bool isDestroyed;

    void Start()
    {
        health = GetComponent<TrunkHealth>();
    }
    void Update()
    {
        isDestroyed = health.destroyed;
        ownRotation = transform.rotation;
        ownPosition = transform.position;
        SpawnPlanks();
    }

    private void SpawnPlanks()
    {
        if (isDestroyed)
        {
            Instantiate(planks, ownPosition, ownRotation);
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }

    
}
