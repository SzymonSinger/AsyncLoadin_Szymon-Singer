using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectSpeed : MonoBehaviour
{
    private TreeHealth _treeHealth;

    void Start()
    {
        _treeHealth = GetComponent<TreeHealth>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("FallingTrunk"))
        {
            float capturedSpeed = other.gameObject.GetComponent<Falling>().speed;
            _treeHealth.treeHealth -= capturedSpeed * 4;

        }
    }
}
