using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrunkHealth : MonoBehaviour
{
    [SerializeField] private float treeHealth = 10;
    [SerializeField] private float treeDmg = 2;
    [SerializeField] private AudioClip axeHit;
    public bool destroyed = false;
    private AudioSource _audio;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {
        if (treeHealth <= 0)
        {
            destroyed = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (treeHealth > 0)
        {
            if (other.gameObject.CompareTag("Axe"))
            {
                _audio.PlayOneShot(axeHit);
                treeHealth -= treeDmg;
                AxeAttack.Axe_particle.Play();
            }
        }
    }
}
