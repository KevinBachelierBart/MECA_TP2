using System.Collections.Generic;//Pour List
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private Transform m_player;

    [SerializeField]
    private GameObject[] m_platformPrefab;
    [SerializeField]
    private Transform m_startingPlatform;
    private Transform m_lastCreatedPlatform;
    [Header("DESIGN")]
    [SerializeField] private float m_distanceForPlatformSpawn;
    [Space(2)]
    [SerializeField] private float m_distanceBetweenPlatform;
    private int m_previousRandom = -1;
    private int m_random = -1;
    [Header("LIST")]
    private List<Transform> m_platformCache;
    [Tooltip("Number of platf in-game before delete")]
    [SerializeField] private int m_maxPlatformCount;


    [Header("DEBUG")]
    [SerializeField] private bool m_debugMode = false;
    [SerializeField] private int m_debugPlatformChoice = -1;
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

        
        
        if (m_debugMode)
        {
            GameObject newPlatformDebug = Instantiate(m_platformPrefab[m_debugPlatformChoice], spawnPosition, Quaternion.identity);
            return newPlatformDebug.transform;
        }
        else
        {
            GameObject newPlatform = Instantiate(m_platformPrefab[Randomize()], spawnPosition, Quaternion.identity);
            return newPlatform.transform;
        }

            
    }

    int Randomize()
    {
        //Randomize spawning
        do
        {
            m_random = Random.Range(0, m_platformPrefab.Length);//0 to 2

        } while (m_previousRandom == m_random);
        
        m_previousRandom = m_random;






        return m_random;
    }

}
