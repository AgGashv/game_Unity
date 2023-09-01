using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnRagdollDestroy : MonoBehaviour
{
    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<Animator>().enabled = false;
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }

}
