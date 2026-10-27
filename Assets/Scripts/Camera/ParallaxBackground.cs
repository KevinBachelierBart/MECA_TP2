using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_parralaxEffectMultiplier;

    private Transform m_cameraTransform;
    private Vector3 m_lastCameraPosition;

    private float m_textureUnitSize;

    void Start()
    {
        m_cameraTransform = Camera.main.transform;
        m_lastCameraPosition = m_cameraTransform.position;

        //Infinite
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        Texture2D texture = sprite.texture;
        m_textureUnitSize = texture.width / sprite.pixelsPerUnit;
        m_textureUnitSize *= transform.localScale.x;
    }


    void LateUpdate()
    {
        Vector3 deltaMovement = m_cameraTransform.position - m_lastCameraPosition; 


        transform.position += new Vector3(deltaMovement.x * m_parralaxEffectMultiplier.x, deltaMovement.y, deltaMovement.z);
        m_lastCameraPosition = m_cameraTransform.position;

        if (Mathf.Abs( m_cameraTransform.position.x - transform.position.x) >= m_textureUnitSize)
        {
            float offsetPositionX = (m_cameraTransform.position.x - transform.position.x) % m_textureUnitSize;
            transform.position = new Vector3(m_cameraTransform.position.x + offsetPositionX, transform.position.y);
        }
    }
}
