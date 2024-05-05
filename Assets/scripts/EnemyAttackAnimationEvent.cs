using UnityEngine;

public class EnemyAttackAnimationEvent : MonoBehaviour
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

    public void Initialize(EnemyAttackSystem system)
    {
        enemyAttackSystem = system;
    }

    public void DestroyPrefab()
    {
        enemyAttackSystem.DestroyPrefab(gameObject);
    }
}
