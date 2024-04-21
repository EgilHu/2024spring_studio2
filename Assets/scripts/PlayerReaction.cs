using UnityEngine;

public class PlayerReaction : MonoBehaviour
{
    private EnemyAttackSystem enemyAttackSystem;

    void Start()
    {
        // 获取敌人攻击系统的引用
        enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
    }

    // 当玩家按下键盘按键时被调用
    void Update()
    {
        // 检查玩家按键并调用相应的反应方法
        if (Input.GetKeyDown(KeyCode.Q))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.LeftSideAttack);
        }
        else if (Input.GetKeyDown(KeyCode.O))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack);
        }
        else if (Input.GetKeyDown(KeyCode.P))
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.RightSideAttack);
        }
        // 添加更多按键和对应的反应
    }

    // 检查玩家反应是否正确
    void CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType expectedAttackType)
    {
        // 获取当前敌人的攻击类型
        EnemyAttackSystem.EnemyAttackType actualAttackType = enemyAttackSystem.GetCurrentAttackType();

        // 判断玩家反应是否正确
        if (actualAttackType == expectedAttackType)
        {
            // 玩家反应正确，继续游戏
            Debug.Log("Continue");
        }
        else
        {
            // 玩家反应错误，游戏结束
            Debug.Log("YOU DIE");
        }
    }
}
