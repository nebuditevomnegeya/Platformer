using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    private Rigidbody2D rb2d;
    private Animator animator;
    [SerializeField] private float WalkSpeed;
    // Start is called before the first frame update
    void Start()
    {
         rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(move* WalkSpeed, rb2d.velocity.y);
        if (move != 0)
        {
            animator.Play("Walk");
            transform.localScale = new Vector3(move > 0 ? 1 : -1, 1, 1); 
        }
        else
        {
            animator.Play("Walk");
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.Play("Jump");
        }

    }
}
