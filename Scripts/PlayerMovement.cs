using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Les Variables
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator anim;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask Ground;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    private enum MovementState { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSoundEffect;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Sa c'est pour aller de droit et gauche
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        // Sa c'est pour sauter
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce );
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
        // Sa c'est pour changer les animations 
    {
        MovementState state;
        //courrir
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false ;
        }
        //courrir l'autre direction
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true; 
        }
        else
        {
            state = MovementState.idle;
        }
        //sauter
        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        //tomber
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);

    }

    private bool isGrounded()
        //Sa c'est pour detecter pour qu'on detect que le ouer a toucher le terre
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, Ground);
    }

}
 