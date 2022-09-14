using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public List<GameObject> plots;
    float plotSize = 18f;
    float lastZPos = 0f;
    float xPosR = 15f;
    int startPlotAmnt = 5;



    void Start()
    {
		for (int i = 0; i < startPlotAmnt; i++)
		{
            SpawnFullPlots();
        }
    }


    void SpawnSinglePlot()
    {
        GameObject rightPlot = plots[Random.Range(0, plots.Count)];
        GameObject leftPlot = plots[Random.Range(0, plots.Count)];

        Instantiate(rightPlot, new Vector3(xPosR, 0, lastZPos), new Quaternion(0, 180, 0, 0));
        Instantiate(leftPlot, new Vector3(-xPosR, 0, lastZPos), new Quaternion(0, 0, 0, 0));


        lastZPos += plotSize;
    }

    public void SpawnFullPlots()
    {
		for (int i = 0; i < 2; i++)
		{
            SpawnSinglePlot();
        }
    }
}
