using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject attackPrefab;
    public float spawnRate = 2.0f;
    private float timer = 0f;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnRate)
        {
            SpawnAttack();
            // 生成圆形之后重置计时器
            timer = 0f;
        }
    }

    void SpawnAttack()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0);
        Instantiate(attackPrefab, spawnPosition, Quaternion.identity);
    }
}
