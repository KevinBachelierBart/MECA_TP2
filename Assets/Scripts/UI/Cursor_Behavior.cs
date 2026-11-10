using UnityEngine;
using UnityEngine.SceneManagement;

public class Cursor_Behavior : MonoBehaviour
{
    //[SerializeField]private bool m_showCursor; A utiliser si plus de scenes a venir
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        

    }
}
