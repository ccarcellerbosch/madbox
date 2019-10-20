using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideTrap : MonoBehaviour
{
    float startZPosition;
    [SerializeField]
    float targetDir;
    [SerializeField]
    float ZDistance = 1f;
    [SerializeField]
    float speed = 0.7f;


    private void Start()
    {
        startZPosition = transform.position.z;

    }
    private void OnCollisionEnter(Collision col)
    {
        GameplayManager.get.uiManager.ShowFinalResults(false);
    }

    private void Update()
    {
        if (ZDistance > 0)
        {
            if (targetDir == 1 && (transform.position.z > startZPosition + ZDistance))
                StartCoroutine(WaitTime(-1f));
            if (targetDir == -1 && (transform.position.z < startZPosition))
                StartCoroutine(WaitTime(1f));
        }
        else
        {
            if (targetDir == 1 && (transform.position.z > startZPosition))
                StartCoroutine(WaitTime(-1f));
            if (targetDir == -1 && (transform.position.z < startZPosition + ZDistance))
                StartCoroutine(WaitTime(1f));

        }


        transform.position += Vector3.forward * targetDir * Time.deltaTime * speed;

    }

    IEnumerator WaitTime(float dir)
    {
        targetDir = 0;
        yield return new WaitForSeconds(0.5f);
        targetDir = dir;
    }
}
