using UnityEngine;

public class RandomGPILocation : MonoBehaviour
{
    [SerializeField]
    private Transform[] m_Locations;
    [SerializeField]
    private GameObject m_GPI;

    private void Start()
    {
        int random = Random.Range(0, m_Locations.Length);

        //m_GPI.transform.position = m_Locations[random].position;
        Instantiate(m_GPI, m_Locations[random].position, Quaternion.identity);
    }
}
