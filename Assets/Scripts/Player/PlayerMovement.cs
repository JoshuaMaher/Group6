using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour 
{
    [SerializeField] public float speed;
    [SerializeField] private float jumpness;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float jumpCooldown;
    private float cooldownTimer = Mathf.Infinity;
    private Rigidbody2D body;
    private Animator anima;
    private CapsuleCollider2D originalCollider;
    private float horizontalInput;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpNoise;

    public bool facingLeft = true; //checks if character is facing left

    

    //GET REFERENCES FOR RIGIDBODY AND ANIMATOR FROM GAME OBJECT 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        originalCollider = GetComponent<CapsuleCollider2D>();
        
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
      

        //FLIPS PLAYER SPRITE WHEN MOVING LEFT / RIGHT
        if(horizontalInput < 0 && !facingLeft)
            flip();
        else if(horizontalInput > 0 && facingLeft)
            flip();

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
