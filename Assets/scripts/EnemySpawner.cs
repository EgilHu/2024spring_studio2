using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform target;
    public float spawnInterval = 2f;
    public float spawnRadius = 5f;

    private float spawnTimer; // 生成计时器

    void Update()
    {
        // 每帧更新生成计时器
        spawnTimer += Time.deltaTime;

        // 如果计时器超过了间隔时间
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f;

            Vector2 randomOffset = Random.insideUnitCircle.normalized * spawnRadius;
            Vector2 spawnPosition = (Vector2)target.position + randomOffset;

            GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

            EnemyMovement enemyMovement = enemy.GetComponent<EnemyMovement>();
            if (enemyMovement != null && target != null)
            {
                enemyMovement.SetTarget(target);
            }
        }
    }
}
