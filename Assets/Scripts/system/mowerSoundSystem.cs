using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mowerSoundSystem : MonoBehaviour
{
    public AudioClip mowerStart;
    public AudioClip mowerRun;
    public AudioClip mowerStop;

    AudioSource start;
    AudioSource run;
    AudioSource stop;

    MowerComponent mower;

    void Awake()
    {
        mower = gameObject.GetComponent<MowerComponent>();
        if(mower == null)
        {
            Debug.Log("wtf");
        }
    }

    void Start()
    {
        start = new AudioSource();
        run = new AudioSource();
        stop = new AudioSource();


        if (start == null)
        {
            Debug.LogError("start == null");
        }
        if (run == null)
        {
            Debug.LogError("run == null");
        }
        if (stop == null)
        {
            Debug.LogError("stop == null");
        }
        start.clip = mowerStart;
        run.clip = mowerRun;
        run.loop = true;
        stop.clip = mowerStop;
    }

    void FixedUpdate()
    {
        switch (mower.state)
        {
            case MowerComponent.State.RUNNING:
                if (!run.isPlaying)
                {
                    run.Play();
                }
                break;
            case MowerComponent.State.TURN_OFF:
                if (!stop.isPlaying)
                {
                    turnOffRunning();
                    stop.Play();
                    mower.state = MowerComponent.State.OFF;
                }
                break;
            case MowerComponent.State.TURN_ON:
                if (!start.isPlaying)
                {
                    start.Play();
                    mower.state = MowerComponent.State.RUNNING;
                }
                break;
            default:
                break;
        }
    }

    void turnOffRunning()
    {
        if (start.isPlaying)
        {
            start.Stop();
        }
        if (run.isPlaying)
        {
            run.Stop();
        }
        if (stop.isPlaying)
        {
            stop.Stop();
        }
    }
}
