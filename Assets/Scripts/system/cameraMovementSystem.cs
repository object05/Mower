using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovementSystem : MonoBehaviour
{
    public GameObject mower;
    DebugMode dm;

    // Start is called before the first frame update
    void Start()
    {
        dm = GameManager.instance.GetComponent<DebugMode>();
        gameObject.transform.position = new Vector3(mower.transform.position.x,
            mower.transform.position.y,gameObject.transform.position.z);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dm.detachCam)
        {
            gameObject.transform.position = new Vector3(mower.transform.position.x,
                mower.transform.position.y, gameObject.transform.position.z);
        }
    }
}
