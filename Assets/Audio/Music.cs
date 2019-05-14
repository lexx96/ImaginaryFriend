﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Music
{
    public string name;

    public AudioClip clip;

    [Range(0,1f)]
    public float volume;
    [Range(.1f,3f)]
    public float pitch;

    public bool loop;

    public AudioSource audiosource;
    [Range(-1, 1f)]
    public float panStereo;
}
