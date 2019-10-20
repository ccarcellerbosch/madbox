using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public List<LevelData> levels;
    List<Block> allBlocks;

    List<Block> currentInstantiatedBlocks;
    Vector3 instantiationPoint = Vector3.zero;

    void Awake()
    {
       LoadlevelsData();
    }

    void LoadlevelsData()
    {
        allBlocks = new List<Block>();
        currentInstantiatedBlocks = new List<Block>();
        Object[] loadedBlocks = Resources.LoadAll("Blocks", typeof(Block));
        foreach (Object obj in loadedBlocks)
        {
            allBlocks.Add((Block)obj); 
        }
    }

    void InitializeWayPoints()
    {
        foreach (Block obj in currentInstantiatedBlocks)
        {
            obj.AddWayPoints();
        }
    }

   public void LoadLevel(int lvlId)
    {
        LevelData currentDataLevel = levels[lvlId];
        foreach (int blockId in currentDataLevel.levelBlocksId)
        {
            Block newBlock = Instantiate(allBlocks.Find(x => x.lvlId.Equals(blockId)), GameplayManager.get.levelElementsContainer);
            newBlock.transform.position = instantiationPoint;
            instantiationPoint = newBlock.blockEnd.position;
            currentInstantiatedBlocks.Add(newBlock);

        }
        InitializeWayPoints();
        InstantiateGoal();
    }

    public Vector3 GetLevelEnd()
    {
        return currentInstantiatedBlocks[currentInstantiatedBlocks.Count - 1].blockEnd.transform.position;
    }

    void InstantiateGoal()
    {
        GameObject goal = Instantiate(GameplayManager.get.goalPrefab, currentInstantiatedBlocks[currentInstantiatedBlocks.Count - 1].blockEnd.transform.position, Quaternion.identity, currentInstantiatedBlocks[currentInstantiatedBlocks.Count - 1].transform);
    }


    

}
