using System.Collections.Generic;
using UnityEngine;

public class Platformer : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    GameObject[] templatePlatforms;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        templatePlatforms = Resources.LoadAll<GameObject>("Platforms/");
    }

    public List<Platformer> GenerateBlocks()
    {
        List<Platformer> oneLevelPlatforms = new List<Platformer>();
        foreach (Transform point in points)
        {
            int platformIndex = Random.Range(0, templatePlatforms.Length);
            oneLevelPlatforms.Add(Instantiate(templatePlatforms[platformIndex], point.position, point.rotation).GetComponent<Platformer>());
        }
        return oneLevelPlatforms;
    }
}
