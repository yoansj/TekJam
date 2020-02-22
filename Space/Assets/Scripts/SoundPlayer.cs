using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    public List<AudioClip> sounds;
    private AudioSource soundPlayer;

    public enum SOUND
    {
        JUMP = 0,
        HIT = 1
    }

    private void Start()
    {
        soundPlayer = GetComponent<AudioSource>();
    }

    public void PlaySound(int index)
    {
        soundPlayer.clip = sounds[index];
        soundPlayer.Play();
    }
}
