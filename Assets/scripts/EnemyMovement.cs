using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform target;
    public float moveSpeed = 3f;

    void Update()
    {
        // 如果目标对象存在，朝向目标对象移动
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            transform.Translate(direction * moveSpeed * Time.deltaTime);
        }
    }

    // 设置目标对象
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
