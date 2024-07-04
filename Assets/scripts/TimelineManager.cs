using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using System.Collections;

public class TimelineManager : MonoBehaviour
{
    // 用于手动添加Timeline游戏物体的列表
    public List<PlayableDirector> timelineDirectors = new List<PlayableDirector>();
    public AudioSource audioSource;
    
    private int currentPlayingIndex = -1; 
    private BlackScreen blackScreen;

    void Start()
    {
        blackScreen = FindObjectOfType<BlackScreen>();
    }
    
    // 在Inspector窗口中显示添加按钮
    [ContextMenu("Add Timeline")]
    void AddTimelineManually()
    {
        // 添加当前选择的游戏物体上的PlayableDirector组件
        PlayableDirector director = GetComponent<PlayableDirector>();
        if (director != null && !timelineDirectors.Contains(director))
        {
            timelineDirectors.Add(director);
        }
    }

    public void PlayTimeline(int index)
    {
        if (index >= 0 && index < timelineDirectors.Count)
        {
            timelineDirectors[index].Play();
            currentPlayingIndex = index;
        }
        else
        {
            Debug.LogError("Invalid timeline index.");
        }
    }

    public void PauseTimeline(int index)
    {
        if (index >= 0 && index < timelineDirectors.Count)
        {
            timelineDirectors[index].Pause();
        }
        else
        {
            Debug.LogError("Invalid timeline index.");
        }
    }

    public void StopTimeline(int index)
    {
        if (index >= 0 && index < timelineDirectors.Count)
        {
            timelineDirectors[index].Stop();
        }
        else
        {
            Debug.LogError("Invalid timeline index.");
        }
    }
    
    public void ResetTimeline()
    {
        if (currentPlayingIndex >= 0 && currentPlayingIndex < timelineDirectors.Count)
        {
            PlayableDirector director = timelineDirectors[currentPlayingIndex];
            //Debug.Log("Resetting timeline: " + director.name);
            if (director.state == PlayState.Playing && audioSource.isPlaying)
            {
                StartCoroutine(ResetTimelineCoroutine(director));
                Debug.Log("Resetting timeline: " + director.name);
            }
        }
        else
        {
            Debug.LogError("No timeline is currently playing.");
        }
    }

    private IEnumerator ResetTimelineCoroutine(PlayableDirector director)
    {
        float startVolume = audioSource.volume;
        
        blackScreen.StartFadeOut();
        director.time = 0;
        
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / 3f;
            yield return null;
        }

        audioSource.Stop();
        audioSource.volume = startVolume;
        
       // yield return new WaitForSeconds(1f);

        // Reset and play the timeline
        //director.time = 0;
        director.Play();
    }
}