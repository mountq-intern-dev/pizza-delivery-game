using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaCarMovement : MonoBehaviour
{
    float verticalSpeed = 3f;

    // Update is called once per frame
    void Update()
    {

        transform.Translate(new Vector3(0,0,verticalSpeed) * Time.deltaTime);
    }
}
