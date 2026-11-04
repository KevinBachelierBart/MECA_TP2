using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    [SerializeField]
    private Camera_Behavior m_cameraBehavior;
    private int m_cameraDistance;
    private int m_bonusScore;
    public int m_score = 0;
    private void Update()
    {
        m_score = m_bonusScore + m_cameraBehavior.m_currentDistance;
    }

    public void AddScore(int additionalScore)
    {
        m_bonusScore += additionalScore;
    }


}
