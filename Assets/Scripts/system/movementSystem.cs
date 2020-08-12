using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movementSystem : MonoBehaviour
{
    MovementComponent m;
    Rigidbody2D rb;
    void Start()
    {
        m = gameObject.GetComponent<MovementComponent>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 speed = transform.up * (m.acceleration * m.accelerationForce);
        rb.AddForce(speed);

        float direction = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.up));
        if(m.acceleration > 0)
        {
            if(direction > 0)
            {
                rb.rotation -= m.rotation * m.rForce * (rb.velocity.magnitude / GameConfig.MAX_MOWER_R_SPEED);
            }
            else
            {
                rb.rotation += m.rotation * m.rForce * (rb.velocity.magnitude / GameConfig.MAX_MOWER_R_SPEED);
            }
        }
        float drift = Vector2.Dot(rb.velocity, rb.GetRelativeVector(Vector2.left)) * 2.0f;
        Vector2 relativeForce = Vector2.right * drift;
        rb.AddForce(rb.GetRelativeVector(relativeForce));

        if(rb.velocity.magnitude > GameConfig.MAX_MOWER_SPEED)
        {
            rb.velocity = rb.velocity.normalized * GameConfig.MAX_MOWER_SPEED;
        }

    }
}
