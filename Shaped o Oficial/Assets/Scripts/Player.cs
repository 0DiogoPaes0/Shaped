using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField] private float _speed;
    ////[SerializeField] private float _groundDistance;

    ////[SerializeField] private LayerMask _terrainLayer;
    //private Rigidbody _rb;

    //private void Awake()
    //{
    //    _rb = GetComponent<Rigidbody>();
    //}

    //private void Update()
    //{
    //    Movement();
    //}

    //private void Movement()
    //{
    //    float x = Input.GetAxis("Horizontal");
    //    float y = Input.GetAxis("Vertical");
    //    Vector3 moveDir = new Vector3(x, 0, y);
    //    _rb.velocity = moveDir * _speed;
    //}



    public int lives = 3;
    public float speed = 5f;
    public float jumpForce = 5f;
    private Rigidbody rb;
    private bool isGrounded = true;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }


    public void LoseLife()
    {
        lives--;
        Debug.Log($"Player Lives: {lives}");

        if (lives <= 0)
        {
            Debug.Log("Player is Dead!");
        }
    }
}
