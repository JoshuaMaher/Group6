using UnityEngine;
using System.Collections;


public class TutorialMovement : MonoBehaviour 
{
    [SerializeField] public float speed;
    [SerializeField] private float jumpness;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpCooldown;
    [SerializeField] private GameObject Grey;
    private float cooldownTimer = Mathf.Infinity;
    private Rigidbody2D body;
    private Animator anima;
    private CapsuleCollider2D originalCollider;
    private float horizontalInput;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpNoise;
    [SerializeField] private AudioSource run;

    public bool facingLeft = true; //checks if character is facing left
    public GameObject timer;
    private float oldJumpness;
    private float oldSpeed;
    public float TimeValue = 0;

    public bool isFrozen;


    //GET REFERENCES FOR RIGIDBODY AND ANIMATOR FROM GAME OBJECT 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        originalCollider = GetComponent<CapsuleCollider2D>();
        oldJumpness = jumpness;
        oldSpeed = speed;
    }

    void Update()
    {
        TimeValue += Time.deltaTime;  
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
      
        if(TimeValue >= 8 && TimeValue <= 15)
        {
            speed = 0f;
            jumpness = 0f;
            Grey.SetActive(true);
            isFrozen = true;
        }
        else if(TimeValue >= 15 && TimeValue <= 22)
        {
            speed = oldSpeed;
            jumpness = oldJumpness;
            Grey.SetActive(false);
            isFrozen = false;
        }

        if(TimeValue >= 22 && TimeValue <= 32)
        {
            speed = 0f;
            jumpness = 0f;
            Grey.SetActive(true);
            isFrozen = true;
        }
        else if(TimeValue >= 32 && TimeValue <= 42)
        {
            speed = oldSpeed;
            jumpness = oldJumpness;
            Grey.SetActive(false);
            isFrozen = false;
        }

        if(TimeValue >= 42 && TimeValue <= 55)
        {
            speed = 0f;
            jumpness = 0f;
            Grey.SetActive(true);
            isFrozen = true;
        }
        else if(TimeValue >= 55)
        {
            speed = oldSpeed;
            jumpness = oldJumpness;
            Grey.SetActive(false);
            isFrozen = false;
        }

        //FLIPS PLAYER SPRITE WHEN MOVING LEFT / RIGHT
        if(horizontalInput < 0 && !facingLeft && !isFrozen)
            flip();
        else if(horizontalInput > 0 && facingLeft && !isFrozen)
            flip();


        //Play Run Sound
        if ((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow)))
        {
            run.Play();
        }

        if ((Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow)))
        {
            run.Stop();
        }

        //SETTING ANIMATOR PARAMETERS
        anima.SetBool("run", horizontalInput != 0);
        anima.SetBool("grounded", isGrounded());

        if(isGrounded() && cooldownTimer > jumpCooldown)        
        {
            if((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)))
            {
                Jump();       
            }
        }
        cooldownTimer += Time.deltaTime;
    }

    private void flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(0f, 180f, 0f);
    }

        private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpness);
        anima.SetTrigger("jump");
        SoundManager.instance.PlaySound(jumpNoise);
        cooldownTimer = 0;
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(originalCollider.bounds.center, originalCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }

    public bool midAir()
    {
        return !isGrounded();
    }
}