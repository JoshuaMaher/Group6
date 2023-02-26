using UnityEngine;
using System.Collections;


public class PlayerMovement : MonoBehaviour 
{
    //public float speed = 5; ? ? ? 
    [SerializeField] private float speed;
    [SerializeField] private float jumpness;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody2D body;
    private Animator anima;
    private BoxCollider2D boxCollider;
    private float horizontalInput;

    [Header("Audio")]
    [SerializeField] private AudioClip jumpNoise;
  

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
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);
      

        //FLIPS PLAYER SPRITE WHEN MOVING LEFT / RIGHT
        if(horizontalInput > 0.01f)
            transform.localScale = new Vector3(2,2,2);
        else if(horizontalInput < -0.01f)
            transform.localScale = new Vector3(-2,2,2);

       

        //SETTING ANIMATOR PARAMETERS
        anima.SetBool("run", horizontalInput != 0);
        anima.SetBool("grounded", isGrounded());

                
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow)) && isGrounded())
        {
            Jump();       
        }
    }
    
    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, jumpness);
        anima.SetTrigger("jump");
        SoundManager.instance.PlaySound(jumpNoise);
    }


    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.1f, groundLayer);

        return raycastHit.collider != null;
    }
}
