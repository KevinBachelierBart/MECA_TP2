using UnityEngine;

public class Score_Manager : MonoBehaviour
{
    [SerializeField]
    private Camera_Behavior m_cameraBehavior;
    private int m_bonusScore;
    public int m_score = 0;
    public int m_highestScore;

    private void Start()
    {
        m_highestScore = PlayerPrefs.GetInt("HighestScore", 0);
    }
    private void Update()
    {
        m_score = m_bonusScore + m_cameraBehavior.m_currentDistance;
    }

    public void AddScore(int additionalScore)
    {
        m_bonusScore += additionalScore;
    }

    public void SaveScore()
    {
        int score = m_score;
        PlayerPrefs.SetInt("Score", score);
        
        if(score > m_highestScore)
        {
            SaveHighestScore(score);
        }

        PlayerPrefs.Save();
    }

    private void SaveHighestScore(int myHighestScore)
    {
        PlayerPrefs.SetInt("HighestScore", myHighestScore);
        PlayerPrefs.Save();
    }


}
