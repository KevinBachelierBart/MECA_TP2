using System.Net.NetworkInformation;
using UnityEngine;

public class WolfTrap_GPI : MonoBehaviour
{
    [SerializeField]
    //private AudioClip m_trapSound; Maybe later
    private Animator m_animator;
    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player_Behavior playerScript = other.GetComponent<Player_Behavior>();

        if (playerScript != null)
        {
            m_animator.Play("WolfTrap");

            //playerScript.PlayGPISound(m_trapSound);
            playerScript.Dying();
        }
    }
}
