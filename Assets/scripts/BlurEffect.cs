using System.Collections;
using UnityEngine;

public class BlurEffect : MonoBehaviour
{
    public GameObject blurSprite; // The GameObject with the blur SpriteRenderer
    private Coroutine blurCoroutine; // The Coroutine for the blur effect

   
    public void EnableBlur(float blurDuration)
    {
        // If a blur effect is already running, stop it
        if (blurCoroutine != null)
        {
            StopCoroutine(blurCoroutine);
        }

        // Start a new blur effect
        blurCoroutine = StartCoroutine(BlurCoroutine(blurDuration));
    }

    // The Coroutine for the blur effect
    private IEnumerator BlurCoroutine(float blurDuration)
    {
        // Enable the blur sprite
        blurSprite.SetActive(true);

        // Gradually increase the alpha value of the sprite's color over the specified duration
        SpriteRenderer spriteRenderer = blurSprite.GetComponent<SpriteRenderer>();
        Color color = spriteRenderer.color;
        float startTime = Time.time;
        while (Time.time - startTime < blurDuration)
        {
            color.a = (Time.time - startTime) / blurDuration;
            spriteRenderer.color = color;
            yield return null;
        }

        // Ensure the alpha value is set to 1 at the end of the duration
        color.a = 1;
        spriteRenderer.color = color;
    }
    
    public void DisableBlur()
    {
        // If a blur effect is running, stop it
        if (blurCoroutine != null)
        {
            StopCoroutine(blurCoroutine);
            blurCoroutine = null;
        }

        // Disable the blur sprite
        blurSprite.SetActive(false);
    }
}