using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsingCamera : MonoBehaviour
{
    [SerializeField] private Transform camTrans;
    [SerializeField] private Transform pivot;
    [SerializeField] private Transform Character;
    [SerializeField] private Transform mTransform;

    [SerializeField] private CharacterStatus characterStatus;
    [SerializeField] private CameraConfig cameraConfig;



    [SerializeField] private float delta;
    [SerializeField] private float mouseX;
    [SerializeField] private float mouseY;
    [SerializeField] private float smoothX;
    [SerializeField] private float smoothY;
    [SerializeField] private float smoothXVelocity;
    [SerializeField] private float smoothYVelocity;
    [SerializeField] private float lookAngle;
    [SerializeField] private float titlAngle;



    void Update() => FixedTick();



    void FixedTick()
    {
        delta = Time.fixedDeltaTime;

        HandleRotation();
        HandlePosition();

        Vector3 targetPosition = Vector3.Lerp(mTransform.position, Character.position, 1);
        mTransform.position = targetPosition;
    }


    void HandlePosition()
    {
        float targetX = cameraConfig.normalX;
        float targetY = cameraConfig.normalY;
        float targetZ = cameraConfig.normalZ;

        Vector3 newPivotPosition = pivot.localPosition;
        newPivotPosition.x = targetX;
        newPivotPosition.y = targetY;

        Vector3 newCameraPosition = camTrans.localPosition;
        newCameraPosition.z = targetZ;


        float t = delta * cameraConfig.pivotSpeed;
        pivot.localPosition = Vector3.Lerp(pivot.localPosition, newPivotPosition, t);
        camTrans.localPosition = Vector3.Lerp(camTrans.localPosition, newCameraPosition, t);


    }



    void HandleRotation()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        if (cameraConfig.turnSmooth > 0)
        {
            smoothX = Mathf.SmoothDamp(smoothX, mouseX, ref smoothXVelocity, cameraConfig.turnSmooth);
            smoothY = Mathf.SmoothDamp(smoothY, mouseY, ref smoothYVelocity, cameraConfig.turnSmooth);

        }
        else
        {
            smoothX = mouseX;
            smoothY = mouseY;
        }

        lookAngle += smoothX * cameraConfig.Y_rot_Speed;
        Quaternion targetRot = Quaternion.Euler(0, lookAngle, 0);
        mTransform.rotation = targetRot;

        titlAngle -= smoothY * cameraConfig.X_rot_Speed;
        titlAngle = Mathf.Clamp(titlAngle, cameraConfig.minAngle, cameraConfig.maxAngle);
        pivot.localRotation = Quaternion.Euler(titlAngle, 0, 0);
    }

}
