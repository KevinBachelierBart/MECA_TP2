using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class Carrot_Behavior : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_carrotSound;
    private Score_Manager m_scoreManager;

    [SerializeField]
    private int m_carrotScore;
    private void Start()
    {
        m_scoreManager = FindFirstObjectByType<Score_Manager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player_Behavior playerScript = other.GetComponent<Player_Behavior>();
        
        if (playerScript != null)
        {
            m_scoreManager.AddScore(m_carrotScore);

            //Je pense que c est sale af....
            Sound_Manager soundManager = playerScript.m_soundManager;
            soundManager.PlayAudio(soundManager.m_GPICarrot);

            Destroy(this.gameObject);
        }
    }


}
