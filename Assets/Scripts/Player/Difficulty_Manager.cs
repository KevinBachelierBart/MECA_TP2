using UnityEngine;

public class Difficulty_Manager : MonoBehaviour
{
    private Player_Behavior m_player;
    private Sound_Manager m_sound_Manager;
    private float m_elapsed;
    [SerializeField]
    private float m_delayIncreaseDifficulty;
    [SerializeField] private int m_increaseValue;

    private void Start()
    {
        m_player = GetComponent<Player_Behavior>();
        m_sound_Manager = m_player.GetComponent<Sound_Manager>();
    }
    void Update()
    {
        m_elapsed += Time.deltaTime;

        if(m_elapsed >= m_delayIncreaseDifficulty)
        {
            m_elapsed = 0;
            m_player.m_speed += m_increaseValue;
            
        }
    }
}
