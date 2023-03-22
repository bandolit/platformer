using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float moveSpeed = 5f; // vitesse de d�placement
    public float jumpForce = 10f; // force de saut
    public Transform groundCheck; // objet qui v�rifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    private Rigidbody2D rb;
    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
    }

    void Update()
    {
        // v�rifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // d�placement horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Turn
        if (moveInput != 0)
        {
            if (moveInput > 0)
            {
                transform.localScale = new Vector2(1f, 1f); // tourne le personnage � droite
            }
            else
            {
                transform.localScale = new Vector2(-1f, 1f); // tourne le personnage � gauche
            }
        }


        // saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
