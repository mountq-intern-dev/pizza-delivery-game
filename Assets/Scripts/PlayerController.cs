using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
     public SpawnManager spawnManager;
     float moveSpeed = 7f;
     float runSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xMovement = Input.GetAxis("Horizontal");
        transform.Translate(new Vector3(xMovement * moveSpeed, 0, runSpeed) * Time.deltaTime);
    }

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("SpawnTrigger"))
		{
            spawnManager.MoveRoad();
		}
	}
}
