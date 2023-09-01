using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {


    public Animator TrapDoorAnim;

    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip doorClose; 

    void Awake()
    {
        TrapDoorAnim = GetComponent<Animator>();
        StartCoroutine(OpenCloseTrap());
    }


    IEnumerator OpenCloseTrap()
    {
        source.PlayOneShot(doorClose);
        TrapDoorAnim.SetTrigger("open");
        yield return new WaitForSeconds(2);
        source.PlayOneShot(doorClose);
        TrapDoorAnim.SetTrigger("close");
        yield return new WaitForSeconds(2);
        StartCoroutine(OpenCloseTrap());

    }
}