using UnityEngine;

public class PlayerReaction : MonoBehaviour
{
    private EnemyAttackSystem enemyAttackSystem;

    void Start()
    {
        enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
    }

    void Update()
    {
        // 检查玩家按键并调用相应的反应方法
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.LeftSideAttack);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.RightSideAttack);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.MiddleAttack);
        }
        else if(Input.GetKeyDown(KeyCode.I))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.UpSideAttack);
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack);
        }
        // 添加更多按键和对应的反应
    }

    void CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType expectedAttackType)
    {
        EnemyAttackSystem.EnemyAttackType actualAttackType = enemyAttackSystem.GetCurrentAttackType();

        if (actualAttackType == expectedAttackType)
        {
            enemyAttackSystem.CorrectDefense();
        }
        else
        {
            Debug.Log("YOU DIE");
        }
    }

}
