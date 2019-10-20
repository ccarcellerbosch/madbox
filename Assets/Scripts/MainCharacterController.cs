using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MainCharacterController : MonoBehaviour
{
     [SerializeField]
    Vector3 startPos;
    [SerializeField]
    float characterSpeed = 3f;
    Vector3 currentDirection;

    Vector3 targetPos;
    int currPos = 0;

    void Awake()
    {
        transform.position = startPos;
        GameplayManager.get.charController = this;
        targetPos = GameplayManager.get.allPathPositions[currPos].position;
        currentDirection = (targetPos - transform.position).normalized;
        GameplayManager.get.currentCamera.SetCameraTarget(transform);
    }

    private void Update()
    {
        if (GameplayManager.get.currentState.Equals(GameState.Playing) && Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            GoToNextPosition();
        }

    }
 
    void GoToNextPosition()
    {
        transform.position += currentDirection * characterSpeed * Time.deltaTime;
    }

    public void UpdateTargetPoint()
    {
        if (currPos < GameplayManager.get.allPathPositions.Count - 1)
        {
            currPos++;
            targetPos = GameplayManager.get.allPathPositions[currPos].position;
            currentDirection = (targetPos - transform.position).normalized;
        }
    }

}
