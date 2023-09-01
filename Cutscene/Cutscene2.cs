using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene2 : MonoBehaviour
{


    [SerializeField] private Animator anim;

    [SerializeField] private GameObject cameraMain;
    [SerializeField] private GameObject canvas;

    IEnumerator Start()
    {
        Cursor.visible = false;
        yield return new WaitForSecondsRealtime(1f);
        anim.SetTrigger("Scream");
        yield return new WaitForSecondsRealtime(5f);
        cameraMain.SetActive(true);
        canvas.SetActive(true);
        Destroy(gameObject);

    }

}
