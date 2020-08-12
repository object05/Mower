using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class collisionSystem : MonoBehaviour
{
    Tilemap obstacles;

    void Start()
    {
        obstacles = gameObject.GetComponent<Tilemap>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Hit");
    }

}
