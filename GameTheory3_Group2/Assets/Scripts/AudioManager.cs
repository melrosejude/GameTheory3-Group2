using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance = null;

    public AudioSource sfxSource;

    public AudioClip canonFire;
    public AudioClip buttonClick;
    public AudioClip ballHitGround;
    public AudioClip sparkleSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
    }

    public void playCanonFire()
    {
        Debug.Log("Playing sound");
        sfxSource.PlayOneShot(canonFire, 0.045f);
       
    }

    public void playButtonClick()
    {
        sfxSource.PlayOneShot(buttonClick, 0.2f);
    }

    public void playHitGround()
    {
        sfxSource.PlayOneShot(ballHitGround, 0.25f);
    }

    public void playSparkle()
    {
        sfxSource.PlayOneShot(sparkleSound, 0.5f);
    }
}
