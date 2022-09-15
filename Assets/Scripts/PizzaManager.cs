using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    Stack<GameObject> pizzasOnCar = new Stack<GameObject>();
    int pizzaCount = 0;
    int donePizza = 0;
    float pizzaLength = 0.04f;
    Transform pizzaLocation;
    public GameObject pizzaPrefab;
    public UIManager uIManager;
    public ParticleManager particleManager;
	void Start()
    {
        pizzaLocation = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);

    }

  
    public void GetPizza()
    {
        SpawnPizza();
        pizzaCount++;
        uIManager.UpdatePizza(pizzaCount);
        particleManager.PizzaParticle();
    }

    public void DeliverPizza()
    {
        
		if (pizzaCount > 0)
		{
            donePizza++;
            GameObject pizzaToRemove = pizzasOnCar.Pop();
            pizzaToRemove.SetActive(false);
            pizzaCount--;
            uIManager.UpdatePizza(pizzaCount);
            uIManager.UpdateDonePizza(donePizza);
            particleManager.DoneParticle();
            
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
