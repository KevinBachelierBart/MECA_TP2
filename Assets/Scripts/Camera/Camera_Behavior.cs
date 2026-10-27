using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;
    [SerializeField]
    private Vector3 m_offset;

    [SerializeField]
    private Vector3 m_StartingDistance;
    
    [SerializeField]
    private int m_currentDistance;

    void Start()
    {
        m_StartingDistance = m_target.transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = m_target.transform.position;
        //transform.position = currentPosition + m_offset;
        //transform.position = new Vector3(m_target.position.x, transform.position.y + m_offset.y, transform.position.z);
        transform.position = new Vector3(currentPosition.x + m_offset.x, transform.position.y, transform.position.z);


        float localCurrentDistance = Vector3.Distance(m_target.transform.position, m_StartingDistance);
        int result = (int)Mathf.Floor(localCurrentDistance);
        m_currentDistance = result;
    }
}
