using UnityEngine;

public class StopRiding : MonoBehaviour
{
    //Ce script est pour eviter un update qui tourne et qui verifie le layer de ride
    //Avec ca j ai un trigger dans ma platform#3 pour stopper le riding animation
    //si jamais le joueur ne saute pas
    //Car c est le saut qui arrete le riding sinon
    //CELA DIT CLAIREMENT BESOIN DE MIEUX GERER LA COMM ENTRE MES SCRIPTS

    private void OnTriggerEnter2D(Collider2D other)
    {
        Player_Behavior playerScript = other.GetComponent<Player_Behavior>();

        if (playerScript != null)
        {
            playerScript.SparkEffect(false);

            //Je pense que c est sale af....
            playerScript.m_GrindSliding.Stop();
        }
    }
}
