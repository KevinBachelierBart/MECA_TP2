using UnityEngine;

public class Camera_Behavior : MonoBehaviour
{
    [SerializeField]
    private Transform m_target;//Player
    [SerializeField]
    private Vector3 m_offset;

    [SerializeField]
    private Vector3 m_StartingDistance;
    
    public int m_currentDistance;
    
    [SerializeField]
    private int currentHeight;

    void Start()
    {
        m_StartingDistance = m_target.transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = m_target.transform.position;
        transform.position = new Vector3(currentPosition.x + m_offset.x, transform.position.y, transform.position.z);


        float localCurrentDistance = Vector3.Distance(m_target.transform.position, m_StartingDistance);
        int result = (int)Mathf.Floor(localCurrentDistance);
        m_currentDistance = result;
    }
}
