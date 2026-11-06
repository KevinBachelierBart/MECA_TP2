using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    private AudioSource m_audioSource;

    public AudioClip m_GPICarrot;
    public AudioClip m_jumpingSound;
    public AudioClip m_landingSound;
    public AudioClip m_grindingSound;
    public AudioClip m_death;
    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudioNewPitch(AudioClip myAudioClip, float newPitch)
    {
        //Si besoin
    }

    public void PlayAudio(AudioClip myAudioClip) 
    {
        m_audioSource.PlayOneShot(myAudioClip);
    }

    public void PlayAudioCondition(bool canPlay, AudioClip myAudioClip)
    {
        if (canPlay) 
        {
            m_audioSource.PlayOneShot(myAudioClip);
        }
        else
        {
            m_audioSource.Stop();
        }
    }

}


