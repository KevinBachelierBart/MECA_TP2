using System.Collections.Generic;//Pour List
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField]
    private GameObject m_platformPrefab;
    [SerializeField]
    private Transform m_startingPlatform;
    private Transform m_lastCreatedPlatform;
    [SerializeField] private Transform m_player;
    [Header("DESIGN")]
    [SerializeField] private float m_distanceForPlatformSpawn;
    [Space(2)]
    [SerializeField] private float m_distanceBetweenPlatform;

    [Header("LIST")]
    [SerializeField]
    private List<Transform> m_platformCache;
    [SerializeField] private int m_maxPlatformCount;



    void Start()
    {
        m_platformCache = new List<Transform>();
        m_lastCreatedPlatform = m_startingPlatform;
        m_platformCache.Add(m_startingPlatform);
    }

    private void Update()
    {
        if (Vector3.Distance(m_player.position, m_lastCreatedPlatform.position) < m_distanceForPlatformSpawn)
        {
            Transform platformEndPoint = m_lastCreatedPlatform.Find("End");
            m_lastCreatedPlatform = SpawnPlatform(platformEndPoint.position);

            m_platformCache.Add(m_lastCreatedPlatform);

            if(m_platformCache.Count > m_maxPlatformCount)
            {
                Transform platformToDelete = m_platformCache[0];
                Destroy(platformToDelete.gameObject);
                m_platformCache.RemoveAt(0);
            }
        } 
    }


    private Transform SpawnPlatform(Vector3 spawnPosition)
    {
        spawnPosition.x += m_distanceBetweenPlatform; 

        GameObject newPlatform = Instantiate(m_platformPrefab, spawnPosition, Quaternion.identity);
        return newPlatform.transform;
    }

}
