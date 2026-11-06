using UnityEngine;

public class Sound_Manager : MonoBehaviour
{
    //On player

    private AudioSource m_audioSource;
    public AudioClip m_jumpingSound;
    public AudioClip m_landingSound;
    public AudioClip m_grindingSound;
    private void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudioNewPitch(AudioClip myAudioClip, float newPitch)
    {

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


