using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;
    
    private TimelineManager _timelineManager;
    private CanvasController _canvasController;
    private BlackScreen _blackScreen;
    void Start()
    {
        currentHealth = maxHealth;
        _timelineManager = FindObjectOfType<TimelineManager>();
        _canvasController = FindObjectOfType<CanvasController>();
        _blackScreen = FindObjectOfType<BlackScreen>();
    }
    
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        _canvasController.SpawnBloodEffect();
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
        _timelineManager.PauseAndPlayFromTime(0, 0);
         _blackScreen.StartFadeOut();
    }
}