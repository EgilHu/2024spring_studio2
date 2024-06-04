using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
//黑屏，用一张全黑图片覆盖屏幕，调整透明度使用curve。
public class BlackScreen : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public AnimationCurve curve;
    [Range(0f, 2f)]public float speed = 1f;

    private void Awake()
    {
        if (spriteRenderer == null)
            spriteRenderer = GetComponent<SpriteRenderer>();
    }

    Color tmpColor;

    public IEnumerator FadeIn()
    {
        float timer = 0f;
        tmpColor = spriteRenderer.color;
        do
        {
            timer += Time.deltaTime;
            SetColorAlpha(1 - curve.Evaluate(timer * speed));
            yield return null;

        } while (tmpColor.a <= 1);
    }

    public IEnumerator FadeOut()
    {
        float timer = 0f;
        tmpColor = spriteRenderer.color;
        do
        {
            timer += Time.deltaTime;
            SetColorAlpha(curve.Evaluate(timer * speed));
            yield return null;

        } while (tmpColor.a >= 0);
        //gameObject.SetActive(false);
    }
    
    void SetColorAlpha(float a)
    {
        tmpColor.a = a;
        spriteRenderer.color = tmpColor;
    }
    
    public void StartFadeIn()
    {
        StartCoroutine(FadeIn());
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }
}