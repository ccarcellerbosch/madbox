using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform characterPos;
    float offset = 8f;
    bool rotatingCamera = false;
    Vector3 targetRotation;

    void LateUpdate()
    {
        if (characterPos != null)
            transform.position = characterPos.transform.position - transform.forward * offset;
    }

    public void SetCameraTarget(Transform targetPos)
    {
        characterPos = targetPos;
    }

    void Update()
    {
        if(characterPos != null)
            transform.position = new Vector3(characterPos.position.x, Mathf.Max(characterPos.position.y, -10f), transform.position.z);
        if (rotatingCamera)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetRotation), Time.deltaTime * 3f);
        }
    }

    public void ChangeCameraAngle(Vector3 newCameraAngle)
    {
        rotatingCamera = true;
        targetRotation = newCameraAngle;
       // transform.rotation = Quaternion.Euler(newCameraAngle);
    }

}
