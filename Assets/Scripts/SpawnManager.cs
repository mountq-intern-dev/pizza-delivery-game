using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> roadParts;
    float roadLen = 36f;

    public void MoveRoad()
    {
       
        GameObject oldRoad = roadParts[0];
        roadParts.Remove(oldRoad);

        Vector3 lastRoadPos = roadParts[roadParts.Count -1].transform.position;
        lastRoadPos = new Vector3(0, 0, lastRoadPos.z + roadLen);

        oldRoad.transform.position = lastRoadPos;
        roadParts.Add(oldRoad);
    }
}
