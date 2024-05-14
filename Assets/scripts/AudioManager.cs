using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioSource sfxSource;
    public AudioClip[] musicClips;
    public AudioClip[] sfxClips;
    private Dictionary<string, AudioClip> musicClipDictionary;
    private Dictionary<string, AudioClip> sfxClipDictionary;
    
    void Start()
    {
        musicClipDictionary = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in musicClips)
        {
            musicClipDictionary.Add(audioClip.name, audioClip);
        }

        sfxClipDictionary = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in sfxClips)
        {
            sfxClipDictionary.Add(audioClip.name, audioClip);
        }
    }
    
    public void PlayAudio(string audioName,float volume)
    {
        if (musicClipDictionary.ContainsKey(audioName))
        {
            musicSource.clip = musicClipDictionary[audioName];
            musicSource.volume = volume;
            musicSource.Play();
        }
        else if (sfxClipDictionary.ContainsKey(audioName))
        {
            sfxSource.clip = sfxClipDictionary[audioName];
            sfxSource.volume = volume;
            sfxSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio clip not found: " + audioName);
        }
    }
    
    public void StopAudio(string audioName)
    {
        if (musicClipDictionary.ContainsKey(audioName))
        {
            musicSource.clip = musicClipDictionary[audioName];
            musicSource.Stop();
        }
        else if (sfxClipDictionary.ContainsKey(audioName))
        {
            sfxSource.clip = sfxClipDictionary[audioName];
            sfxSource.Stop();
        }
        else
        {
            Debug.LogWarning("Audio clip not found: " + audioName);
        }
    }
}
