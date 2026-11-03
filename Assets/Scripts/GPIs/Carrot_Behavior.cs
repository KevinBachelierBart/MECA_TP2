using UnityEngine;

public class Carrot_Behavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Player_Behavior playerScript = other.GetComponent<Player_Behavior>();
        
        if (playerScript != null)
        {

        }
    }
}
