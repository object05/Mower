using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementSystem : MonoBehaviour
{
    public GameObject mower;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = new Vector3(mower.transform.position.x,
            mower.transform.position.y,gameObject.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.position = new Vector3(mower.transform.position.x,
            mower.transform.position.y, gameObject.transform.position.z);
    }
}
