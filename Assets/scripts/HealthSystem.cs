using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    void Start()
    {
        currentHealth = maxHealth;
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
    }
}