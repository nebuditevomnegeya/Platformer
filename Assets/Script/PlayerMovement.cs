using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float walkSpeed = 5f;
    private Rigidbody2D rb2d;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask groundLayer;

    public bool isGrounded;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(move * walkSpeed, rb2d.velocity.y);

        if (move != 0)
        {
            transform.localScale = new Vector3(move > 0 ? 1 : -1, 1, 1);
        }

        // isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // Для зручності — відобразити радіус в сцені
    private void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
        }
    }

     void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.CompareTag("GroundLayer"))
        {
            isGrounded = true;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        if (other.gameObject.CompareTag("GroundLayer"))
        {
            isGrounded = false;
        }
    }
}