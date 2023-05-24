using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public const float V = 10f;
    public float moveSpeed = 5f; // vitesse de déplacement
    public float jumpForce = 10f; // force de saut
    public Transform groundCheck; // objet qui vérifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    private Rigidbody2D rb;
    private bool isGrounded = false;

    CapsuleCollider2D CapsulPlayer;

    public bool canJump = true;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;
    }

    void Update()
    {
        // vérifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        // déplacement horizontal
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Turn
        if (moveInput != 0)
        {
            if (moveInput > 0)
            {
                transform.localScale = new Vector2(0.53f, 0.53f); // tourne le personnage à droite
            }
            else
            {
                transform.localScale = new Vector2(-0.53f, 0.53f); // tourne le personnage à gauche
            }
        }


        // saut
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded && canJump == true)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {


        isGrounded = true;
        CapsulPlayer.sharedMaterial.friction = V;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        isGrounded = false;
        CapsulPlayer.sharedMaterial.friction = 0;
        CapsulPlayer.enabled = false;
        CapsulPlayer.enabled = true;


    }

}
