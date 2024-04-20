using UnityEngine;

public class AttackAnimationEvent : MonoBehaviour
{
    private EnemyAttackSystem enemyAttackSystem;

    public void Initialize(EnemyAttackSystem system)
    {
        enemyAttackSystem = system;
    }

    public void DestroyPrefab()
    {
        enemyAttackSystem.DestroyPrefab(gameObject);
    }
}
