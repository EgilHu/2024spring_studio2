using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    // 用于手动添加Timeline游戏物体的列表
    public List<PlayableDirector> timelineDirectors = new List<PlayableDirector>();

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
    
    public void PauseAndPlayFromTime(int index, double time)
    {
        if (index >= 0 && index < timelineDirectors.Count)
        {
            timelineDirectors[index].Pause(); // 暂停当前的timeline
            timelineDirectors[index].playableGraph.GetRootPlayable(0).SetTime(time); // 将时间指针设置到指定的时间点
            timelineDirectors[index].Evaluate(); // 更新PlayableDirector的状态
            timelineDirectors[index].Play(); // 从指定的时间点开始播放
        }
        else
        {
            Debug.LogError("Invalid timeline index.");
        }
    }
}