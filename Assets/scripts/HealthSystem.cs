using UnityEngine;
using System.Collections;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    public GameObject lifeSquare;
    
    private TimelineManager _timelineManager;
    private CanvasController _canvasController;
    private BlackScreen _blackScreen;
    private BlurEffect _blurEffect;
    private AudioManager _audioManager;
    void Start()
    {
        currentHealth = maxHealth;
        _timelineManager = FindObjectOfType<TimelineManager>();
        _canvasController = FindObjectOfType<CanvasController>();
        _blackScreen = FindObjectOfType<BlackScreen>();
        _blurEffect = FindObjectOfType<BlurEffect>();
        _audioManager = FindObjectOfType<AudioManager>();
    }
    
    IEnumerator CameraShake(float duration, float magnitude)
    {
        Vector3 originalPosition = Camera.main.transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;

            Camera.main.transform.localPosition = new Vector3(x, y, originalPosition.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        Camera.main.transform.localPosition = originalPosition;
    }
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        _canvasController.SpawnBloodEffect();
        lifeSquare.transform.localScale *= 1.25f;
        StartCoroutine(CameraShake(0.15f, 0.3f));
        
        Animator animator = lifeSquare.GetComponent<Animator>();
        if (animator != null)
        {
            animator.speed *= 1.2f;
        }
        
        SpriteRenderer spriteRenderer = lifeSquare.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a *= 0.8f;
            spriteRenderer.color = color;
        }
        
        if (currentHealth <= 0)
        {
            Die();
            _audioManager.PlayAudio("die", 1f);
        }
        else
        {
            _audioManager.PlayAudio("hurt", 1f);
        }
    }

    // 生命值回满
    public void ResetHealth()
    {
        currentHealth = maxHealth;
        lifeSquare.transform.localScale = new Vector3(0.16f, 0.16f, 0.16f);
                 
        Animator animator = lifeSquare.GetComponent<Animator>();
        if (animator != null)
        {
            animator.speed = 1f; // 假设初始速度为1
        }

        SpriteRenderer spriteRenderer = lifeSquare.GetComponent<SpriteRenderer>();
        if (spriteRenderer != null)
        {
            Color color = spriteRenderer.color;
            color.a = 180f; 
            spriteRenderer.color = color;
        }
        
        _blurEffect.DisableBlur();
    }
    
    void Die()
    {
        Debug.Log("Entity died.");
        _blurEffect.EnableBlur(2f);
        _timelineManager.ResetTimeline();
    }
}