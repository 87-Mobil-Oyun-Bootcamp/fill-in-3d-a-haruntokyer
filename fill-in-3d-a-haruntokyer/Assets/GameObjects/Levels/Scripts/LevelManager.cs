using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance => instance;

    public System.Action LevelCompleted;

    [Space]
    [SerializeField]
    LevelInfoAsset levelInfoAsset;

    [Space]
    [SerializeField]
    private Transform blockContainer;

    [Space]
    [SerializeField]
    private Transform cubeContainer;

    [Space]
    [SerializeField]
    private Transform groundContainer;

    private static LevelManager instance;

    int currentLevelIndex = 0;

    BlockSpawner blockSpawner = new BlockSpawner();

    CubeSpawner cubeSpawner = new CubeSpawner();

    GroundSpawner groundSpawner = new GroundSpawner();

    List<BlockController> createdBlocks = new List<BlockController>();
    List<BlockController> filledBlocks = new List<BlockController>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }

        blockSpawner = GetComponent<BlockSpawner>();
        cubeSpawner = GetComponent<CubeSpawner>();
        groundSpawner = GetComponent<GroundSpawner>();
    }

    public bool HandleCreateNextLevel()
    {
        if(createdBlocks.Count > 0)
        {
            for (int i = 0; i < createdBlocks.Count; i++)
            {
                Destroy(createdBlocks[i]);
            }
        }

        ++currentLevelIndex;

        if (levelInfoAsset.levelInfos.Count >= currentLevelIndex)
        {
            CreateNextLevel();
            return true;
        }

        return false;
    }

    void CreateNextLevel()
    {
        blockSpawner.CreateBlockFromImage(levelInfoAsset.levelInfos[currentLevelIndex - 1], blockContainer);
        cubeSpawner.CreatBaseCube(blockSpawner, cubeContainer);
        groundSpawner.CreateGroundFromImage(levelInfoAsset.levelInfos[currentLevelIndex - 1], groundContainer);
        
    }

    public void OnBlockCreated(BlockController blockController)
    {
        createdBlocks.Add(blockController);
        Debug.Log("Collected Block Count " + filledBlocks.Count);
    }

    public void OnBlockFilled(BlockController blockController)
    {
        filledBlocks.Add(blockController);
        Debug.Log($"{filledBlocks.Count} / {createdBlocks.Count} <- Collected Block Count");

        if (filledBlocks.Count == createdBlocks.Count)
        {
            LevelCompleted?.Invoke();
        }
    }
}
