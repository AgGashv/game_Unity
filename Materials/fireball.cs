using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireball : MonoBehaviour
{
    [SerializeField] private GameObject ball;

    [SerializeField] private AudioSource source;
    
    [SerializeField] private AudioClip fire;
 

    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }


    void Update() => transform.Translate(8f * Time.deltaTime * new Vector3(0, 1, 0.05f), Space.Self);

    void OnTriggerEnter(Collider other)
    {
        var col = gameObject.GetComponent<Collider>();
        source.PlayOneShot(fire);
        Destroy(ball);
        col.enabled = false;
    }


}
