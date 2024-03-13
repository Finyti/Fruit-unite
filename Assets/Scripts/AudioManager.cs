using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    static AudioSource source;
    void Awake()
    {
        source = GetComponent<AudioSource>();
    }


    public static void Play(AudioClip clip, float volume = 1f)
    {
        source.PlayOneShot(clip, volume);
    }
}
