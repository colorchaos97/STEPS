using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle : MonoBehaviour
{
    Rigidbody2D rbCircle;

    [SerializeField] private float maxvelocidad=5f;
    [SerializeField] private float fuerzamov=5f;
    [SerializeField] private float fuerzaJump=5f;
    private bool grounded=true;
    

    // Start is called before the first frame update
    void Start()
    {
        rbCircle=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow)&&rbCircle.velocity.x>-maxvelocidad)
        { 
            rbCircle.AddForce (new Vector2 (-fuerzamov,0),ForceMode2D.Force);
        }
        if (Input.GetKey(KeyCode.RightArrow)&&rbCircle.velocity.x<maxvelocidad)
        { 
            rbCircle.AddForce (new Vector2 (fuerzamov,0),ForceMode2D.Force);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded)
        { 
            rbCircle.AddForce (new Vector2(0,fuerzaJump));
            grounded= false;
        }    
    }
    void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.tag == "suelo")
        {
            grounded=true;
        }
    }
}
