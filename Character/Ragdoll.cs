using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ragdoll : MonoBehaviour
{

    void Start()
    {
        StartCoroutine(AnimatorOff());
    }

    IEnumerator AnimatorOff()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        GetComponent<Animator>().enabled = false;
        yield return new WaitForSecondsRealtime(5f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
