using System.Collections;
using System.Collections.Generic;
using System.Net.Http.Headers;
using UnityEngine;

public class TreeHandling : MonoBehaviour
{
    [SerializeField] private GameObject fullTrunk;
    [SerializeField] private GameObject cuttedTrunk;
    [SerializeField] private GameObject fallingTrunk;
    [SerializeField] private TreeHealth Full;
    [SerializeField] private AudioClip fallingSound;
    
    private AudioSource _audio;
    private bool isCutted;
    private bool isFalling = false;
    private bool isDestroyed;
    private Rigidbody fallingRB;
    
    void Start()
    {
        _audio = GetComponent<AudioSource>();
        fallingRB = fallingTrunk.GetComponent<Rigidbody>();
        fullTrunk.SetActive(true);
        cuttedTrunk.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        isCutted = Full.destroyed;
        CuttedTree();
    }

    private void CuttedTree()
    {
        if (isCutted)
        {
            fullTrunk.SetActive(false);
            cuttedTrunk.SetActive(true);
            Fall();
        }   
    }

    private void Fall()
    {
        Vector3 fallDirection = Camera.main.transform.forward;
        fallDirection.y = 0f;
        fallDirection.Normalize();
        if (!isFalling)
        {
            _audio.PlayOneShot(fallingSound);
            fallingRB.AddForce(fallDirection * 30f, ForceMode.Impulse);
            isFalling = true;
        }

    }
}
