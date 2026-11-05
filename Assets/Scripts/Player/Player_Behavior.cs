using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class Player_Behavior : MonoBehaviour
{
    [Header("INPUT SYSTEM")]
    [SerializeField]
    private InputActionAsset m_inputAction;
    private InputAction m_move;
    private Vector2 moveAmt;
    private InputAction m_jump;

    [Space(5)]
    [Header("Rigidbody 2D")]
    private Rigidbody2D m_rigidbody2D;

    [Header("DESIGN")]
    private bool m_isGrounded;
    private bool m_canMove;

    [Space(5)]
    [SerializeField]
    private int m_speed;

    [Space(5)]
    [SerializeField]
    private int m_jumpForce;
    private int m_doubleJump;

    [Header("SOUNDS")]
    private AudioSource m_audioSource;

    [Header("ANIMATION & SR")]
    private Animator m_animator;
    private SpriteRenderer m_sp;

    [Header("DEBUG--------------------------------------------------")]
    [SerializeField]
    private bool m_debugAutoRun = true;

    private GameObject m_Spark;

    void Start()
    {
        m_move = m_inputAction.FindAction("Move");
        m_jump = m_inputAction.FindAction("Jump");

        m_rigidbody2D = GetComponent<Rigidbody2D>();

        m_animator = GetComponent<Animator>();

        m_sp = GetComponent<SpriteRenderer>();

        m_Spark = transform.GetChild(0).gameObject;
        m_audioSource = GetComponent<AudioSource>();

        m_isGrounded = false;
        m_canMove = true;
    }

    void Update()
    {
        Moving();

        bool isJumping = m_jump.WasPressedThisFrame();
        if (isJumping)
        {
            Jump();
            
        }

        Falling();
    }  

    void Moving()
    {
        if(m_canMove)
        {
            //MOVEMENT
            if (m_debugAutoRun)
            {
                Vector2 calculatedVelocity = m_rigidbody2D.linearVelocity;
                calculatedVelocity.x = m_speed;
                m_rigidbody2D.linearVelocity = calculatedVelocity;
            }
            else
            {
                moveAmt = m_move.ReadValue<Vector2>().normalized;
                Vector2 calculatedVelocity = m_rigidbody2D.linearVelocity;
                calculatedVelocity.x = moveAmt.x * m_speed;
                m_rigidbody2D.linearVelocity = calculatedVelocity;
            }

            /*
            if(moveAmt.x == 0)
            {
                //Si tu ne touches pas le joystick
            }*/

            if (moveAmt.x < 0)
            {
                m_sp.flipX = true;
            }
            else
            {
                m_sp.flipX = false;
            }

            //ANIMATOR
            if (Mathf.Abs(m_rigidbody2D.linearVelocity.x) > Mathf.Epsilon)
            {
                SetBoolAnimation("isRunning", true);
            }
            else
            {
                SetBoolAnimation("isRunning", false);
            }
        }
        

    }

    void Jump()
    {
        m_doubleJump++;

        SetBoolAnimation("isJumping", true);
        SetBoolAnimation("a_IsGrounded", false);
        if (m_doubleJump <= 2)
        {
            m_rigidbody2D.AddForce(Vector2.up * m_jumpForce, ForceMode2D.Impulse);
            m_isGrounded = false;
        }
        else
        {
            //Debug.Log("Tu as deja fait ton double saut");
        }

        SparkEffect(false);
    }

    void Falling()
    {
        if (m_rigidbody2D.linearVelocity.y < Mathf.Epsilon)//Si velocity en y de player est < que 0.00...008
        {
            SetBoolAnimation("isJumping", false);
            SetBoolAnimation("isFalling", true);
        }
    }

    public void Dying()
    {
        m_canMove = false;
        m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX;//LLM et pas top top 
        m_rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionY;//LLM et pas top top 

        SetBoolAnimation("isFalling", false);
        SetBoolAnimation("isJumping", false);

        SetBoolAnimation("isDying", true);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            m_isGrounded = true;
            m_doubleJump = 0;
            SetBoolAnimation("a_IsGrounded", true);
            SetBoolAnimation("isFalling", false);
        }
        else if (collision.gameObject.layer == LayerMask.NameToLayer("SideDeath"))
        {
            Dying();
        }
        else if(collision.gameObject.layer == LayerMask.NameToLayer("Pipe"))
        {
            SparkEffect(true);
            m_doubleJump = 0;
        }
    }

    void SetBoolAnimation(string animName, bool animBool)
    {
        m_animator.SetBool(animName, animBool);
    }

    public void PlayGPISound(AudioClip myAudioClip)
    {
        m_audioSource.PlayOneShot(myAudioClip);
    }

    public void SparkEffect(bool isActivated)
    {
        m_Spark.SetActive(isActivated);
    }

}
