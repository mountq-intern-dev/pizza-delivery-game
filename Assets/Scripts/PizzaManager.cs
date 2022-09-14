using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    Stack<GameObject> pizzasOnCar = new Stack<GameObject>();
    int pizzaCount = 0;
    float pizzaLength = 0.04f;
    Transform pizzaLocation;
    public GameObject pizzaPrefab;
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
        
		if (pizzaCount > 0)
		{
            GameObject pizzaToRemove = pizzasOnCar.Pop();
            pizzaToRemove.SetActive(false);
            pizzaCount--;
            
        }
    }

    void SpawnPizza()
    {
        GameObject createdPizza = ObjectPool.instance.GetObjectInPool();
        Vector3 pizzaLoc = new Vector3(pizzaLocation.position.x, pizzaLocation.position.y + pizzaCount * pizzaLength, pizzaLocation.position.z);
        pizzasOnCar.Push(createdPizza);

        if (createdPizza != null)
		{
            createdPizza.transform.parent = pizzaLocation.transform;
            createdPizza.transform.position = pizzaLoc;
            createdPizza.SetActive(true);
		}
    }
}
