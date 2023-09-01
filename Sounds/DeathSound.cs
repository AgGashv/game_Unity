using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSound : MonoBehaviour
{

    [SerializeField] private AudioSource youDied;

    [SerializeField] private AudioClip sound;


    public void Sound()
    {
        youDied.PlayOneShot(sound);
    }
}
