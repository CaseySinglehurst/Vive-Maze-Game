using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject[] levels;
    int currentLevel;

    public Transform levelSpawnLocation; // currently the table on the left hand side

    List<GameObject> spawnedLevels = new List<GameObject>();

    public GameObject waywardBalls; // balls currently not in any maze

	// Use this for initialization
	void Start () {
        currentLevel = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public int GetCurrentLevel()
    {
        return currentLevel;
    }

    public void SpawnNewLevel()
    {
        if (levels.Length > currentLevel )
        {
            currentLevel++;
            spawnedLevels.Add(Instantiate(levels[currentLevel - 1], levelSpawnLocation.position, levelSpawnLocation.rotation));
        }
    }

    public void SpawnCurrentLevel()
    {
        spawnedLevels.Add(Instantiate(levels[currentLevel - 1], levelSpawnLocation.position, levelSpawnLocation.rotation));
    }

    public void CleanUpLevels()
    {
        foreach (GameObject g in spawnedLevels)
        {
            Destroy(g);
        }
        spawnedLevels = new List<GameObject>();

        for (int i = 0; i < waywardBalls.transform.childCount; i++)
        {
            Destroy(waywardBalls.transform.GetChild(i).gameObject);
        }

        SpawnCurrentLevel();
    }
}
