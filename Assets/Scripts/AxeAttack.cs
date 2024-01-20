using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeAttack : MonoBehaviour
{
    [SerializeField] private GameObject axe;
    
    private Animator animator;
    private BoxCollider axeCollider;
    public static ParticleSystem Axe_particle;

    void Start()
    {
        Axe_particle = axe.GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
        axeCollider = axe.GetComponent<BoxCollider>();
        AxeTriggerOff();
    }
    void Update()
    {
        AxeSwing();
    }

    private void AxeSwing()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetTrigger("Attack");
        }
    }

    public void AxeTriggerOn()
    {
        axeCollider.enabled = true;
    }

    public void AxeTriggerOff()
    {
        Axe_particle.Stop();
        axeCollider.enabled = false;
    }
}
