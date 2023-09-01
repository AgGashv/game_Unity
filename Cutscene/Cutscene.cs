using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    [SerializeField] private GameObject secondCam;
    [SerializeField] private GameObject firstCam;
    [SerializeField] private GameObject canvas;

    [SerializeField] private MainCharacter main;
    [SerializeField] private CharacterMovement characterMovement;
    [SerializeField] private Animator anim;


    IEnumerator Start()
    {
        Cursor.visible = false;
        main.MoveStop();
        yield return new WaitForSecondsRealtime(4f);
        characterMovement.enabled = true;
        anim.enabled = true;
        main.MoveContinue();
        Destroy(secondCam);
        firstCam.SetActive(true);
        canvas.SetActive(true);
    }
}
