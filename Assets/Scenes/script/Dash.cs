using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField] private TrailRenderer tr;
    public bool isDashing = false;
    float horizontal_value;
    float vertical_value;
    [SerializeField] float moveSpeed_horizontal = 400.0f;

    // Vitesse de déplacement du joueur
    public float moveSpeed = 5f;
    // Distance maximale de deplacement lors du dash
    public float dashDistance = 5f;
    // Temps de recharge du dash en secondes
    public float dashCooldown = 0f;
    // Direction du dash
    private Vector2 dashDirection;
    // Temps restant avant de pouvoir utiliser le dash à nouveau
    private float dashCooldownTimer = 0f;

    public Sprite defaultSprite;
    public Sprite dashSprite;
    private SpriteRenderer spriteRenderer;
    private Transform spriteTransform;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
    }

    // Update is called once per frame
    void Update()
    {
        // Si le dash est en cours de recharge, mettre a jour le temps restant
        if (dashCooldownTimer > 0)
        {
            dashCooldownTimer -= Time.deltaTime;
        }

        // Sinon, permettre au joueur d'utiliser le dash
        else
        {
            // Recuperer le vecteur de direction
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");
            Vector2 direction = new Vector2(horizontal, vertical).normalized;

            // Si le joueur appuie sur la touche de dash et que la direction est valide
            if (Input.GetButtonDown("Dash") && direction != Vector2.zero)
            {
                // Normaliser la direction pour éviter les deplacements excessifs en diagonale
                if (direction.magnitude > 1f)
                {
                    direction.Normalize();
                }

                // Stocker la direction pour le dash
                dashDirection = direction;

                // Mettre en place le temps de recharge du dash
                dashCooldownTimer = dashCooldown;
                tr.emitting = true;
                isDashing = true;
                // Changer le sprite renderer pour le sprite de dash
                spriteRenderer.sprite = dashSprite;

                Invoke("RestoreDefaultSprite", 0.5f);

                //devenir invincible pendant le Dash
                this.GetComponentInParent<playerHealth>().imune = true;
                StartCoroutine(Dashing());
               
            }

        }
        if (Input.GetButtonUp("Dash"))
        {
            tr.emitting = false;
        }
    }
    
    private IEnumerator Dashing()
    {
        yield return new WaitForSeconds(0.2f);
        isDashing = false;
        spriteRenderer.sprite = defaultSprite;
        this.GetComponentInParent<playerHealth>().imune = false ;
    }

    void FixedUpdate()
    {
        // Si le joueur est en train de dasher, le déplacer
        if (dashDirection != Vector2.zero)
        {
            //transform.position += dashDirection * dashDistance; //ca marche aussi avec ca mais ca te tp dans le sol

            //rb.velocity = dashDirection * dashDistance / Time.fixedDeltaTime; //envoie trop loin

            Vector2 targetPosition = rb.position + dashDirection * dashDistance; //CA MARCHE FINALEMENT

            rb.MovePosition(targetPosition);

            // Réinitialiser la direction du dash
            dashDirection = Vector2.zero;
        }
        // Sinon, deplacer le joueur normalement
        else
        {
            Vector2 target_velocity = new Vector2(horizontal_value * moveSpeed_horizontal * Time.fixedDeltaTime, rb.velocity.y);
            return;
        }

        if (dashDirection != Vector2.zero)
        {
            Vector2 targetPosition = rb.position + dashDirection * dashDistance;
            rb.MovePosition(targetPosition);

            if (dashDirection.x != 0f)
            {
                spriteTransform.localScale = new Vector3(Mathf.Sign(dashDirection.x), 1f, 1f);
            }
        }
         

    }
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteTransform = GetComponent<Transform>();
    }
}