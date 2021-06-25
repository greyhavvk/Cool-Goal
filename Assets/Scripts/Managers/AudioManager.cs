using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager audioManager;

#pragma warning disable 0649

    [Header("General References")]
    [SerializeField] private AudioSource generalAudioSource;

    [Header("SFXs")]
    [SerializeField] private AudioClip _finalSFX;
    [SerializeField] private AudioClip _failSFX;
    [SerializeField] private AudioClip _shotSFX;

#pragma warning restore 0649

    private void Awake()
    {
        audioManager = this;
    }

    public void PlayFailSFX()
    {
        generalAudioSource.PlayOneShot(_failSFX);
    }

    public void PlayFinishSFX()
    {
        generalAudioSource.PlayOneShot(_finalSFX);
    }

    public void PlayShotSFX()
    {
        generalAudioSource.PlayOneShot(_shotSFX);
    }
}