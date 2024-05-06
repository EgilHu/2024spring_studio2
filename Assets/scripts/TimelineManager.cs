using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    public Dictionary<string, PlayableDirector> playableDirectors = new Dictionary<string, PlayableDirector>();

    public void AddTimeline(string name, PlayableDirector playableDirector)
    {
        if (!playableDirectors.ContainsKey(name))
        {
            playableDirectors.Add(name, playableDirector);
        }
        else
        {
            Debug.LogError("A timeline with the same name already exists.");
        }
    }

    public void PlayTimeline(string name)
    {
        if (playableDirectors.ContainsKey(name))
        {
            playableDirectors[name].Play();
        }
        else
        {
            Debug.LogError("No timeline found with the given name.");
        }
    }

    public void PauseTimeline(string name)
    {
        if (playableDirectors.ContainsKey(name))
        {
            playableDirectors[name].Pause();
        }
        else
        {
            Debug.LogError("No timeline found with the given name.");
        }
    }
}
