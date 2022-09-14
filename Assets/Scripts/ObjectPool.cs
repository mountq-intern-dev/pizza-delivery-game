using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
	PlaneSpawner planeSpawner;
    public static ObjectPool instance;

	int pizzaAmount = 10;
	List<GameObject> poolObjects = new List<GameObject>();

	int houseAmount = 5;
	List<GameObject> housePool = new List<GameObject>();


	

	[SerializeField] private GameObject pizzaPrefab;

	// Start is called before the first frame update
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}

		for (int i = 0; i < pizzaAmount; i++)
		{
			GameObject tmp = Instantiate(pizzaPrefab);
			tmp.SetActive(false);
			poolObjects.Add(tmp);
		}

		planeSpawner = GetComponent<PlaneSpawner>();

		for (int i = 0; i < planeSpawner.plots.Count; i++)
		{
			for (int m = 0; m < houseAmount; m++)
			{
				GameObject tmp = Instantiate(planeSpawner.plots[i]);
				tmp.SetActive(false);
				housePool.Add(tmp);
			}
		}

		RandomizeList();
	}

	private void Start()
	{
		
	}

	void RandomizeList()
	{
		for (int i = 0; i < housePool.Count; i++)
		{
			GameObject tmp = housePool[i];
			int rand = Random.Range(i, housePool.Count);
			housePool[i] = housePool[rand];
			housePool[rand] = tmp;
		}
	}


	public GameObject GetObjectInPool()
	{
		
		for (int i = 0; i < poolObjects.Count; i++)
		{
			if (!poolObjects[i].activeInHierarchy)
			{
				return poolObjects[i];
			}
		}

		return null;
	}

	

	public GameObject GetHouseInPool()
	{
		for (int i = 0; i < housePool.Count; i++)
		{
			if (!housePool[i].activeInHierarchy)
			{
				return housePool[i];
			}
		}

		return null;
	}
}
