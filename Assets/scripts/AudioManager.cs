using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    private Dictionary<string, AudioClip> audioClipDictionary;
    
    void Start()
    {
        audioClipDictionary = new Dictionary<string, AudioClip>();
        foreach (AudioClip audioClip in audioClips)
        {
            audioClipDictionary.Add(audioClip.name, audioClip);
        }
    }
    
    public void PlayAudio(string audioName)
    {
        if (audioClipDictionary.ContainsKey(audioName))
        {
            audioSource.clip = audioClipDictionary[audioName];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Audio clip not found: " + audioName);
        }
    }
}
