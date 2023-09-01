using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTrap : MonoBehaviour
{

    private void Update()
    {
         var rig = GetComponent<Rigidbody>(); 
        
         rig.AddForce(Vector3.forward * 7f);
    }
    
    
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player") || collision.gameObject.CompareTag("walls"))
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSecondsRealtime(5f);
        Destroy(gameObject);
    }
}
