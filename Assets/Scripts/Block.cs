using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
   public int lvlId;
   public Transform blockEnd;

   public List<Transform> positionPoints;

    public void AddWayPoints()
    {
        for(int i = 0; i < positionPoints.Count; i++)
        {
            GameplayManager.get.allPathPositions.Add(positionPoints[i]);
        }
    }

}
