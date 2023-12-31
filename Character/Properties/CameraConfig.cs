using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Camera/Config")]
public class CameraConfig : ScriptableObject
{
    public float turnSmooth;
    public float pivotSpeed;
    public float Y_rot_Speed;
    public float X_rot_Speed;
    public float minAngle;
    public float maxAngle;
    public float normalX;
    public float normalY;
    public float normalZ;
}
