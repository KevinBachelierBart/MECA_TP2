using System.Net.NetworkInformation;
using UnityEngine;

public class WolfTrap_GPI : MonoBehaviour
{
    [SerializeField]
    private AudioClip m_trapSound;

    private void Start()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player_Behavior playerScript = other.GetComponent<Player_Behavior>();

        if (playerScript != null)
        {
            //playerScript.PlayGPISound(m_trapSound);
            playerScript.Dying();
        }
    }
}
