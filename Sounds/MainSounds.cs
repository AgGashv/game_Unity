using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSounds : MonoBehaviour
{

    [SerializeField] private AudioSource characterAudioQuiet;
    [SerializeField] private AudioSource characterAudioLoud;
    [SerializeField] private AudioSource characterAudioMedium;

    
    [SerializeField] private AudioClip drinkFlask;
    [SerializeField] private AudioClip picking;
    [SerializeField] private AudioClip metalStep;
    [SerializeField] private AudioClip woodenStep;
    [SerializeField] private AudioClip attack1;
    [SerializeField] private AudioClip attack2;
    [SerializeField] private AudioClip[] waterStep;
    [SerializeField] private AudioClip[] damageCharacter;
    [SerializeField] private AudioClip[] moves;
    [SerializeField] private AudioClip[] steps;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip castSound;



    public void DrinkinFlask() => characterAudioMedium.PlayOneShot(drinkFlask);

    public void PickingUp() => characterAudioQuiet.PlayOneShot(picking);


    public void MoveSound() => characterAudioLoud.PlayOneShot(moves[Random.Range(0, moves.Length)]);

    public void StepSound()
    {
        var pos = transform.position;
        pos.y += 0.6f;

        if (Physics.Raycast(pos, Vector3.down,  out RaycastHit hit, 0.7f))
        {
            if (hit.collider.tag == "Ground" || hit.collider.tag == "walls")
            {
                characterAudioQuiet.PlayOneShot(steps[Random.Range(0, steps.Length)]);
            }
            if (hit.collider.tag == "LatticeMinusHP")
            {
                characterAudioLoud.PlayOneShot(metalStep);
            }
            if (hit.collider.tag == "Wood")
            {
                characterAudioLoud.PlayOneShot(woodenStep);
            }
            if (hit.collider.tag == "minusHP")
            {
                characterAudioQuiet.PlayOneShot(waterStep[Random.Range(0, waterStep.Length)]);
            }
        }
        
    }

    public void GettingDamage() => characterAudioQuiet.PlayOneShot(damageCharacter[Random.Range(0, damageCharacter.Length)]);

    public void Attack1() => characterAudioLoud.PlayOneShot(attack1);

    public void Attack2() => characterAudioLoud.PlayOneShot(attack2);

    public void DamageSound() => characterAudioQuiet.PlayOneShot(damageSound);

    public void CastSound() => characterAudioMedium.PlayOneShot(castSound);

}
