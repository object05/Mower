using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class DebugInputSystem : MonoBehaviour
{

    DebugMode dm;

    void Start()
    {
        dm = gameObject.GetComponent<DebugMode>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            dm.toggleDebugging();
        }
    }
}
