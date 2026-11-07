using TMPro;
using UnityEngine;

public class Display_Leaderboard : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI m_highestScoreTMP;
    [SerializeField] private TextMeshProUGUI m_lastScoreTMP;

    private void Start()
    {
        m_highestScoreTMP.text = "HIGHEST SCORE:\n " + PlayerPrefs.GetInt("HighestScore",0).ToString();
        m_lastScoreTMP.text = "YOUR SCORE: " + PlayerPrefs.GetInt("Score", 0).ToString();
    }
}
