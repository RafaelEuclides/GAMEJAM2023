using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private Animator an;

    Rigidbody rb;
    public float JumpForce;
    public float speed;
    public float fallJump;

    public LayerMask Layermask;
    public bool IsGrounded;
    public float GroundCheckSize;
    public Vector3 GroundCheckPosition;


    // Start is called before the first frame update
    void Start()
    {
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var groundCheck = Physics.OverlapSphere(transform.position + GroundCheckPosition, GroundCheckSize, Layermask);
        if(groundCheck.Length !=0)
        {
            IsGrounded = true;
            an.SetBool("Jump", false);
        }
        else
        {
            IsGrounded = false;
            an.SetBool("Jump", true);
        }
       
        if(IsGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }

        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (fallJump - 1) * Time.deltaTime;
        }
    }    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + GroundCheckPosition, GroundCheckSize);
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction =  new Vector3(horizontal, 0 , vertical); 
        //rb.MovePosition(transform.position + direction * speed * Time.deltaTime);

        if(horizontal != 0 || vertical != 0)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            an.SetBool("Walk", true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(direction), 50 * Time.deltaTime);
        }
        if(horizontal == 0 && vertical == 0)
        {
            an.SetBool("Walk", false);
        }

    }

}
