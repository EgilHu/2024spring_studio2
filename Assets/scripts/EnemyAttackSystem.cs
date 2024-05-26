using System.Collections;
using UnityEngine;
using UnityEngine.Timeline;

public class EnemyAttackSystem : MonoBehaviour
{
    public GameObject [] tutorialPrefabs;

    private PlayerReaction playerReaction;
    private HealthSystem _healthSystem;
    private ScreenDamage _screenDamage;

    void Start()
    {
        playerReaction = FindObjectOfType<PlayerReaction>();
        _screenDamage = FindObjectOfType<ScreenDamage>();
        _healthSystem = FindObjectOfType<HealthSystem>();
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

    public IEnumerator SpawnEnemyAttack(EnemyAttackType type, float speed)
    {
        // 寻找对应类型的攻击招式
        EnemyAttackMove move = System.Array.Find(enemyAttackMoves, x => x.type == type);
        if (move != null)
        {
            GameObject attackObject = Instantiate(move.prefab, move.prefab.transform.position, move.prefab.transform.rotation);
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
                animator.speed = speed;
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
                _healthSystem.TakeDamage(1);
                _screenDamage.CurrentHealth -= 1f; 
                Debug.Log("Health has been updated: " + _healthSystem.currentHealth);
            }
            StopCoroutine(playerReaction.counterAttackCoroutine);
        }
        else
        {
            Debug.LogError("PlayerReaction is not initialized");
        }
    }
    
    public IEnumerator SpawnTutorialAttack(EnemyAttackType type, int frameCount)
    {
        // 生成指定类型的敌人攻击
        StartCoroutine(SpawnEnemyAttack(type, 1.0f));

        // 等待指定的帧数
        for (int i = 0; i < frameCount; i++)
        {
            yield return null;
        }

        // 暂停预制体的动画
        Animator animator = enemyAttackMoves[(int)type].prefab.GetComponent<Animator>();
        if (animator != null)
        {
            // 暂停动画
            Time.timeScale = 0;
            //Debug.Log("Animator disabled");
        }

        // 等待玩家的回击
        while (true)
        {
            if (playerReaction.GetCorrectReactionTypeForAttack(type))
            {
                // 玩家回击正确，恢复动画的播放
                if (animator != null)
                {
                    // 恢复动画播放
                    Time.timeScale = 1;
                    /*Debug.Log("Animator enabled");*/
                }

                // 延迟1帧
                yield return null;

                // 结束当前协程
                yield break;
            }

            yield return null;
        }
    }
    
    public void SpawnTutorialPrefab(int index)
    {
        if (index >= 0 && index < tutorialPrefabs.Length)
        {
            GameObject prefab = Instantiate(tutorialPrefabs[index], tutorialPrefabs[index].transform.position, Quaternion.identity);
            playerReaction.currentTutorialPrefab = prefab;
        }
        else
        {
            Debug.LogWarning("Tutorial prefab index out of range: " + index);
        }
    }
    
}
    
