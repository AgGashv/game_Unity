using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossSound : MonoBehaviour
{
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip scream;
    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip deathSound;

    [SerializeField] private AudioSource bossSourceLoud;
    [SerializeField] private AudioSource bossSourceQuite;


    void Scream() => bossSourceLoud.PlayOneShot(scream);


    void Shoot() => bossSourceQuite.PlayOneShot(shootSound);

    void DeathSound() => bossSourceQuite.PlayOneShot(deathSound);

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PSword"))
        {
            bossSourceQuite.PlayOneShot(damageSound);
        }
        if (other.CompareTag("Cast"))
        {
            bossSourceQuite.PlayOneShot(damageSound);
        }
    }
}
