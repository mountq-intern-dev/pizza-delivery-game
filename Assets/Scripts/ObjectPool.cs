using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
	int poolAmount = 10;
	List<GameObject> poolObjects = new List<GameObject>();

	[SerializeField] private GameObject pizzaPrefab;

	// Start is called before the first frame update
	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	private void Start()
	{
		for (int i = 0; i < poolAmount; i++)
		{
			GameObject tmp = Instantiate(pizzaPrefab);
			tmp.SetActive(false);
			poolObjects.Add(tmp);
			
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
}
