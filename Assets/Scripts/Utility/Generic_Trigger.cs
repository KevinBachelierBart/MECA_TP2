using UnityEngine;
using UnityEngine.Events;

public class Generic_Trigger : MonoBehaviour
{
    //Pensé à la fin du TP mais à faire pour le suivant, définitivement. 
    [SerializeField]
    private bool isTriggerEnter = false;
    [SerializeField]
    private UnityEvent myEventEnter;

    [Space(10)]

    [SerializeField]
    private bool isTriggerExit = false;
    [SerializeField] private UnityEvent myEventExit;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Player_Behavior playerScriptEnter = other.GetComponent<Player_Behavior>();

        if (isTriggerEnter) 
        {
            if (playerScriptEnter != null)
            {
                myEventEnter.Invoke();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Player_Behavior playerScriptExit = collision.GetComponent<Player_Behavior>();

        if (isTriggerExit) 
        {
            if (playerScriptExit != null)
            {
                myEventExit.Invoke();
            }
        }
    }
}
