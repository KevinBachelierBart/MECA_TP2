using TMPro;
using UnityEngine;


public class Display_Distance : MonoBehaviour
{
    [SerializeField]
    Camera_Behavior m_cameraBehavior;

    [SerializeField]

    private TextMeshProUGUI m_displayTMP;

    private void Update()
    {
        m_displayTMP.text = m_cameraBehavior.m_currentDistance.ToString();
    }
}
