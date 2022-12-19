using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] BlocksPrefab;
    public GameObject FirstBlocks;
    public int MinBlocks;
    public int MaxBlocks;
    public float DistanceBetweenBlocks;
    public Transform FinishTrigger;
    public Transform PlaneRoot;
    public Game Game;

    private void Awake()
    {
        int blocksCount = Random.Range(MinBlocks, MaxBlocks + 1);   

        for (int i = 0; i < blocksCount; i++)
        {
            int prefabIndex = Random.Range(0, BlocksPrefab.Length);
            GameObject blocksPrefab = i == 0 ? FirstBlocks : BlocksPrefab[prefabIndex];
            GameObject blocks = Instantiate(blocksPrefab, transform);
            blocks.transform.localPosition = CalculateBlockPosition(i);
        }
        FinishTrigger.localPosition = CalculateBlockPosition(blocksCount);

        PlaneRoot.localScale = new Vector3(1, 1, blocksCount * DistanceBetweenBlocks);

         Vector3 CalculateBlockPosition(int blockIndex)
        {
            return new Vector3(0, 0, DistanceBetweenBlocks * blockIndex);
        }
    }
}
