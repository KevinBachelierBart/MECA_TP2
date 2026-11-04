using TMPro;
using UnityEngine;


public class Display_Distance : MonoBehaviour
{
    [SerializeField]
    private Score_Manager m_score_Manager;

    [SerializeField]

    private TextMeshProUGUI m_displayTMP;

    private void Update()
    {
        m_displayTMP.text = m_score_Manager.m_score.ToString();
    }
}
