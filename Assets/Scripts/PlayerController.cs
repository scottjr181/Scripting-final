using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public Animator Anim;
    public float jumpforce;

    private float Vertical;
    private float Horizontal;

    private bool isFacingRight;

    public LayerMask groundLayer;

    public float groundCheckValue;

    public bool isGrounded = false;

    public GameObject rayCastObject;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        Anim = this.GetComponent<Animator>();
    }

    void input()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");
    }

    // Update is called once per frame
    void Update()
    {
        input();
        Jump();
        GroundCheck();
    }

    private void GroundCheck()
    {
       // Debug.DrawRay(rayCastObject.transform.position, Vector3.down * groundCheckValue, Color.red);
        if (Physics.Raycast(rayCastObject.transform.position, Vector3.down, groundCheckValue, groundLayer))
        {
            if (isGrounded == false)
            {
                Anim.SetBool("Jump", false);
            }
            isGrounded = true;
        }
        else
        {
            isGrounded = false;

        }



    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.velocity = new Vector3(Horizontal * Time.deltaTime * speed, rb.velocity.y, rb.velocity.z);
        Anim.SetFloat("Speed", Mathf.Abs(Horizontal));
        Rotate();
    }

    private void Rotate()
    {
        if (Horizontal > 0 && !isFacingRight)
        {
            this.transform.rotation = Quaternion.Euler(0f, 90f, 0f);
            isFacingRight = true;
        }
        else if (Horizontal < 0 && isFacingRight)
        {
            this.transform.rotation = Quaternion.Euler(0f, 270f, 0f);
            isFacingRight = false;
        }
    }
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpforce, ForceMode.Impulse);
            Anim.SetBool("Jump", true);
        }
    }
}
