using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonEnemySounds : MonoBehaviour
{

    [SerializeField] private AudioSource sourceQuietDamage;
    [SerializeField] private AudioSource sourceLoud;

    [SerializeField] private AudioClip shootSound;
    [SerializeField] private AudioClip damageSound;
    [SerializeField] private AudioClip diedSound;
    [SerializeField] private AudioClip dragonDamage;   

    [SerializeField] private EnemyDragon enemyDragon;

    public void Shoot() => sourceLoud.PlayOneShot(shootSound);

    public void Damage()
    {
        if (enemyDragon.dragonHP >= 0f)
        {
            sourceQuietDamage.PlayOneShot(damageSound);
            sourceQuietDamage.PlayOneShot(dragonDamage);
        }
    }

    public void Death()
    {
        sourceQuietDamage.PlayOneShot(diedSound);
    }



}
