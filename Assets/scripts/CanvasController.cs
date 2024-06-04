using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    public GameObject[] prefabs; // 存储预制体的数组
    public float fadeSpeed = 0.5f; // 渐入渐出的速度

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
            GameObject prefab = Instantiate(prefabs[prefabIndex], Vector3.zero, Quaternion.identity);
            StartCoroutine(FadeInOut(prefab));
        }
        else
        {
            Debug.LogWarning("Prefab index out of range: " + prefabIndex);
        }
    }

    private IEnumerator FadeInOut(GameObject prefab)
    {
        SpriteRenderer renderer = prefab.GetComponent<SpriteRenderer>();
        if (renderer != null)
        {
            // 渐入
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeSpeed)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(0, 1, t));
                renderer.color = newColor;
                yield return null;
            }

            // 保持1秒
            yield return new WaitForSeconds(3f);

            // 渐出
            for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeSpeed)
            {
                Color newColor = new Color(1, 1, 1, Mathf.Lerp(1, 0, t));
                renderer.color = newColor;
                yield return null;
            }

            Destroy(prefab); // 销毁预制体
        }
    }
}