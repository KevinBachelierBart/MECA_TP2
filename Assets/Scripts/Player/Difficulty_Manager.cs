using UnityEngine;

public class Difficulty_Manager : MonoBehaviour
{
    private Player_Behavior m_player;
    private float m_baseSpeed;
    [SerializeField] private float m_elapsed;
    [SerializeField] private float m_increaseValue;

    private float vitesseTotale;
    private void Start()
    {
        m_player = GetComponent<Player_Behavior>();
        m_baseSpeed = m_player.m_speed;
    }
    void Update()
    {
        m_elapsed += Time.deltaTime;

        vitesseTotale = m_baseSpeed + (m_elapsed * m_increaseValue);

        m_player.m_speed = vitesseTotale;
    }
}
