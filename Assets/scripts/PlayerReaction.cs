using System;
using UnityEditor.SceneManagement;
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
    private AudioManager audioManager;
    void Start()
    { 
        //enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
        audioManager = FindObjectOfType<AudioManager>();
    }
    
    public Coroutine counterAttackCoroutine;
    public void ReactToSignal(EnemyAttackSystem.EnemyAttackType type)
    {
        switch (type)
        {
            case EnemyAttackSystem.EnemyAttackType.LeftSideAttack :
            case EnemyAttackSystem.EnemyAttackType.RightSideAttack :
            case EnemyAttackSystem.EnemyAttackType.MiddleAttack :
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack :
            case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack :
            case EnemyAttackSystem.EnemyAttackType.UpSideAttack :
                counterAttackCoroutine = StartCoroutine(CounterAttack(type));
                break;
            default:
                Debug.LogWarning("Unhandled attack type: " + type);
                break;
        }
    }
    
    public bool successfulReaction = false;
    public GameObject playerAttackVFX;
    public System.Collections.IEnumerator CounterAttack(EnemyAttackSystem.EnemyAttackType type)
    {
        //bool perfectReaction = false;
        
        // KeyCode keyCode = GetCorrectReactionTypeForAttack(type);
        // 检查玩家是否在此期间做出正确输入
        while (true)
        {
            if (GetCorrectReactionTypeForAttack(type))
            {
                successfulReaction = true;
                Debug.Log("Successful counterattack!");
                audioManager.PlayAudio("punch");
                Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
                break;
            }
            successfulReaction = false;
            yield return null;
        }
        
        if (!successfulReaction)
        {
            Debug.Log("YOU DIE");
        } 
    }
    
    // private KeyCode GetCorrectReactionTypeForAttack(EnemyAttackSystem.EnemyAttackType type)
    // {
    //     switch (type)
    //     {
    //         case EnemyAttackSystem.EnemyAttackType.LeftSideAttack:
    //             return KeyCode.Q;
    //         case EnemyAttackSystem.EnemyAttackType.RightSideAttack:
    //             return KeyCode.P;
    //         case EnemyAttackSystem.EnemyAttackType.MiddleAttack:
    //             return KeyCode.I;
    //         case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack:
    //             return KeyCode.Space;
    //         case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack:
    //             return KeyCode.B;
    //         case EnemyAttackSystem.EnemyAttackType.UpSideAttack:
    //             return KeyCode.O;
    //         default:
    //             return KeyCode.None;
    //     }
    // }
    
    private bool GetCorrectReactionTypeForAttack(EnemyAttackSystem.EnemyAttackType type)
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
                return false;
        }
    }
}