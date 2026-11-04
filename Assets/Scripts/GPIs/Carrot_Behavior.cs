using UnityEngine;
using UnityEngine.SceneManagement;

public class Carrot_Behavior : MonoBehaviour
{
    private AudioSource m_carrotSound;
    private Score_Manager m_scoreManager;

    [SerializeField]
    private int m_carrotScore;
    private void Start()
    {
        m_carrotSound = GetComponent<AudioSource>();
        m_scoreManager = FindFirstObjectByType<Score_Manager>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player_Behavior playerScript = other.GetComponent<Player_Behavior>();
        
        if (playerScript != null)
        {
            m_carrotSound.Play();

            m_scoreManager.AddScore(m_carrotScore);

            Destroy(this.gameObject);
        }
    }


}
