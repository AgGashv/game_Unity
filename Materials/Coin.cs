using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    
    
    void Update() => gameObject.transform.Rotate(0f, 0.7f, 0f);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("player"))
            Destroy(gameObject);
    }
}
