using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mowerSoundSystem : MonoBehaviour
{
    public AudioClip mowerStart;
    public AudioClip mowerRun;
    public AudioClip mowerStop;

    AudioSource src;
    MowerComponent mower;

    void Awake()
    {
        mower = gameObject.GetComponent<MowerComponent>();
        src = gameObject.GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        switch (mower.state)
        {
            case MowerComponent.State.RUNNING:
                if (!src.isPlaying)
                {
                    src.loop = true;
                    src.PlayOneShot(mowerRun,0.2f);
                }
                break;
            case MowerComponent.State.TURN_OFF:
                src.Stop();
                src.loop = false;
                src.PlayOneShot(mowerStop,0.2f);
                mower.state = MowerComponent.State.OFF;
                break;
            case MowerComponent.State.TURN_ON:
                src.Stop();
                src.loop = false;
                src.PlayOneShot(mowerStart,0.2f);
                mower.state = MowerComponent.State.RUNNING;
                break;
            default:
                break;
        }
    }




}
