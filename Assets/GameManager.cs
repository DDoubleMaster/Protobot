using UnityEngine;

public class GameManager : MonoBehaviour
{
    Vector2 currentBlock;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SetCurrentBlock(Vector2.zero);

        InvokeRepeating("RandomSetCurrentBlock", 5, 5);
    }

    void RandomSetCurrentBlock()
    {
        Vector3 tempDir;
        switch(Random.Range(1, 3))
        {
            case 1: tempDir = gameObject.transform.right * -1 * 20; break;
            case 2: tempDir = gameObject.transform.forward * -1 * 20; break;
            case 3: tempDir = gameObject.transform.right * 20; break;
            default: tempDir = gameObject.transform.forward * -1 * 20; break;
        }
        Debug.Log(currentBlock + new Vector2(tempDir.x, tempDir.z));
        SetCurrentBlock(currentBlock + new Vector2(tempDir.x, tempDir.z));
    }

    public delegate void BlockSet(Vector2 blockPose); 
    public event BlockSet currentBlockWasSet;
    public void SetCurrentBlock(Vector2 blockPose)
    {
        currentBlock = blockPose;
        currentBlockWasSet?.Invoke(currentBlock);
    }
}
