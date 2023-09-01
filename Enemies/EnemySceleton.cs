using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemySceleton : MonoBehaviour
{
    [SerializeField] private GameObject enSword;
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject ragdoll;

    [SerializeField] private Image imHP;
    
    [SerializeField] NavMeshAgent nav;
    
    [SerializeField] private Animator anim;
    
    [SerializeField] private float dist;
    [SerializeField] private float radius;
    [SerializeField] private float HP = 100f;

    [SerializeField] private AudioSource source;

    void Update()
    {
        imHP.fillAmount = HP / 100f;

        if (HP <= 0f)
        {
            Instantiate(ragdoll, transform.position, transform.rotation);
            Destroy(gameObject);
        }

        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > radius)
        {
            nav.enabled = false;
            anim.SetTrigger("Idle");
        }
        if (dist < radius && dist > 2f)
        {
            source.enabled = true;
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            anim.SetTrigger("Run");
        }
        else
            source.enabled = false;

        if (dist < 2f)
            anim.SetTrigger("Attack");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PSword"))
        {
            anim.SetTrigger("Impact");
            HP -= 34f;
        }
        if (other.CompareTag("Cast"))
        {
            anim.SetTrigger("Impact");
            HP -= 50f;
        }
    }

    void MotionStop()
    {
        nav.speed = 0f;
        enSword.SetActive(false);
    }
    void MotionContinue() => nav.speed = 3.5f;

    void EnSwordIn() => enSword.SetActive(true);
    void EnSwordOut() => enSword.SetActive(false);

    
}
