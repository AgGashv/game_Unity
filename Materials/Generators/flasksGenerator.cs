using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flasksGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> flaskPosition;

    [SerializeField] private GameObject flask;

    void Start()
    {
        GameObject[] array = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            int random = Random.Range(0, flaskPosition.Count);
            array[i] = Instantiate(flask, flaskPosition[random]);
            array[i].SetActive(true);
            flaskPosition.RemoveAt(random);
        }
    }
}


