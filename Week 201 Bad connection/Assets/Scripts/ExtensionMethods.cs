using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class ExtensionMethods
{
    public static void TurnOff(this CanvasGroup group)
    {
        group.alpha = 0;
        group.blocksRaycasts = false;
        group.interactable = false;
    }
    public static void TurnOn(this CanvasGroup group)
    {
        group.alpha = 1;
        group.blocksRaycasts = true;
        group.interactable = true;
    }
    public static void ChangeStartColor(this ParticleSystem.MainModule thisColor, Color changeToThisColor)
    {
        thisColor.startColor = new Color(changeToThisColor.r, changeToThisColor.g, changeToThisColor.b, changeToThisColor.a);
    }
    public static void ChangeColor(this SpriteRenderer sr, Color changeToThisColor)
    {
        sr.color = new Color(changeToThisColor.r, changeToThisColor.g, changeToThisColor.b, changeToThisColor.a);
    }
    public static Vector3 WorldPositionWithMainCamera(this Touch touch)
    {
        Vector3 touchPixelPos = new Vector3(touch.position.x, touch.position.y, Camera.main.transform.position.z);

        Vector3 pos = Camera.main.ScreenToWorldPoint(touchPixelPos);

        Vector3 touchPos = new Vector3(-pos.x, -pos.y, 0);
        
        return touchPos;
    }
    public static Vector3 WorldPositionWithMainCameraClick()
    {
        Vector3 clickPixelPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.z);

        Vector3 clickPos = Camera.main.ScreenToWorldPoint(clickPixelPos);

        Vector3 finalClickPos = new Vector3(-clickPos.x, -clickPos.y, 0);

        return finalClickPos;
    }
    /// <summary>
    /// Warning: Permanently Changes Pitch
    /// </summary>
    /// <param name="randomAmount">Amount to randomize between min and max.</param>
    public static void PlayPitchRandom(this AudioSource source, float randomAmount)
    {
        float originalPitch = source.pitch;
        float newPitch = Random.Range(-randomAmount, randomAmount);
        newPitch = newPitch + originalPitch;
        source.pitch = newPitch;
        source.Play();
    }
}
