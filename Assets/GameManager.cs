using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector2 currentBlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCurrentBlock(Vector2.zero);
    }

    public delegate void BlockSet(Vector2 blockPose); 
    public event BlockSet currentBlockWasSet;
    public void SetCurrentBlock(Vector2 blockPose)
    {
        currentBlock = blockPose;
        currentBlockWasSet?.Invoke(currentBlock);
    }
}
