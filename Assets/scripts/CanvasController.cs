using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
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
}
