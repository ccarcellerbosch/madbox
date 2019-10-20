using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    bool activated = false;
    [SerializeField]
    Vector3 newCameraAngle;
    private void OnTriggerEnter(Collider col)
    {
        if (!activated)
        {
            activated = true;
            GameplayManager.get.currentCamera.ChangeCameraAngle(newCameraAngle);
        }
    }
}
