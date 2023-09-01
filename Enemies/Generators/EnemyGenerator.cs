using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> enPosition;

    [SerializeField] private List<GameObject> enemies;


    void Start()
    {
        GameObject[] array = new GameObject[6];
        for (int i = 0; i < array.Length; i++)
        {
            int randomPosition = Random.Range(0, enPosition.Count);
            int randomEnemy = Random.Range(0, enemies.Count);
            array[i] = Instantiate(enemies[randomEnemy], enPosition[randomPosition]);
            array[i].SetActive(true);
            enPosition.RemoveAt(randomPosition);
        }
        
    }

}
