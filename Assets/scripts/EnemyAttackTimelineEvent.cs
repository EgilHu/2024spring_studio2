using UnityEngine;

public class EnemyAttackTimelineEvent : MonoBehaviour
{
    private EnemyAttackSystem enemyAttackSystem;

    void Start()
    {
        enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
        if (enemyAttackSystem == null)
        {
            Debug.LogError("EnemyAttackSystem not found");
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
            enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.LeftSideAttack);
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
            enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.RightSideAttack);
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
            enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.MiddleAttack);
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
            enemyAttackSystem.SpawnEnemyAttack(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack);
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
    
}