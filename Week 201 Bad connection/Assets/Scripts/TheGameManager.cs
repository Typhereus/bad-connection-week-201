using UnityEngine;

public class TheGameManager : MonoBehaviour
{
    /// <summary>
    /// Random places body parts for operation (board game) like game 
    /// around the body and shows it to the player for lengthOfTimeToShowBodyParts 
    /// length of time. Then it fades and removes the body parts for placement 
    /// by the player using android TOUCH controls. You wont be able to move the parts
    /// unless you have an android phone connected with UNITY REMOTE
    /// 
    /// Only the showing of body parts and the touch conrolts are implemented
    /// the DONE button is not implemented either
    /// </summary>
    public float lengthOfTimeToShowBodyParts = 5f;
    public CanvasGroup doneGroup;

    private void Start()
    {
        FadeToBlack.Instance.StartFadeToClear();

        Invoke("ShowAndBlank", lengthOfTimeToShowBodyParts);
    }

    public void ShowAndBlank()
    {
        FadeToBlack.Instance.StartFadeToBlack();
        Invoke("ShowBlank", 1f);
    }

    private void ShowBlank()
    {
        RandomBodyPartPlacement.Instance.MemoryGameSpawnPlacingParts();
        RandomBodyPartPlacement.Instance.RemovePreview();
        doneGroup.TurnOn();
        TouchingInputs.Instance.inputEnabled = true;
        FadeToBlack.Instance.StartFadeToClear();
    }
}
