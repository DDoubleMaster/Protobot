using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    GameManager gMan;

    [SerializeField] List<Transform> points;
    GameObject[] platforms;

    Vector2 blockPos;
    bool isCurrentPlatform = false;

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
        Debug.Log($"{gameObject.name}, {currentPos} and {Mathf.Abs((currentPos - blockPos).magnitude)}");

        if (currentPos == blockPos && isCurrentPlatform != true)
        {
            isCurrentPlatform = true;
            GenerateBlocks();
        }

        if (Mathf.Abs((currentPos - blockPos).magnitude) == 20)
            isCurrentPlatform = false;
            

        if (Mathf.Abs((currentPos - blockPos).magnitude) != 20 && currentPos != blockPos)
        {
            isCurrentPlatform = false;
            Destroy(gameObject);
        }
    }

    void GenerateBlocks()
    {
        foreach (Transform point in points)
        {
            int platformIndex = Random.Range(0, platforms.Length);
            GameObject currentPlatform = Instantiate(platforms[platformIndex], point.position, point.rotation);
            Vector3 pos = currentPlatform.transform.position;
            currentPlatform.name = $"Platform {pos.x} | {pos.z}";
        }
    }

    private void OnDestroy()
    {
        gMan.currentBlockWasSet -= CheckPos;
    }
}
