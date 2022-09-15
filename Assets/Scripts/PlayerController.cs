using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public SpawnManager spawnManager;
     public PizzaManager pizzaManager;
     GameObject lastShop;
     GameObject lastHome;
     float horizontalSpeed = 7f;
     float verticalSpeed = 8f;
   
    void Update()
    {
        MoveForward();
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("SpawnTrigger"))
		{
            spawnManager.TriggerSpawns();

		}

		else if (other.gameObject.CompareTag("SlowZone"))
		{
            SlowDown();
        }

        else if (other.gameObject.CompareTag("PizzaShop") && lastShop != other.gameObject)
		{
            lastShop = other.gameObject;
            pizzaManager.GetPizza();
        }

		else if (other.gameObject.CompareTag("TargetHouse") && lastHome != other.gameObject)
        {
            lastHome = other.gameObject;
            pizzaManager.DeliverPizza();
		}

    }

	private void OnTriggerExit(Collider other)
	{
        if (other.gameObject.CompareTag("SlowZone"))
        {
            Accelerate();
        }
    }

    void MoveForward()
    {
        float xMovement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(xMovement * horizontalSpeed, 0, verticalSpeed) * Time.deltaTime);
    }
    void SlowDown()
    {
        horizontalSpeed = 3.5f;
        verticalSpeed = 3.5f;
    }
    void Accelerate()
    {
        horizontalSpeed = 7f;
        verticalSpeed = 8f;
    }
}
