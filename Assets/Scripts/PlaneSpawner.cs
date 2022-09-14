using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public List<GameObject> plots;
    Queue<GameObject> createdPlots = new Queue<GameObject>();
    float plotSize = 18f;
    float lastZPos = 0f;
    float xPosR = 15f;
    int startPlotAmnt = 8;



    void Start()
    {

		for (int i = 0; i < startPlotAmnt; i++)
		{
            SpawnBothPlots(1);
        }
    }


    void SpawnLeftPlot()
    {

        GameObject leftPlot = ObjectPool.instance.GetHouseInPool();

		if (leftPlot != null )
		{
            createdPlots.Enqueue(leftPlot);
            leftPlot.SetActive(true);

            leftPlot.transform.position = new Vector3(-xPosR, 0, lastZPos);
            leftPlot.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void SpawnRightPlot()
    {
        GameObject rightPlot = ObjectPool.instance.GetHouseInPool();

        if  (rightPlot != null)
        {
            createdPlots.Enqueue(rightPlot);
            rightPlot.SetActive(true);

            rightPlot.transform.position = new Vector3(xPosR, 0, lastZPos);
            rightPlot.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
    }

    public void SpawnBothPlots(int amnt)
    {
		for (int i = 0; i < amnt; i++)
		{
            SpawnLeftPlot();
            SpawnRightPlot();
            lastZPos += plotSize;
        }   
    }

    public void DestroyPlots(int amnt)
    {
		for (int i = 0; i < amnt; i++)
		{
            createdPlots.Dequeue().SetActive(false);
            createdPlots.Dequeue().SetActive(false);
        }   
    }
}
