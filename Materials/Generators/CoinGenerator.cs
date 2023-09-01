using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> coinPosition;

    [SerializeField] private GameObject coin;

    void Start()
    {
        GameObject[] array = new GameObject[5];
        for (int i = 0; i < 5; i++)
        {
            int random = Random.Range(0, coinPosition.Count);
            array[i] = Instantiate(coin, coinPosition[random]);
            array[i].SetActive(true);
            coinPosition.RemoveAt(random);
        }
    }


}
