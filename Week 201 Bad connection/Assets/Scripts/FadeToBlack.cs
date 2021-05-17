using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToBlack : MonoBehaviour
{
    public static FadeToBlack Instance;
    private void Awake()
    {
        Instance = this;
    }

    public Animator fadeToBlackAnimator;

    public void StartFadeToBlack()
    {
        fadeToBlackAnimator.SetTrigger("FadeToBlack");
    }
    public void StartFadeToClear()
    {
        fadeToBlackAnimator.SetTrigger("FadeToClear");  
    }
}
