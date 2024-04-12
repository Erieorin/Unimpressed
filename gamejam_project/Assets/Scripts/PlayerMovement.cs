using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] public float moveSpeed;
    public Rigidbody2D rb;
    public bool grounded;
    public static bool _isFacingRight = false;


    void Update()
    {
        float hor = Input.GetAxisRaw("Horizontal"); //��������� �����������
        rb.velocity = new Vector2(hor * moveSpeed, rb.velocity.y); //��������

        // ������������� ������ 
        if (hor > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        if (hor < -0.01f)
        {  transform.localScale = new Vector3(-1, 1, 1);}
        
        // ������
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            Jump();
        }
    }

    private void Turn()
    {
        if (_isFacingRight)
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 180f, transform.rotation.z);
            //transform.position = Quaternion.Euler(rotator);
            _isFacingRight = false;
        }

        else
        {
            Vector3 rotator = new Vector3(transform.rotation.x, 0f, transform.rotation.z);
            //transform.position = Quaternion.Euler(rotator);
            _isFacingRight = true;
        }
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, moveSpeed);
        grounded = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }



}