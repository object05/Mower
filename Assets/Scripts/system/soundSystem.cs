using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class soundSystem : MonoBehaviour
{
    public AudioClip damage;
    public AudioClip pick;

    AudioSource src;
    // Start is called before the first frame update
    void Awake()
    {
        src = gameObject.GetComponent<AudioSource>();
    }

    public void playDamage()
    {
        src.PlayOneShot(damage,0.1f);
    }
    public void playPick()
    {
        src.PlayOneShot(pick,1f);
    }
}
