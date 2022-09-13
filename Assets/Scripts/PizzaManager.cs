using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{

    
    int pizzaCount = 0;
    float pizzaLength = 0.04f;
    GameObject lastPizza;
    GameObject createdPizza;
    Transform pizzaLocation;
    public GameObject pizzaPrefab;

	private void Awake()
	{
		
	}
	void Start()
    {
        pizzaLocation = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);

    }

  
    public void GetPizza()
    {
        SpawnPizza();
        pizzaCount++;
    }

    public void DeliverPizza()
    {
       
        lastPizza.SetActive(false);
        pizzaCount--;
    }

    void SpawnPizza()
    {
        GameObject createdPizza = ObjectPool.instance.GetObjectInPool();
        Vector3 pizzaLoc = new Vector3(pizzaLocation.position.x, pizzaLocation.position.y + pizzaCount * pizzaLength, pizzaLocation.position.z);

        if (createdPizza != null)
		{
            lastPizza = createdPizza;
            createdPizza.transform.parent = pizzaLocation.transform;
            createdPizza.transform.position = pizzaLoc;
            createdPizza.SetActive(true);
		}
    }
}
