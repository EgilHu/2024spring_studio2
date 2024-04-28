using UnityEngine;

/*public class PlayerReaction : MonoBehaviour
{
    private EnemyAttackSystem enemyAttackSystem;
    private DebugHandLandMarks _debugHandLandMarks;
    void Start()
    {
        enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
    }

    // void Update()
    // {
    //     // 检查玩家按键并调用相应的反应方法
    //     if (Input.GetKeyDown(KeyCode.Q))
    //     {
    //         CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.LeftSideAttack);
    //     }
    //     else if (Input.GetKeyDown(KeyCode.Space))
    //     {
    //         CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack);
    //     }
    //     else if (Input.GetKeyDown(KeyCode.P))
    //     {
    //         CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.RightSideAttack);
    //     }
    //     else if (Input.GetKeyDown(KeyCode.O))
    //     {
    //         CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.MiddleAttack);
    //     }
    //     else if(Input.GetKeyDown(KeyCode.I))
    //     {
    //         CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.UpSideAttack);
    //     }
    //     else if (Input.GetKeyDown(KeyCode.K))
    //     {
    //         CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack);
    //     }
    //     // 添加更多按键和对应的反应
    // }

    void Update()
    {
        if (_debugHandLandMarks.DetectDoubleFist())
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.MiddleAttack);
        }
        else if (_debugHandLandMarks.DetectSinglePalmAttack())
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.SinglePalmAttack);
        }
        else if (_debugHandLandMarks.DetectDoublePalmAttack())
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.DoublePalmAttack);
        }
        else if (_debugHandLandMarks.DetectPalmDownAttack())
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.UpSideAttack);
        }
        else if (_debugHandLandMarks.DetectPalmRight())
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.RightSideAttack);
        }
        else if (_debugHandLandMarks.DetectPalmLeft())
        {
            CheckPlayerReaction(EnemyAttackSystem.EnemyAttackType.LeftSideAttack);
        }
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

}*/

public class PlayerReaction : MonoBehaviour
{
    private DebugHandLandMarks _debugHandLandMarks;
    void Start()
    { 
        //enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
    }
    // 在收到信号时调用的方法，根据不同的攻击类型做出不同的反应
    {
        switch (type)
        {
            case EnemyAttackSystem.EnemyAttackType.LeftSideAttack :
            case EnemyAttackSystem.EnemyAttackType.RightSideAttack :
            case EnemyAttackSystem.EnemyAttackType.MiddleAttack :
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack :
            case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack :
            case EnemyAttackSystem.EnemyAttackType.UpSideAttack :
                StartCoroutine(CounterAttack(type));
                break;
            default:
                Debug.LogWarning("Unhandled attack type: " + type);
                break;
        }
    }

    private System.Collections.IEnumerator CounterAttack(EnemyAttackSystem.EnemyAttackType type)
    {
        bool successfulReaction = false;
        bool perfectReaction = false;
        
    }
    
    private _debugHandLandMarks GetCorrectReactionTypeForAttack(EnemyAttackSystem.EnemyAttackType type)
    {
        switch (type)
        {
            case EnemyAttackSystem.EnemyAttackType.LeftSideAttack:
                return _debugHandLandMarks.DetectPalmLeft();
            case EnemyAttackSystem.EnemyAttackType.RightSideAttack:
                return _debugHandLandMarks.DetectPalmRight();
            case EnemyAttackSystem.EnemyAttackType.MiddleAttack:
                return _debugHandLandMarks.DetectDoubleFist();
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack:
                return _debugHandLandMarks.DetectSinglePalmAttack();
            case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack:
                return _debugHandLandMarks.DetectDoublePalmAttack();
            case EnemyAttackSystem.EnemyAttackType.UpSideAttack:
                return _debugHandLandMarks.DetectPalmDownAttack();
            default:
                return null;
        }
    }
}