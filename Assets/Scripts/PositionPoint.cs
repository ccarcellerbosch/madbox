using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionPoint : MonoBehaviour
{
    bool activated = false;
    private void OnTriggerEnter(Collider col)
    {
        if (!activated)
        {
            activated = true;
            GameplayManager.get.charController.UpdateTargetPoint();
        }
    }
}
