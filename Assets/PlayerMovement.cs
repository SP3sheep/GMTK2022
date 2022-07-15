using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal") * speed * Time.deltaTime, Input.GetAxis("Vertical") * speed * Time.deltaTime, 0);

        // transform.LookAt(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.up);

        RotateTowardsMouse();
    }

    void RotateTowardsMouse()
    {
        var mousePosition = Input.mousePosition;
        var objectScreenPosition = Camera.main.WorldToScreenPoint(transform.position);
        var direction = mousePosition - objectScreenPosition; // No need to normalize btw
        var angle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(new Vector3(0, 0, -angle));
    }
}
