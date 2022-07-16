using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float dashForce;
    public float dashCooldown;
    [HideInInspector] public float angle;

    float dashTimer;
    Rigidbody2D rb;
    Vector2 movementInput;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        dashTimer = dashCooldown;
    }
    
    void Update()
    {
        
        movementInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        // transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);

        RotateTowardsMouse();

        dashTimer += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space) && dashTimer >= dashCooldown) Dash();
    }
    private void FixedUpdate()
    {
        rb.AddForce(movementInput * speed);
    }

    void Dash()
    {
        rb.AddForce(rb.velocity.normalized * dashForce);
        dashTimer = 0;
    }

    void RotateTowardsMouse()
    {
        var mousePosition = Input.mousePosition;
        var objectScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var direction = mousePosition - objectScreenPosition; // No need to normalize btw
        angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}
