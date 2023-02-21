using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour 
{
    //public float speed = 5; ? ? ? 
    [SerializeField] private float speed;
    [SerializeField] private float jumpness;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;
    private Rigidbody2D body;
    private Animator anima;
    private BoxCollider2D boxCollider;
    private float walljumpCooldown;
    private float horizontalInput;

    [Header("Dash")]
    public float dashSpeed;
    public float dashTime;
    private float dashCooldown;
    public float resetDashCooldown;

    [Header("Audio")]
    [SerializeField] AudioClip jumpNoise;
    [SerializeField] AudioClip dashNoise;
  

    //GET REFERENCES FOR RIGIDBODY AND ANIMATOR FROM GAME OBJECT 
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
      

        //FLIPS PLAYER SPRITE WHEN MOVING LEFT / RIGHT
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(2,2,2);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2,2,2);

       

        //SETTING ANIMATOR PARAMETERS
        anima.SetBool("run", horizontalInput != 0);
        anima.SetBool("grounded", isGrounded());

        //WALL JUMP LOGIC
        if(walljumpCooldown > 0.2f)
        {
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if(onWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;
                
                if(Input.GetKey(KeyCode.Space))
                {
                    Jump();

                    if(Input.GetKeyDown(KeyCode.Space) && isGrounded())
                         SoundManager.instance.PlaySound(jumpNoise);
                }
                
        }
        else
            walljumpCooldown += Time.deltaTime;


        // START THE COOLDOWN TIMER FOR DASH
        dashCooldown -= Time.deltaTime;
        // STOPS TIMER WHEN COOLDOWN IS READY
        if (dashCooldown < 0)
        {
            dashCooldown = -1;
        } 
        else 
        {
            dashCooldown -= Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.V)) 
        {
            if (dashCooldown <= 0) 
            {
                StartCoroutine(Dash());

                if(Input.GetKeyDown(KeyCode.V))
                    SoundManager.instance.PlaySound(dashNoise);
            }

             
        }
    }

       private IEnumerator Dash()
        {

        float startTime = Time.time;
        float localScaleX = transform.localScale.x;
   
        while (Time.time < startTime + dashTime) 
        {

            float movementSpeed = dashSpeed * Time.deltaTime;

            if (Mathf.Sign(localScaleX) == 1) 
            {
                transform.Translate(movementSpeed, 0, 0);
            } 
            else 
            {
                transform.Translate(-movementSpeed, 0, 0);
            }
           
            dashCooldown = resetDashCooldown;
            yield return null;
        }

        }


    private void Jump()
    {
        if(isGrounded())
        {
            body.velocity = new Vector2(body.velocity.x, jumpness);
            anima.SetTrigger("jump");   
        }
        else if(onWall() && !isGrounded())
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);
                transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, transform.localScale.z);

                //ADDED THIS LINE BECAUSE X SCALE KEPT CHANGING TO 1
             
            }
            else
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 6);

            walljumpCooldown = 0;
        } 
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }

     private bool onWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.1f, wallLayer);

        return raycastHit.collider != null;
    }

    public bool canAttack()
    {
        return horizontalInput == 0 && isGrounded() && !onWall();
    }
}
