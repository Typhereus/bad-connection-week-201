using UnityEngine;

public class VariousSounds : MonoBehaviour
{
    AudioSource buttonAudioSource;

    [SerializeField] AudioClip[] audioClips;

    private void Start()
    {
        buttonAudioSource = GetComponent<AudioSource>();
    }

    public void PlayButtonSound()
    {
        foreach (var sound in audioClips)
        {
            if (sound.name.Contains("Button Pushed"))
            {
                buttonAudioSource.clip = sound;
                Debug.Log(sound.name + " Inserito"); //DEBUG
                buttonAudioSource.Play();
                return;
            }
        }
        Debug.Log("Missing Button Pushed clip.");
    }
}
