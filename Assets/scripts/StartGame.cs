using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour
{
    public float fadeDuration = 3f; // 持续时间
    public GameObject introText;
    public AudioSource audioSource;
    private float fadeTimer = 0f; // 计时器
    private bool isFading = false; // 是否正在淡出

    private SpriteRenderer spriteRenderer; // 精灵渲染器组件
    private Color originalColor; // 初始颜色
    private EnemyAttackTimelineEvent _enemyAttackTimelineEvent;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // 获取精灵渲染器组件
        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color; // 保存初始颜色
        }
        _enemyAttackTimelineEvent = FindObjectOfType<EnemyAttackTimelineEvent>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            fadeTimer += Time.deltaTime; // 增加计时器

            if (fadeTimer >= fadeDuration)
            {
                isFading = true; // 开始淡出
            }
        }
        else
        {
            fadeTimer = 0f; // 重置计时器
        }

        if (isFading)
        {
            float alpha = Mathf.Lerp(originalColor.a, 0f, (fadeTimer - fadeDuration) / fadeDuration); // 计算新的透明度
            if (spriteRenderer != null)
            {
                spriteRenderer.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha); // 设置新的颜色
            }

            audioSource.volume = Mathf.Lerp(1f, 0f, (fadeTimer - fadeDuration) / fadeDuration);
            
            if (alpha <= 0f)
            {
                isFading = false; // 停止淡出
                introText.SetActive(false); // 隐藏文本
                audioSource.Stop();
                _enemyAttackTimelineEvent.PlayTutorialTimeline01();
            }
        }
    }
}
