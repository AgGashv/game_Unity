using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyDragon : MonoBehaviour
{
    [SerializeField] private NavMeshAgent nav;

    [SerializeField] private Animator anim;

    [SerializeField] private Image HPIm;


    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject fbPlace;
    [SerializeField] private GameObject hpBar;

    [SerializeField] private float dist;
    [SerializeField] private float radius;
    [SerializeField] public float dragonHP = 100f;

    void Update()
    {
        HPIm.fillAmount = dragonHP / 100f;

        if (dragonHP < 0)
            dragonHP = 0f;

        if (dragonHP <= 0f)
        {
            StartCoroutine(Death());
        }

        dist = Vector3.Distance(player.transform.position, transform.position);
        if (dist > radius)
        {
            nav.enabled = false;
            anim.SetTrigger("Idle");
        }

        if (dist < radius)
        {
            nav.enabled = true;
            nav.SetDestination(player.transform.position);
            anim.SetTrigger("Attack");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PSword"))
        {
            anim.SetTrigger("Impact");
            dragonHP -= 25f;
        }
        if (other.CompareTag("Cast"))
        {
            anim.SetTrigger("Impact");
            dragonHP -= 34f;
        }
    }

    IEnumerator Death()
    {
        anim.SetTrigger("Died");
        hpBar.SetActive(false);
        nav.speed = 0f;
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }

    void FireBall()
    {
        Instantiate(fireball, fbPlace.transform.position, fbPlace.transform.rotation);
    }
}
