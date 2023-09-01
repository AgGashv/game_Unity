using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    [SerializeField] private AudioSource myFx;
    [SerializeField] private AudioClip guidanceSound;
    [SerializeField] private AudioClip clickSound;


    public void GuidanceSound() => myFx.PlayOneShot(guidanceSound);


    public void ClickSound() => myFx.PlayOneShot(clickSound);
}
