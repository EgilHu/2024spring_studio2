using UnityEngine;

public class EnemyAttackTimelineEvent : MonoBehaviour
{
    private EnemyAttackSystem enemyAttackSystem;
    private TimelineManager timelineManager;
    private AudioManager audioManager;

    void Start()
    {
        enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
        if (enemyAttackSystem == null)
        {
            Debug.LogError("EnemyAttackSystem not found");
        }
        
        timelineManager = FindObjectOfType<TimelineManager>();
        if (timelineManager == null)
        {
            Debug.LogError("TimelineManager not found");
        }
        
        audioManager = FindObjectOfType<AudioManager>();
        if (audioManager == null)
        {
            Debug.LogError("AudioManager not found");
        }
    }
    
    /*public void SpawnLeftSideAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.LeftSideAttack));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnRightSideAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.RightSideAttack));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }*/
    public void SpawnMiddleAttack(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.MiddleAttack, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnSinglePalmAttack(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnLeftSinglePalmAttack(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttackLeft, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnRightSinglePalmAttack(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttackRight, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnDoublePalmAttack(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnUpSideAttack(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttack, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnUpSideAttackLeft(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttackLeft, speed);
        }

        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnUpSideAttackRight(float speed)
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StartEnemyAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttackRight, speed);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    
    public void StopCounterAttack()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.StopCounterAttack();
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopMiddleAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.MiddleAttack);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopSinglePalmAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopDoublePalmAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopLeftPalmAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttackLeft);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopRightPalmAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttackRight);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopLeftUpsideAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttackLeft);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void StopRightUpsideAttackCounter()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem. StopSpecificEnemyAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttackRight);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    
    //教程关中间停止动画
    public void SpawnTutorialMiddleAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.MiddleAttack, 85));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnTutorialSPalmAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack, 85));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnTutorialUSideAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttack, 85));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnTutorialDPalmAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack, 85));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    
    //教程关手势动画
    public void SpawnFistTutorialPrefab()
    {
        int index = 0;
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.SpawnTutorialFistAni(index);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpwanTutorialSPalmAni()
    {
        /*int index = 1;*/
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.SpawnTutorialSPalmAni(1);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnTutorialUSideAni()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.SpawnTutorialUSidePalmAni(2);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    
    public void PlayMainTimelineLevel01()
    {
        audioManager.StopAudio("tutorial part01");
        timelineManager.PauseTimeline(1);
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline(0);
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    public void PlayTutorialTimeline()
    {
        audioManager.PlayAudio("tutorial part01",1f);
        timelineManager.PauseTimeline(0);
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline(1);
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    public void PlayMainTimelineLevel02()
    {
        timelineManager.PauseTimeline(0);
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline(2);
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    public void PlayMainTimelineLevel03()
    {
        timelineManager.PauseTimeline(2);
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline(3);
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    public void PlayMainTimelineLevel04()
    {
        timelineManager.PauseTimeline(3);
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline(4);
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    public void PlayOutroTimeline()
    {
        timelineManager.PauseTimeline(4);
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline(5);
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    
    
    public void PlayAudio_tutorial_part01()
    {
        if (audioManager != null)
        {
            audioManager.PlayAudio("tutorial 01",0.45f);
        }
        else
        {
            Debug.LogError("AudioManager is not initialized");
        }
    }
    public void StopAudio_tutorial_part01()
    {
        if (audioManager != null)
        {
            audioManager.StopAudio("tutorial 01");
        }
        else
        {
            Debug.LogError("AudioManager is not initialized");
        }
    }
}