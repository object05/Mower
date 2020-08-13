using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MowerComponent : MonoBehaviour
{
    public enum State
    {
        OFF,TURN_ON,RUNNING,TURN_OFF
    }

    public State state;

    void Awake()
    {
        state = State.OFF;
    }
    
}
