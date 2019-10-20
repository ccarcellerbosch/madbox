using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownTrap : MonoBehaviour
{
    float startYPosition;
    [SerializeField]
    float targetDir;
    [SerializeField]
    float YDistance = 1f;
    [SerializeField]
    float speed = 0.7f;


    private void Start()
    {
        startYPosition = transform.position.y;
       
    }
    private void OnCollisionEnter(Collision col)
    {
        GameplayManager.get.uiManager.ShowFinalResults(false);
    }

    private void Update()
    {
        if (YDistance > 0)
        {
            if (targetDir == 1 && (transform.position.y > startYPosition + YDistance))
                StartCoroutine(WaitTime(-1f));
            if (targetDir == -1 && (transform.position.y < startYPosition))
                StartCoroutine(WaitTime(1f));
        }
        else
        {
            if (targetDir == 1 && (transform.position.y > startYPosition))
                StartCoroutine(WaitTime(-1f));
            if (targetDir == -1 && (transform.position.y < startYPosition + YDistance))
                StartCoroutine(WaitTime(1f));

        }


        transform.position += Vector3.up * targetDir * Time.deltaTime * speed;
        
    }

    IEnumerator WaitTime(float dir)
    {
        targetDir = 0;
        yield return new WaitForSeconds(1f);
        targetDir = dir;
    }

}
