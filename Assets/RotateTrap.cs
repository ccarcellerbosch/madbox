using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrap : MonoBehaviour
{

    void Update()
    {
        transform.Rotate(Vector3.up * 100f * Time.deltaTime);

    }

    private void OnCollisionEnter(Collision col)
    {
        GameplayManager.get.uiManager.ShowFinalResults(false);
    }
}
