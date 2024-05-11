using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyAttackSystem : MonoBehaviour
{
    private PlayerReaction playerReaction;

    void Start()
    {
        playerReaction = FindObjectOfType<PlayerReaction>();
    }

    public enum EnemyAttackType
    {
        LeftSideAttack,
        RightSideAttack,
        MiddleAttack,
        SinglePalmAttack,
        DoublePalmAttack,
        UpSideAttack,
    }

    /*招式类*/
    [System.Serializable]
    public class EnemyAttackMove
    {
        public EnemyAttackType type; // 攻击类型
        public GameObject prefab;
        public AnimationClip animation;
    }

    public EnemyAttackMove[] enemyAttackMoves; // 保存所有攻击招式的数组

    public IEnumerator SpawnEnemyAttack(EnemyAttackType type)
    {
        // 寻找对应类型的攻击招式
        EnemyAttackMove move = System.Array.Find(enemyAttackMoves, x => x.type == type);
        if (move != null)
        {
            GameObject attackObject = Instantiate(move.prefab, transform.position, Quaternion.identity);
            Renderer renderer = attackObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false; // 设置为不可见
            }
            Animator animator = attackObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false; // 停止动画
            }
            yield return null; // 等待下一帧
            yield return new WaitForSeconds(0.1f); // 添加一个小的延迟
            if (renderer != null)
            {
                renderer.enabled = true; // 设置为可见
            }
            if (animator != null)
            {
                animator.enabled = true; // 开始播放动画
            }
            playerReaction.ReactToSignal(type);
        }
        else
        {
            Debug.LogWarning("Attack type not found: " + type);
        }
    }
    
    public void DestroyPrefab(GameObject prefab)
    {
        Destroy(prefab);
    }

    public void StopCounterAttack()
    {
        if (playerReaction != null)
        {

            if (!playerReaction.successfulReaction)
            {
                Debug.Log("YOU DIE");
            }
            StopCoroutine(playerReaction.counterAttackCoroutine);

        }
        else
        {
            Debug.LogError("PlayerReaction is not initialized");
        }
    }
}
    
