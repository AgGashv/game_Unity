using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossScript : MonoBehaviour
{

    [SerializeField] private NavMeshAgent nav;

    [SerializeField] private Animator anim;

    [SerializeField] private Image hpIm;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject fireball;
    [SerializeField] private GameObject fbPlace;
    [SerializeField] private GameObject basicAttack;
    [SerializeField] private GameObject tailAttack;
    [SerializeField] private GameObject youWin;
    [SerializeField] private GameObject music;


    [SerializeField] private bool fly = false;

    [SerializeField] private float dragonHP = 100f;
    [SerializeField] private float dist;
    [SerializeField] private float radius;
    [SerializeField] private float navSpeed;
    [SerializeField] private float colSize;

    private IEnumerator Start()
    {
        nav.speed = 0f;
        yield return new WaitForSecondsRealtime(5f);
        nav.speed = navSpeed;
    }


    private void Update()
    {
        var col = GetComponent<SphereCollider>();

        hpIm.fillAmount = dragonHP / 100f;

        if (dragonHP < 0)
        {
            dragonHP = 0f;
        }
        
        if (dragonHP <= 0f)
        {
            StartCoroutine(Death());
        }

        dist = Vector3.Distance(player.transform.position, transform.position);

        if (dist > radius && !fly)
        {
            nav.SetDestination(player.transform.position);
            anim.SetTrigger("Fire");
        }

        if (dist < radius && dist > 3 && !fly)
        {
            nav.SetDestination(player.transform.position);
            anim.SetTrigger("TailAttack");
        }

        if (dist < 3 && !fly)
        {
            nav.SetDestination(player.transform.position);
            anim.SetTrigger("BasicAttack");
        }

        var pos = transform.position;
        pos.y += 0.5f;
        Vector3 v = new Vector3(0, -1, 1);

        if (fly)
        {
            nav.SetDestination(player.transform.position);
        }
        
        if (Physics.Raycast(pos, v, out RaycastHit hit, 1f))
        {
            
            if (hit.collider.tag == "Fly" && fly == false)
            {
                Debug.Log("Fly");
                col.center = new Vector3(0.001f, 5f, 0.01f);
                anim.SetTrigger("TakeOff");
                fly = true;
            }
        }

        if (Physics.Raycast(pos, Vector3.down, out RaycastHit hitt, 1f))
        {
            if (hitt.collider.tag == "Ground" && fly)
            {
                Debug.Log("Land");
                col.center = new Vector3(0.001f, 2f, 0.01f);
                anim.SetTrigger("Land");
                fly = false;
            }
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PSword"))
        {
            dragonHP -= 10f;
        }
        if (other.CompareTag("Cast"))
        {
            dragonHP -= 20f;
        }
    }

    IEnumerator Death()
    {
        anim.SetTrigger("Died");
        nav.enabled = false;
        youWin.SetActive(true);
        music.SetActive(false);
        yield return new WaitForSecondsRealtime(10f);
        SceneManager.LoadScene(0);
    }

    void FireBall()
    {
        Instantiate(fireball, fbPlace.transform.position, fbPlace.transform.rotation);
    }

    void MouthAttackOn() => basicAttack.SetActive(true);
    void MouthAttackOff() => basicAttack.SetActive(false);

    void TailAttackOn() => tailAttack.SetActive(true);
    void TailAttackOff() => tailAttack.SetActive(false);
}
