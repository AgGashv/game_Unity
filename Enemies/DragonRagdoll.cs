using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonRagdoll : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return new WaitForSecondsRealtime(10f);
        Destroy(gameObject);
    }


}
