using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaManager : MonoBehaviour
{
    Rigidbody pizzaAnchor;
    Stack<GameObject> pizzasOnCar = new Stack<GameObject>();
    int donePizza = 0;
    float pizzaLength = 0.04f;
    Transform pizzaLocation;
    public GameObject pizzaPrefab;
    public UIManager uIManager;
    public ParticleManager particleManager;
	void Start()
    {
        pizzaAnchor = GameObject.FindGameObjectWithTag("Anchor").GetComponent<Rigidbody>();
        pizzaLocation = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0);
    }

  
    public void GetPizza()
    {
        SpawnPizza();
        uIManager.UpdatePizza(pizzasOnCar.Count);
		if (pizzasOnCar.Count < 11)
		{
            particleManager.PizzaParticle();
        }
        
    }

    public void DeliverPizza()
    {
        
		if (pizzasOnCar.Count > 0)
		{
            donePizza++;
            GameObject pizzaToRemove = pizzasOnCar.Pop();
            pizzaToRemove.SetActive(false);
            uIManager.UpdatePizza(pizzasOnCar.Count);
            uIManager.UpdateDonePizza(donePizza);
            particleManager.DoneParticle();
            
        }
    }

    void SpawnPizza()
    {
        GameObject createdPizza = ObjectPool.instance.GetObjectInPool();
        Vector3 pizzaLoc = new Vector3(pizzaLocation.position.x, pizzaLocation.position.y + pizzasOnCar.Count * pizzaLength, pizzaLocation.position.z);
        

        if (createdPizza != null)
		{
			if (pizzasOnCar.Count == 0)
			{
                createdPizza.GetComponent<SpringJoint>().connectedBody = pizzaAnchor;

            }
			else
			{
                createdPizza.GetComponent<SpringJoint>().connectedBody = pizzasOnCar.Peek().GetComponent<Rigidbody>();

            }
            pizzasOnCar.Push(createdPizza);
            createdPizza.transform.parent = pizzaLocation.transform;    
            createdPizza.transform.position = pizzaLoc;
            createdPizza.SetActive(true);
		}
    }
}
