using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class collisionSystem : MonoBehaviour
{
    soundSystem ss;
    GameManager gm;

    void Start()
    {
        ss = gameObject.GetComponent<soundSystem>();
        gm = GameManager.instance;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!GameManager.instance.ended)
        {
            if (other.tag == "Grass")
            {
                //Destroy(other.gameObject);
                other.gameObject.SetActive(false);
                gm.incScore();
                ss.playPick();
            }
            else if (other.tag == "Obstacle")
            {
                Debug.Log("Obstacle");
                gm.damage();
                ss.playDamage();
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Obstacle" && !gm.ended)
        {
            Debug.Log("Obstacle");
            gm.damage();
            ss.playDamage();
        }
    }
}
