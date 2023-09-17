using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BasicMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private BoxCollider2D collider;
    private SpriteRenderer sprite;

    private enum MovementState { idle, running, jumping, falling }

    private float horizontalInput;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    [SerializeField] private LayerMask jumpableGround;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Allows player to jump once
        if (Input.GetButtonDown("Jump") && isGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // loads current scene
        }

        UpdateAnimationState();
    }

    void UpdateAnimationState()
    {
        MovementState state;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        // Flip the player sprite everytime they change direction
        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
            //animator.SetInteger("state", 1);
            state = MovementState.running;
            Debug.Log("Running");
        } else {
            //animator.SetInteger("state", 0);
            Debug.Log("Idle");
            state = MovementState.idle;
        }

        // Trigger jump animation or falling animation depending on player's velocity
        if (rb.velocity.y > 0.1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -0.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int) state);
    }

      // checks if player is grounded. Returns true if player is standing on ground,
    // otherwise false if not.
    private bool isGrounded()
    {
        // creates a box around the player that has the same shape as the player's box collider.
        // the box is positioned below the player's feet to check if it overlaps with the ground.
        return Physics2D.BoxCast(collider.bounds.center, collider.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
    }
}
