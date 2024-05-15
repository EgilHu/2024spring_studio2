using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ScreenDamage : MonoBehaviour
{
    [Tooltip("The maximum amount of health. THIS IS NOT THE CURRENT HEALTH.")]
    public float maxHealth = 30f;                                      
    [Tooltip("Drag and drop the image game object which contains the bloody frame.")]
    public Image bloodyFrame;                                           
    [Tooltip("The amount of critical health which when reached will make a pulsating effect.")]
    public float criticalHealth = 10f;                                  
    
    [Tooltip("Will show a blur effect when hit.")]
    public bool useBlurEffect = true;                                  
    [Tooltip("The radial blur image.")]
    public Image blurImage;                                             
    [Tooltip("The duration of the blur effect."), Range(0f, 5f)] 
    public float blurDuration = 0.1f;                   
    [Tooltip("The speed of the blur fading in and out.")]
    public float blurFadeSpeed = 5f;                                    
    
    [Tooltip("Set an event to trigger on death.")]
    public UnityEvent deathEvent;     


    #region SYSTEM VARIABLES

    float _health;                                                      
    float opacity = 0f;                                                 
    float lastHealth = 100f;   
    float showDamageOpacity;                                         

    Animator animator;                                                  
    Dictionary<AudioSource, float> fadedAudiosCopy;                     
    
    bool showingBlur = false;                                           
    bool triggerBlur = false;
    bool hideBlur = false;
    bool hideDamage = false;

    public float CurrentHealth {
        get { return _health; }

        set {
            hideDamage = false;

            // save the last health
            lastHealth = _health;

            // set the new health
            _health = value;

            
            // show radial blur effect
            if (_health < lastHealth && useBlurEffect && blurImage != null && _health > 0f) {
                blurImage.enabled = true;
                hideBlur = false;
                triggerBlur = true;
            }


            bloodyFrame.enabled = true;


            // if health set to something less than 0 - DEAD
            if (_health <= 0f) {
                _health = 0f;
                animator.enabled = false;

                deathEvent.Invoke();

                // change blood frame color to black
                var temp = bloodyFrame.color;
                temp = new Color(0, 0, 0, 200);
                bloodyFrame.color = temp;

                return;
            }
            
            // turn on/off pulsating effect
            if (_health <= criticalHealth && (_health > 0f)) {
                animator.enabled = true;
            }
            else {
                animator.enabled = false;
            }

            // calculate the opacity
            opacity = 1f - (_health / maxHealth);
            
            // change image opacity value
            var tempColor = bloodyFrame.color;
            tempColor = new Color(255, 255, 255, opacity);
            bloodyFrame.color = tempColor;
        }
    }

    #endregion

    #region UNITY METHODS

    void Start() 
    {
        animator = bloodyFrame.transform.GetComponent<Animator>();

        //set current health to maximum health on start
        CurrentHealth = maxHealth;
    }


    void Update()
    {
        // fade in blur
        if (triggerBlur) {
            
            var tempColor = blurImage.color;
            tempColor.a += Time.deltaTime * blurFadeSpeed;
            blurImage.color = tempColor;

            if (tempColor.a >= 1.9f) {
                triggerBlur = false;
                showRadialBlurCoroutine = StartCoroutine(ShowRadialBlur());
            }
        }
        
        // fade out blur
        if (hideBlur) {
            var tempColor = blurImage.color;
            tempColor.a -= Time.deltaTime * blurFadeSpeed;
            blurImage.color = tempColor;

            if (tempColor.a <= 0f) {
                hideBlur = false;
                blurImage.enabled = false;
            }
        }

        // hide the damage called from ShowDamage()
        if (hideDamage) {
            showDamageOpacity -= Time.deltaTime * showDamageOpacity;
            bloodyFrame.color = new Color(bloodyFrame.color.r, bloodyFrame.color.g, bloodyFrame.color.b, showDamageOpacity);
            
            if (showDamageOpacity <= 0.1) {
                hideDamage = false;
            }
        }
    }

    #endregion

    #region SYSTEM METHODS
    
    // show the radial blur coroutine
    Coroutine showRadialBlurCoroutine;
    IEnumerator ShowRadialBlur()
    {
        if (showingBlur) yield break;

        showingBlur = true;
        blurImage.enabled = true;
        
        yield return new WaitForSeconds(blurDuration);
        
        showingBlur = false;
        hideBlur = true;
    }

    #endregion

    #region APIs

    public void ShowDamage(float shownValue)
    {
        hideDamage = false;

        bloodyFrame.enabled = true;
        opacity = 1f - (shownValue / maxHealth);

        var tempColor = bloodyFrame.color;
        tempColor = new Color(255, 255, 255, opacity);
        bloodyFrame.color = tempColor;

        ShowBlur();

        showDamageOpacity = opacity;
    }

    public void ShowBlur()
    {
        if (useBlurEffect) {
            blurImage.enabled = true;
            hideBlur = false;
            triggerBlur = true;
        }
    }

    #endregion
}
