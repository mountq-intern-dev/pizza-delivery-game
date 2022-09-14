using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    PlaneSpawner planeSpawner;
    public List<GameObject> roadParts;
    float roadLen = 36f;
    int triggerTime = 1;

	private void Start()
	{
        planeSpawner = GetComponent<PlaneSpawner>();
	}

	public void TriggerSpawns()
    {
        MoveRoad();
        planeSpawner.SpawnBothPlots(2);
        triggerTime++;
		if (triggerTime > 3)
		{
            
            planeSpawner.DestroyPlots(2);
		}
        

    }
    private void MoveRoad()
    {
       
        GameObject oldRoad = roadParts[0];
        roadParts.Remove(oldRoad);

        Vector3 lastRoadPos = roadParts[roadParts.Count -1].transform.position;
        lastRoadPos = new Vector3(0, 0, lastRoadPos.z + roadLen);

        oldRoad.transform.position = lastRoadPos;
        roadParts.Add(oldRoad);
    }
}
