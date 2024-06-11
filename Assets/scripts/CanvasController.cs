using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject[] prefabs; // 存储预制体的数组
    public float fadeSpeed = 0.5f; // 渐入渐出的速度
    public float titleDuration = 3f; // 持续时间
    public float tutorialFadeSpeed = 0.5f; // 教程文本的渐入渐出速度
    public float tutorialDuration = 1f; // 教程文本的持续时间
    public float bloodEffectFadeSpeed = 1f; // 血液特效的渐入渐出速度
    public float bloodEffectDuration = 1f; // 血液特效的持续时间
    //public GameObject bloodEffect;

    private BlackScreen blackScreen;
    // Start is called before the first frame update
    void Start()
    {
        blackScreen = FindObjectOfType<BlackScreen>();
    }

    public void BlackScreenFadeIn()
    {
        blackScreen.StartFadeIn();
    }
    public void BlackScreenFadeOut()
    {
        blackScreen.StartFadeOut();
    }
    
    // 新的方法，用于生成指定的预制体并实现渐入和渐出效果
    public void SpawnWithFade(int prefabIndex)
    {
        if (prefabIndex >= 0 && prefabIndex < prefabs.Length)
        {
            GameObject prefab = Instantiate(prefabs[prefabIndex], prefabs[prefabIndex].transform.position, prefabs[prefabIndex].transform.rotation);
            StartCoroutine(FadeInOut(prefab, fadeSpeed, titleDuration));
        }
        else
        {
            Debug.LogWarning("Prefab index out of range: " + prefabIndex);
        }
    }

    public void SpawnTutorialLongTextWithFade(int prefabIndex)
    {
        if (prefabIndex >= 0 && prefabIndex < prefabs.Length)
        {
            GameObject prefab = Instantiate(prefabs[prefabIndex], prefabs[prefabIndex].transform.position, prefabs[prefabIndex].transform.rotation);
            StartCoroutine(FadeInOut(prefab, tutorialFadeSpeed, 5));
        }
        else
        {
            Debug.LogWarning("Prefab index out of range: " + prefabIndex);
        }
    }
    public void SpawnTutorialTextWithFade(int prefabIndex)
    {
        if (prefabIndex >= 0 && prefabIndex < prefabs.Length)
        {
            GameObject prefab = Instantiate(prefabs[prefabIndex], prefabs[prefabIndex].transform.position, prefabs[prefabIndex].transform.rotation);
            StartCoroutine(FadeInOut(prefab, tutorialFadeSpeed, tutorialDuration));
        }
        else
        {
            Debug.LogWarning("Prefab index out of range: " + prefabIndex);
        }
    }
    
    private IEnumerator FadeInOut(GameObject prefab, float Speed, float duration)
    {
        SpriteRenderer renderer = prefab.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            // 渐入
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / Speed)
            {
                Color newColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Lerp(0, 1, t));
                renderer.color = newColor;
                yield return null;
            }

            // 保持1秒
            yield return new WaitForSeconds(duration);

            // 渐出
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / Speed)
            {
                Color newColor = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Lerp(1, 0, t));
                renderer.color = newColor;
                yield return null;
            }

            Destroy(prefab); // 销毁预制体
        }
    }
    
    private void SpawnWithFade(int prefabIndex, float speed,float duration)
    { 
        if (prefabIndex >= 0 && prefabIndex < prefabs.Length)
        {
            GameObject prefab = Instantiate(prefabs[prefabIndex], prefabs[prefabIndex].transform.position, prefabs[prefabIndex].transform.rotation);
            StartCoroutine(FadeInOut(prefab, speed, duration));
        }
        else
        {
            Debug.LogWarning("Prefab index out of range: " + prefabIndex);
        }
    }
    
    public void SpawnBloodEffect()
    {
        SpawnWithFade(4, bloodEffectFadeSpeed, bloodEffectDuration);
        //Debug.Log("Spawn blood effect.");
    }
}