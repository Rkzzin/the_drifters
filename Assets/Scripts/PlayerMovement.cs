using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float maxSpeed = 10f;
    public float steerSpeed = 250f;
    [Range(0.1f, 1.0f)] public float lateralFriction = 0.5f;

    private Rigidbody2D rb;
    private Vector2 moveInput;
    private AudioSource audioSource;
    public CoinSpawner spawner;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        rb.gravityScale = 0f;
        rb.angularDamping = 2.0f; 
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        float thrust = moveInput.y * speed;
        rb.AddForce(transform.up * thrust);

        float steerAmount = -moveInput.x * steerSpeed * (rb.linearVelocity.magnitude / maxSpeed);
        rb.MoveRotation(rb.rotation + steerAmount * Time.fixedDeltaTime);

        Vector2 lateralVelocity = transform.right * Vector2.Dot(rb.linearVelocity, transform.right);
        rb.AddForce(-lateralVelocity * lateralFriction, ForceMode2D.Force);

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Moeda") && !GameController.gameOver)
        {
            if (audioSource) audioSource.Play();
            GameController.CollectableCollected();
            if (spawner != null) spawner.SpawnNewCoin();
        
            Destroy(other.gameObject);
        }
    }
}