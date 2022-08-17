using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MusicManager : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] music;
    public bool isPlaying;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        isPlaying = false;
    }

    public IEnumerator StartMusic(int index, float waitTime)
    {
        if (music[index] != null)
        {
            isPlaying = true;
            audioSource.clip = music[index];
            yield return new WaitForSeconds(waitTime);
            audioSource.Play();
        }
    }
}
