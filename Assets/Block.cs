using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    GameManager gMan;

    [SerializeField] List<Transform> points;
    GameObject[] platforms;

    Vector2 blockPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gMan = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gMan.currentBlockWasSet += CheckPos;

        blockPos = new Vector2(transform.position.x, transform.position.z);

        platforms = Resources.LoadAll<GameObject>("Platforms/");
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
        foreach (Transform point in points)
        {
            int platformIndex = Random.Range(0, platforms.Length);
            Instantiate(platforms[platformIndex], point.position, point.rotation);
        }
    }

    private void OnDestroy()
    {
        gMan.currentBlockWasSet -= CheckPos;
    }
}
