using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    int pizzaCount = 0;
    float pizzaLength = 0.04f;
    GameObject lastPizza;
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
        Destroy(lastPizza);
        pizzaCount--;
    }

    void SpawnPizza()
    {
        Vector3 pizzaLoc = new Vector3(pizzaLocation.position.x, pizzaLocation.position.y + pizzaCount * pizzaLength, pizzaLocation.position.z);
        lastPizza = Instantiate(pizzaPrefab, pizzaLoc, pizzaPrefab.transform.rotation, pizzaLocation);
    }
}
