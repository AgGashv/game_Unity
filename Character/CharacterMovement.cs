using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private Transform CameraTransform;

    [SerializeField] public Vector3 rotationDirection;
    [SerializeField] public Vector3 moveDirection;


    [SerializeField] private Animator anim;

    [SerializeField] public float horizontal;
    [SerializeField] public float vertical;
    [SerializeField] public float moveAmount;


    [SerializeField] private float rotationSpeed;

    void Update() => MoveUpdate();



    public void MoveUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveAmount = Mathf.Clamp01(Mathf.Abs(vertical) + Mathf.Abs(horizontal));


        Vector3 moveDir = CameraTransform.forward * vertical;
        moveDir += CameraTransform.right * horizontal;
        moveDir.Normalize();
        rotationDirection = CameraTransform.forward;
        moveDirection = moveDir;


        RotationNormal();
    }




    public void RotationNormal()
    {
        rotationDirection = moveDirection;

        Vector3 targetDir = rotationDirection;
        targetDir.y = 0;

        if (targetDir == Vector3.zero)
            targetDir = transform.forward;



        Quaternion lookDir = Quaternion.LookRotation(targetDir);
        Quaternion targetRot = Quaternion.Slerp(transform.rotation, lookDir, rotationSpeed);
        transform.rotation = targetRot;

    }
}