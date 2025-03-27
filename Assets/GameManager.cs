using UnityEngine;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    Platformer levelTwo;
    List<Platformer> levelOne = new List<Platformer>();
    
    public void SetCurrentPlatform(Platformer nextPlatform)
    {
        if (levelTwo != null && levelTwo == nextPlatform)
            return;

        if (levelOne.Count != 0)
            foreach (Platformer platform in levelOne)
            {
                if (platform != nextPlatform)
                    Destroy(platform.gameObject);
            }

        levelOne.Clear();

        if (levelTwo != null)
            levelOne.Add(levelTwo);

        levelTwo = nextPlatform;
        levelOne.AddRange(levelTwo.GenerateBlocks());
        
    }
}
