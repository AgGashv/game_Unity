using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enter : MonoBehaviour
{
    [SerializeField] private GameObject mainButtons;


    void Update()
    {
        if (Input.anyKey)
        {
            Destroy(gameObject);
            mainButtons.SetActive(true);
        }
    }
}
