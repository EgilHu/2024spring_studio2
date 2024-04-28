using UnityEngine;
/*using System.Collections;*/

public class EnemyAttackSystem : MonoBehaviour
{
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
        public EnemyAttackType type;// 攻击类型
        public GameObject prefab;
        public AnimationClip animation;
    }

    public EnemyAttackMove[] enemyAttackMoves;// 保存所有攻击招式的数组

    public void SpawnEnemyAttack(EnemyAttackType type)
    {
        // 寻找对应类型的攻击招式
        EnemyAttackMove move = System.Array.Find(enemyAttackMoves, x => x.type == type);
        if (move != null)
        {
            Instantiate(move.prefab, transform.position, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("Attack type not found: " + type);
        }
    }
    
    /*public AnimatorOverrideController[] animatorOverrides; // 每种攻击对应的Animator Override Controller
    public GameObject leftSideAttackPrefab;
    public GameObject singlePalmAttackPrefab;
    public GameObject rightSideAttackPrefab;
    public GameObject middleAttackPrefab;
    public GameObject upSideAttackPrefab;
    public GameObject doublePalmAttackPrefab;
    // 添加更多攻击方式的预制体

    private Animator animator;
    private EnemyAttackType currentAttackType; // 声明当前的攻击类型变量

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            StopCoroutine("AttackRoutine"); // 停止之前的协程
            Attack(); // 开始新的攻击
        }
    }


    void Attack()
    {
        EnemyAttackType randomAttack = (EnemyAttackType)Random.Range(0, (int)EnemyAttackType.DoublePalmAttack + 1);

        switch (randomAttack)
        {
            case EnemyAttackType.LeftSideAttack:
                currentAttackType = EnemyAttackType.LeftSideAttack;
                PlayAnimation(animatorOverrides[0], leftSideAttackPrefab);
                break;
            case EnemyAttackType.SinglePalmAttack:
                currentAttackType = EnemyAttackType.SinglePalmAttack;
                PlayAnimation(animatorOverrides[1], singlePalmAttackPrefab);
                break;
            case EnemyAttackType.RightSideAttack:
                currentAttackType = EnemyAttackType.RightSideAttack;
                PlayAnimation(animatorOverrides[2], rightSideAttackPrefab);
                break;
            case EnemyAttackType.MiddleAttack:
                currentAttackType = EnemyAttackType.MiddleAttack;
                PlayAnimation(animatorOverrides[3], middleAttackPrefab);
                break;
            case EnemyAttackType.UpSideAttack:
                currentAttackType = EnemyAttackType.UpSideAttack;
                PlayAnimation(animatorOverrides[4], upSideAttackPrefab);
                break;
            case EnemyAttackType.DoublePalmAttack:
                currentAttackType = EnemyAttackType.DoublePalmAttack;
                PlayAnimation(animatorOverrides[5], doublePalmAttackPrefab);
                break;
        }

        StartCoroutine(CheckInputDuringAttack());
    }

    IEnumerator CheckInputDuringAttack()
    {
        bool inputReceived = false;
        KeyCode correctKey = GetCorrectKeyCode(currentAttackType);

        while (!inputReceived && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1f)
        {
            if (Input.GetKeyDown(correctKey))
            {
                inputReceived = true;
                CorrectDefense();
            }
            yield return null;
        }

        if (!inputReceived)
        {
            Debug.Log("YOU DIE");
        }
    }

    KeyCode GetCorrectKeyCode(EnemyAttackType attackType)
    {
        switch (attackType)
        {
            case EnemyAttackType.LeftSideAttack:
                return KeyCode.Q;
            case EnemyAttackType.SinglePalmAttack:
                return KeyCode.Space;
            case EnemyAttackType.RightSideAttack:
                return KeyCode.P;
            case EnemyAttackType.MiddleAttack:
                return KeyCode.O;
            case EnemyAttackType.UpSideAttack:
                return KeyCode.I;
            case EnemyAttackType.DoublePalmAttack:
                return KeyCode.K;
            default:
                return KeyCode.None;
        }
    }

    void PlayAnimation(AnimatorOverrideController overrideController, GameObject prefab)
    {
        animator.runtimeAnimatorController = overrideController;
        animator.SetTrigger("EnemyAttackTrigger");
        GameObject attackObject = Instantiate(prefab, transform.position, Quaternion.identity);
        AttackAnimationEvent attackEvent = attackObject.AddComponent<AttackAnimationEvent>();
        attackEvent.Initialize(this);
    }

    public void CorrectDefense()
    {
        Debug.Log("Correct Defense!");
    }*/

    public void DestroyPrefab(GameObject prefab)
    {
        Destroy(prefab);
    }

    /*public EnemyAttackType GetCurrentAttackType()
    {
        return currentAttackType;
    }*/
}
