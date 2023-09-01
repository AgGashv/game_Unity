using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneGeneration : MonoBehaviour
{
    [SerializeField] private GameObject stone;
    [SerializeField] private List<Transform> stones;


    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(5f);
        Instantiate(stone, stones[Random.Range(0, stones.Count)]);
        StartCoroutine(Start());
    }


}
