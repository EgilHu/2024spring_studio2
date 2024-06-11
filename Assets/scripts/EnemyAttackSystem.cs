using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackSystem : MonoBehaviour
{
    public GameObject[] tutorialPrefabs;
    public GameObject playerAttackVFX;

    private PlayerReaction playerReaction;
    private HealthSystem _healthSystem;
    private ScreenDamage _screenDamage;
    private DebugHandLandMarks _debugHandLandMarks;

    private Dictionary<EnemyAttackType, Coroutine> runningCoroutines = new Dictionary<EnemyAttackType, Coroutine>();

    void Start()
    {
        playerReaction = FindObjectOfType<PlayerReaction>();
        _screenDamage = FindObjectOfType<ScreenDamage>();
        _healthSystem = FindObjectOfType<HealthSystem>();
        _debugHandLandMarks = FindObjectOfType<DebugHandLandMarks>();
    }

    public enum EnemyAttackType
    {
        LeftSideAttack,
        RightSideAttack,
        MiddleAttack,
        SinglePalmAttack,
        SinglePalmAttackLeft,
        SinglePalmAttackRight,
        DoublePalmAttack,
        UpSideAttack,
        UpSideAttackLeft,
        UpSideAttackRight,
    }

    [System.Serializable]
    public class EnemyAttackMove
    {
        public EnemyAttackType type;
        public GameObject prefab;
    }

    public EnemyAttackMove[] enemyAttackMoves;

    public void StartEnemyAttack(EnemyAttackType type, float speed)
    {
        if (runningCoroutines.ContainsKey(type))
        {
            StopCoroutine(runningCoroutines[type]);
            runningCoroutines.Remove(type);
        }
        Coroutine attackCoroutine = StartCoroutine(SpawnEnemyAttack(type, speed));
        runningCoroutines[type] = attackCoroutine;
    }

    public IEnumerator SpawnEnemyAttack(EnemyAttackType type, float speed)
    {
        EnemyAttackMove move = System.Array.Find(enemyAttackMoves, x => x.type == type);
        if (move != null)
        {
            GameObject attackObject = Instantiate(move.prefab, move.prefab.transform.position, move.prefab.transform.rotation);
            Renderer renderer = attackObject.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.enabled = false;
            }
            Animator animator = attackObject.GetComponent<Animator>();
            if (animator != null)
            {
                animator.enabled = false;
            }
            yield return null;
            yield return new WaitForSeconds(0.1f);
            if (renderer != null)
            {
                renderer.enabled = true;
            }
            if (animator != null)
            {
                animator.enabled = true;
                animator.speed = speed;
            }
            playerReaction.ReactToSignal(type);
        }
        else
        {
            Debug.LogWarning("Attack type not found: " + type);
        }

        if (runningCoroutines.ContainsKey(type))
        {
            runningCoroutines.Remove(type);
        }
    }

    public void StopSpecificEnemyAttack(EnemyAttackType type)
    {
        if (playerReaction != null)
        {
            if (!playerReaction.IsReactionSuccessful(type))
            {
                Debug.Log("YOU DIE");
                _healthSystem.TakeDamage(1);
                //_screenDamage.CurrentHealth -= 1f;
                Debug.Log("Health has been updated: " + _healthSystem.currentHealth);
            }
            if (runningCoroutines.ContainsKey(type))
            {
                StopCoroutine(runningCoroutines[type]);
                runningCoroutines.Remove(type);
            }
        }
        else
        {
            Debug.LogError("PlayerReaction is not initialized");
        }
    }

    public void StopCounterAttack()
    {
        if (playerReaction != null)
        {
            if (!playerReaction.successfulReaction)
            {
                Debug.Log("YOU DIE");
                _healthSystem.TakeDamage(1);
                _screenDamage.CurrentHealth -= 1f; 
                Debug.Log("Health has been updated: " + _healthSystem.currentHealth);
            }
            StopCoroutine(playerReaction.counterAttackCoroutine);
        }
        else
        {
            Debug.LogError("PlayerReaction is not initialized");
        }
    }

    public void DestroyPrefab(GameObject prefab)
    {
        Destroy(prefab);
    }

    public IEnumerator SpawnTutorialAttack(EnemyAttackType type, int frameCount)
    {
        StartCoroutine(SpawnEnemyAttack(type, 1.0f));

        for (int i = 0; i < frameCount; i++)
        {
            yield return null;
        }

        Animator animator = enemyAttackMoves[(int)type].prefab.GetComponent<Animator>();
        if (animator != null)
        {
            Time.timeScale = 0;
        }

        while (true)
        {
            if (playerReaction.GetCorrectReactionTypeForAttack(type))
            {
                if (animator != null)
                {
                    Time.timeScale = 1;
                }

                yield return null;
                yield break;
            }

            yield return null;
        }
    }

    public void SpawnTutorialFistAni(int index)
    {
        if (index >= 0 && index < tutorialPrefabs.Length)
        {
            GameObject prefab = Instantiate(tutorialPrefabs[index], tutorialPrefabs[index].transform.position, Quaternion.identity);
            playerReaction.currentTutorialPrefab = prefab;

            // Start the new coroutine
            StartCoroutine(PlayFistAnimationThenResumeTimeline(prefab));
        }
        else
        {
            Debug.LogWarning("Tutorial prefab index out of range: " + index);
        }
    }
    public void SpawnTutorialSPalmAni(int index)
    {
        if (index >= 0 && index < tutorialPrefabs.Length)
        {
            GameObject prefab = Instantiate(tutorialPrefabs[index], tutorialPrefabs[index].transform.position, Quaternion.identity);
            playerReaction.currentTutorialPrefab = prefab;

            // Start the new coroutine
            StartCoroutine(PlaySPalmAnimationThenResumeTimeline(prefab));
        }
        else
        {
            Debug.LogWarning("Tutorial prefab index out of range: " + index);
        }
    }
    public void SpawnTutorialUSidePalmAni(int index)
    {
        if (index >= 0 && index < tutorialPrefabs.Length)
        {
            GameObject prefab = Instantiate(tutorialPrefabs[index], tutorialPrefabs[index].transform.position, Quaternion.identity);
            playerReaction.currentTutorialPrefab = prefab;

            // Start the new coroutine
            StartCoroutine(PlayUSidePalmAnimationThenResumeTimeline(prefab));
        }
        else
        {
            Debug.LogWarning("Tutorial prefab index out of range: " + index);
        }
    }
    public void SpawnTutorialDPalmAni(int index)
    {
        if (index >= 0 && index < tutorialPrefabs.Length)
        {
            GameObject prefab = Instantiate(tutorialPrefabs[index], tutorialPrefabs[index].transform.position, Quaternion.identity);
            playerReaction.currentTutorialPrefab = prefab;

            // Start the new coroutine
            StartCoroutine(PlayDPalmAnimationThenResumeTimeline(prefab));
        }
        else
        {
            Debug.LogWarning("Tutorial prefab index out of range: " + index);
        }
    }
    
    
    private IEnumerator PlayFistAnimationThenResumeTimeline(GameObject prefab)
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Pause the timeline but keep the prefab animation playing
        Time.timeScale = 0;
        Animator animator = prefab.GetComponent<Animator>();
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime; // Set the animator to ignore time scale
        }

        // Wait until _debugHandLandMarks.DetectDoubleFist() returns true
        while (!_debugHandLandMarks.DetectDoubleFist())
        {
            yield return null;
        }

        // Resume the timeline
        Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
        Time.timeScale = 1;
        Destroy(prefab);
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.Normal; // Set the animator back to normal update mode
        }
    }
    private IEnumerator PlaySPalmAnimationThenResumeTimeline(GameObject prefab)
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Pause the timeline but keep the prefab animation playing
        Time.timeScale = 0;
        Animator animator = prefab.GetComponent<Animator>();
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime; // Set the animator to ignore time scale
        }
        
        while (!_debugHandLandMarks.DetectSinglePalmAttack())
        {
            yield return null;
        }

        // Resume the timeline
        Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
        Time.timeScale = 1;
        Destroy(prefab);
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.Normal; // Set the animator back to normal update mode
        }
    }
    private IEnumerator PlayUSidePalmAnimationThenResumeTimeline(GameObject prefab)
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Pause the timeline but keep the prefab animation playing
        Time.timeScale = 0;
        Animator animator = prefab.GetComponent<Animator>();
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime; // Set the animator to ignore time scale
        }
        
        while (!_debugHandLandMarks.DetectPalmDownAttack())
        {
            yield return null;
        }

        // Resume the timeline
        Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
        Time.timeScale = 1;
        Destroy(prefab);
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.Normal; // Set the animator back to normal update mode
        }
    }
    private IEnumerator PlayDPalmAnimationThenResumeTimeline(GameObject prefab)
    {
        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Pause the timeline but keep the prefab animation playing
        Time.timeScale = 0;
        Animator animator = prefab.GetComponent<Animator>();
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.UnscaledTime; // Set the animator to ignore time scale
        }
        
        while (!_debugHandLandMarks.DetectDoublePalmAttack())
        {
            yield return null;
        }

        // Resume the timeline
        Instantiate(playerAttackVFX, Vector3.zero, Quaternion.identity);
        Time.timeScale = 1;
        Destroy(prefab);
        if (animator != null)
        {
            animator.updateMode = AnimatorUpdateMode.Normal; // Set the animator back to normal update mode
        }
    }
}
