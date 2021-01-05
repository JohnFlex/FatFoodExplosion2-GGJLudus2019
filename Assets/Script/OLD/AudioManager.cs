using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioClip[] Music;
    public AudioClip[] Sound;
    float nexttimer;
    bool nowMus = false;
    // Start is called before the first frame update
    void Start()
    {
        nexttimer = 300;
        InvokeRepeating("PlaySound", 1f, nexttimer);
    }

    void PlaySound()
    {
        if (!nowMus)
        {
            this.GetComponent<AudioSource>().clip = Music[Random.Range(0, Music.Length - 1)];
            

        }
        else
        {
            this.GetComponent<AudioSource>().clip = Sound[Random.Range(0, Sound.Length - 1)];
        }
        nexttimer = this.GetComponent<AudioSource>().clip.length ;
    }
}
