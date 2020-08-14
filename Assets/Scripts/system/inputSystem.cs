using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inputSystem : MonoBehaviour
{
    private MovementComponent movement;

    void Start()
    {
        movement = gameObject.GetComponent<MovementComponent>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!GameManager.instance.ended)
        {
            movement.rotation = Input.GetAxis("Horizontal");
            movement.acceleration = Input.GetAxis("Vertical");
        }
        else
        {
            movement.rotation = 0;
            movement.acceleration = 0;
        }
    }
}
