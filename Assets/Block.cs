using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameManager gMan;

    [SerializeField] List<Transform> points;

    Vector2 blockPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();

        blockPos = new Vector2(transform.position.x, transform.position.z);

        gMan.currentBlockWasSet += CheckPos;
    }

    void CheckPos(Vector2 currentPos)
    {
        if (currentPos == blockPos)
            GenerateBlocks();

        if (Mathf.Abs((currentPos - blockPos).magnitude) != 20 && currentPos != blockPos)
            Destroy(gameObject); 
    }

    void GenerateBlocks()
    {
/*        foreach(Transform point in points)
            Instantiate(testBlock, point.position, point.rotation);*/
    }

    private void OnDestroy()
    {
        gMan.currentBlockWasSet -= CheckPos;
    }
}
