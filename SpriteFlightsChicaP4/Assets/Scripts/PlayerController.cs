using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject boosterFlame;
    public float thrustForce = 1f;
    public float maxSpeed = 5f;
    
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            //calculate mouse direction and move player in that direction
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.value);
            Vector2 direction = mousePosition - transform.position;

            //Move player in direction of mouse click
            transform.up = direction;
            rb.AddForce(direction * thrustForce);

            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
            boosterFlame.SetActive(true);
            }
            else if (Mouse.current.leftButton.wasReleasedThisFrame)
            {
            boosterFlame.SetActive(false);
            }

            if (rb.linearVelocity.magnitude > maxSpeed)
            {
                rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
            }
        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}