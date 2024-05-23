using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    private TimelineManager _timelineManager;
    void Start()
    {
        currentHealth = maxHealth;
        _timelineManager = FindObjectOfType<TimelineManager>();
    }
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // 生命值回满
    public void ResetHealth()
    {
        currentHealth = maxHealth;
    }
    
    void Die()
    {
        Debug.Log("Entity died.");
        _timelineManager.StopTimeline(0);
    }
}