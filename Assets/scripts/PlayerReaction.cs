using System;
using UnityEditor.SceneManagement;
using UnityEngine;

public class PlayerReaction : MonoBehaviour
{
    private DebugHandLandMarks _debugHandLandMarks;
    [SerializeField] private AudioManager audioManager;
    
    public GameObject currentTutorialPrefab;
    void Start()
    { 
        //enemyAttackSystem = FindObjectOfType<EnemyAttackSystem>();
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
        /*audioManager = FindObjectOfType<AudioManager>();*/

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
        while (true)
        {
            if (GetCorrectReactionTypeForAttack(type))
            {
                successfulReaction = true;
                Debug.Log("Successful counterattack!");
                //audioManager.PlayAudio("punch");
                Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
                if (currentTutorialPrefab != null)
                {
                    Destroy(currentTutorialPrefab);
                    currentTutorialPrefab = null;
                }
                switch (type)
                {
                    case EnemyAttackSystem.EnemyAttackType.LeftSideAttack :
                        audioManager.PlayAudio("left", 0.5f);
                        break;
                    case EnemyAttackSystem.EnemyAttackType.RightSideAttack :
                        audioManager.PlayAudio("right",0.5f);
                        break;
                    case EnemyAttackSystem.EnemyAttackType.MiddleAttack :
                        audioManager.PlayAudio("fist",0.5f);
                        Debug.Log("Fist sound played!");
                        break;
                    case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack :
                        audioManager.PlayAudio("palm",0.5f);
                        break;
                    /*case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack :
                        audioManager.PlayAudio("doublePalm");
                        break;
                    case EnemyAttackSystem.EnemyAttackType.UpSideAttack :
                        audioManager.PlayAudio("up");
                        break;*/
                }
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
    
    public bool GetCorrectReactionTypeForAttack(EnemyAttackSystem.EnemyAttackType type)
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