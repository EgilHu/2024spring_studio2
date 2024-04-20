using UnityEngine;
using System.Collections;

public class EnemyAttackSystem : MonoBehaviour
{
    public enum EnemyAttackType
    {
        LeftSideAttack,
        SinglePalmAttack,
        RightSideAttack,
        // 添加更多攻击方式
    }

    public AnimatorOverrideController[] animatorOverrides; // 每种攻击对应的Animator Override Controller
    public GameObject leftSideAttackPrefab;
    public GameObject singlePalmAttackPrefab;
    public GameObject rightSideAttackPrefab;
    // 添加更多攻击方式的预制体

    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AttackRoutine());
    }

    IEnumerator AttackRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);
            Attack();
            // Debug.Log("Attack");
        }
    }

    void Attack()
    {
        EnemyAttackType randomAttack = (EnemyAttackType)Random.Range(0, (int)EnemyAttackType.RightSideAttack + 1);

        switch (randomAttack)
        {
            case EnemyAttackType.LeftSideAttack:
                PlayAnimation(animatorOverrides[0], leftSideAttackPrefab);
                break;
            case EnemyAttackType.SinglePalmAttack:
                PlayAnimation(animatorOverrides[1], singlePalmAttackPrefab);
                break;
            case EnemyAttackType.RightSideAttack:
                PlayAnimation(animatorOverrides[2], rightSideAttackPrefab);
                break;
                // 添加更多攻击方式的case
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

    public void DestroyPrefab(GameObject prefab)
    {
        Destroy(prefab);
    }
}
