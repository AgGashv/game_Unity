using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    [SerializeField] private AudioSource characterAudioQuiet;
    [SerializeField] private AudioSource characterAudioLoud;

    [SerializeField] private AudioClip attack1;
    [SerializeField] private AudioClip[] moves;
    [SerializeField] private AudioClip[] steps;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip damageVoice;



    public void MoveSound() => characterAudioLoud.PlayOneShot(moves[Random.Range(0, moves.Length)]);

    public void StepSound() => characterAudioQuiet.PlayOneShot(steps[Random.Range(0, steps.Length)]);

    public void Attack1() => characterAudioLoud.PlayOneShot(attack1);

    public void DamageSound()
    {
        characterAudioQuiet.PlayOneShot(damageSound);
        characterAudioQuiet.PlayOneShot(damageVoice);
    }

}
