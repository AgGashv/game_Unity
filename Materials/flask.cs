using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class flask : MonoBehaviour
{
    [SerializeField] private MainCharacter characterAnimation;
 
    [SerializeField] private GameObject flaskO;
    [SerializeField] private GameObject backgrounTake;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("player")) 
        { 
            backgrounTake.SetActive(true);
            if (Input.GetKey(KeyCode.E) && characterAnimation.HPflask < 4f)
            {
                Destroy(flaskO);
                backgrounTake.SetActive(false);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        backgrounTake.SetActive(false);  
    }
}
