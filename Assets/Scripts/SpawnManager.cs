using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    PlaneSpawner planeSpawner;
    public List<GameObject> roadParts;

    Queue<GameObject> disabledPizzaCars = new Queue<GameObject>();
    Queue<GameObject> activePizzaCars = new Queue<GameObject>();
    public GameObject pizzaCar;
    float lastRoadZ;
    float roadLen = 36f;
    int triggerTime = 1;

	private void Start()
	{
        CreatePizzaCars();
        planeSpawner = GetComponent<PlaneSpawner>();
	}

	public void TriggerSpawns()
    {
        MovePizzaCars();
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
        lastRoadZ = lastRoadPos.z + roadLen;

        oldRoad.transform.position = lastRoadPos;
        roadParts.Add(oldRoad);
    }

    void CreatePizzaCars()
    {
		for (int i = 0; i < 6; i++)
		{
            GameObject tmp = Instantiate(pizzaCar, new Vector3(0, 0, 0), new Quaternion(0, 180, 0, 0));
            disabledPizzaCars.Enqueue(tmp);
            tmp.SetActive(false);
        }
    }

    void MovePizzaCars()
    {
        GameObject tmp;
        if (activePizzaCars.Count > 5)
        {
            tmp = activePizzaCars.Dequeue();
            disabledPizzaCars.Enqueue(tmp);
            tmp.SetActive(false);
        }

        tmp = disabledPizzaCars.Dequeue();
        activePizzaCars.Enqueue(tmp);
        tmp.transform.position = new Vector3(Random.Range(-1.8f, 1.8f), 0, lastRoadZ);
        tmp.SetActive(true);
    }

  
}
