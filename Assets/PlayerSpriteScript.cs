using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpriteScript : MonoBehaviour
{
    public Sprite[] sprites;
    Transform parent;
    SpriteRenderer spriteRenderer;
    
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parent = transform.parent;
    }
    
    void Update()
    {
        transform.rotation = Quaternion.identity;

        float angle = -parent.GetComponent<PlayerMovement>().angle + 180;
        angle = angle / 45;
        if (angle >= 7.5) angle -= 8;
        
        spriteRenderer.sprite = sprites[Mathf.RoundToInt(angle)];
    }
}
