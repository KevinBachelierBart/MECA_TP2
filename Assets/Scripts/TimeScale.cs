using UnityEngine;

public class TimeScale : MonoBehaviour
{
    //SCRIPT UNIQUEMENT DANS GAME
    private float m_timeScaleState;
    void Start()
    {
        SetTimeScale(0f);
    }

    public void SetTimeScale(float timeScaleState)
    {
        Time.timeScale = timeScaleState;
    }
}
