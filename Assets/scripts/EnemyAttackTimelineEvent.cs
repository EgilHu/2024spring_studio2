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

    /*public void Initialize(EnemyAttackSystem system)
    {
        enemyAttackSystem = system;
    }

    public void DestroyPrefab()
    {
        enemyAttackSystem.DestroyPrefab(gameObject);
    }*/

    public void SpawnLeftSideAttack()
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
    }
    public void SpawnMiddleAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.MiddleAttack));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }

    public void SpawnSinglePalmAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnDoublePalmAttack()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    public void SpawnUpSideAttack()
    {
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.UpSideAttack);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    /*public EnemyAttackSystem.EnemyAttackType type;*/
    
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

    public void SpawnFistTutorialPrefab()
    {
        int index = 0;
        if (enemyAttackSystem != null)
        {
            enemyAttackSystem.SpawnTutorialPrefab(index);
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }

    public void SpawnTutorialSinglePalmAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack, 95));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    public void SpawnTutorialLeftSideAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.LeftSideAttack, 160));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    public void SpawnTutoriaRightSideAttack()
    {
        if (enemyAttackSystem != null)
        {
            StartCoroutine(enemyAttackSystem.SpawnTutorialAttack(EnemyAttackSystem.EnemyAttackType.RightSideAttack, 155));
        }
        else
        {
            Debug.LogError("EnemyAttackSystem is not initialized");
        }
    }
    
    public void PlayMainTimeline()
    {
        audioManager.StopAudio("tutorial part01");
        timelineManager.PauseTimeline("TutorialTimeline");
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline("MainTimeline");
        }
        else
        {
            Debug.LogError("TimelineManager is not initialized");
        }
    }
    
    public void PlayTutorialTimeline()
    {
        audioManager.PlayAudio("tutorial part01",1f);
        timelineManager.PauseTimeline("MainTimeline");
        if (timelineManager != null)
        {
            timelineManager.PlayTimeline("TutorialTimeline");
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
            audioManager.PlayAudio("tutorial part01",1f);
        }
        else
        {
            Debug.LogError("AudioManager is not initialized");
        }
    }
}