using System;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.Collections.Generic;

public class PlayerReaction : MonoBehaviour
{
    private DebugHandLandMarks _debugHandLandMarks;
    [SerializeField] private AudioManager audioManager;

    public GameObject currentTutorialPrefab;

    void Start()
    {
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
    }

    public Coroutine counterAttackCoroutine;
    public void ReactToSignal(EnemyAttackSystem.EnemyAttackType type)
    {
        if (!reactionStatus.ContainsKey(type))
        {
            reactionStatus[type] = false; // 初始化反应状态
        }

        switch (type)
        {
            case EnemyAttackSystem.EnemyAttackType.LeftSideAttack:
            case EnemyAttackSystem.EnemyAttackType.RightSideAttack:
            case EnemyAttackSystem.EnemyAttackType.MiddleAttack:
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack:
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttackLeft:
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttackRight:
            case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack:
            case EnemyAttackSystem.EnemyAttackType.UpSideAttack:
            case EnemyAttackSystem.EnemyAttackType.UpSideAttackLeft:
            case EnemyAttackSystem.EnemyAttackType.UpSideAttackRight:
                counterAttackCoroutine = StartCoroutine(CounterAttack(type));
                break;
            default:
                Debug.LogWarning("Unhandled attack type: " + type);
                break;
        }
    }

    // 使用字典来记录每种攻击类型的反应状态
    private Dictionary<EnemyAttackSystem.EnemyAttackType, bool> reactionStatus = new Dictionary<EnemyAttackSystem.EnemyAttackType, bool>();

    public GameObject playerAttackVFX;
    public bool successfulReaction = false;
    public System.Collections.IEnumerator CounterAttack(EnemyAttackSystem.EnemyAttackType type)
    {
        while (true)
        {
            if (GetCorrectReactionTypeForAttack(type))
            {
                reactionStatus[type] = true;
                successfulReaction = true;
                Debug.Log("Successful counterattack!");
                Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
                if (currentTutorialPrefab != null)
                {
                    Destroy(currentTutorialPrefab);
                    currentTutorialPrefab = null;
                }
                PlayAttackAudio(type);
                break;
            }
            reactionStatus[type] = false;
            successfulReaction = false;
            yield return null;
        }
    }

    private void PlayAttackAudio(EnemyAttackSystem.EnemyAttackType type)
    {
        switch (type)
        {
            case EnemyAttackSystem.EnemyAttackType.LeftSideAttack:
                audioManager.PlayAudio("left", 0.5f);
                break;
            case EnemyAttackSystem.EnemyAttackType.RightSideAttack:
                audioManager.PlayAudio("right", 0.5f);
                break;
            case EnemyAttackSystem.EnemyAttackType.MiddleAttack:
                audioManager.PlayAudio("fist", 0.8f);
                break;
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttack:
                audioManager.PlayAudio("palm1", 1f);
                break;
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttackLeft:
                audioManager.PlayAudio("palm1", 1f);
                break;
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttackRight:
                audioManager.PlayAudio("palm1", 1f);
                break;
            case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack:
                audioManager.PlayAudio("palm2", 1f);
                break;
            case EnemyAttackSystem.EnemyAttackType.UpSideAttack:
                audioManager.PlayAudio("down palm", 1f);
                break;
            case EnemyAttackSystem.EnemyAttackType.UpSideAttackLeft:
                audioManager.PlayAudio("down palm", 1f);
                break;
            case EnemyAttackSystem.EnemyAttackType.UpSideAttackRight:
                audioManager.PlayAudio("down palm", 1f);
                break;
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
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttackLeft:
                return _debugHandLandMarks.DetectSinglePalmAttack();
            case EnemyAttackSystem.EnemyAttackType.SinglePalmAttackRight:
                return _debugHandLandMarks.DetectSinglePalmAttack();
            case EnemyAttackSystem.EnemyAttackType.DoublePalmAttack:
                return _debugHandLandMarks.DetectDoublePalmAttack();
            case EnemyAttackSystem.EnemyAttackType.UpSideAttack:
                return _debugHandLandMarks.DetectPalmDownAttack();
            case EnemyAttackSystem.EnemyAttackType.UpSideAttackLeft:
                return _debugHandLandMarks.DetectPalmDownAttack();
            case EnemyAttackSystem.EnemyAttackType.UpSideAttackRight:
                return _debugHandLandMarks.DetectPalmDownAttack();
            default:
                return false;
        }
    }

    public bool IsReactionSuccessful(EnemyAttackSystem.EnemyAttackType type)
    {
        return reactionStatus.ContainsKey(type) && reactionStatus[type];
    }
}
