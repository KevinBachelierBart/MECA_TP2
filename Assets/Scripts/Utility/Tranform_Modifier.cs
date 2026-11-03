using UnityEngine;

public class Tranform_Modifier : MonoBehaviour
{
    [Header("SCALING")]
    [SerializeField]
    private bool m_ChangeRotation = false;
    [SerializeField]
    private int m_angleRotation;
    [SerializeField]
    private float m_rotationSpeed = 1f;

    [Header("SCALING")]
    [SerializeField]
    private bool m_ChangeScaling = false;

    private Vector3 m_scaleA;
    [SerializeField]
    private Vector3 m_scaleB;
    [SerializeField]
    private float m_scalingSpeed = 1f;

    private void Start()
    {
        m_scaleA = transform.localScale;
    }

    void Update()
    {
        if (m_ChangeScaling)
        {
            float t = Mathf.PingPong(Time.time * m_scalingSpeed, 1f);//LLM

            transform.localScale = Vector3.Lerp(m_scaleA, m_scaleB, t);//LLM

        
        }

        if (m_ChangeRotation)
        {
            transform.Rotate(0, 0, m_angleRotation * m_rotationSpeed * Time.deltaTime) ;
        }

    }
}
