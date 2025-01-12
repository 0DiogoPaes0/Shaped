using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[Header("Movement")]
    //[SerializeField] private float _gravityForce;
    //[SerializeField] private float _playerGravity;
    //[SerializeField] private float _fallGravityMult;
    //[SerializeField] private float _maxFallSpeed;
    //[SerializeField] private float _fastFallGravityMult;
    //[SerializeField] private float _maxFastFallSpeed;

    //[Header("Run")]
    //[SerializeField] private float _runMaxSpeed;
    //[SerializeField] private float _runAcceleration;
    //[SerializeField] private float _runAccelAmount;
    //[SerializeField] private float _runDecceleration;
    //[SerializeField] private float _runDeccelAmount;
    //[SerializeField] private float _accelInAir;
    //[SerializeField] private float _deccelInAir;
    //[SerializeField] private bool _doConserveMomentum = true;

    //[Header("Jump")]
    //[SerializeField] private float _jumpHeight;
    //[SerializeField] private float _jumpTimeToApex;
    //[SerializeField] private float _jumpForce;

    //[Header("Both Jumps")]
    //[SerializeField] private float _jumpCutGravityMult;
    //[SerializeField] private float _jumpHangGravityMult;
    //[SerializeField] private float _jumpHangTimeThreshold;
    //[SerializeField] private float _jumpHangAccelerationMult;
    //[SerializeField] private float _jumpHangMaxSpeedMult;

    //[Header("Wall Jump")]
    //[SerializeField] private Vector3 _wallJumpForce;
    //[SerializeField] private float _wallJumpRunLerp;
    //[SerializeField] private float _wallJumpTime;
    //[SerializeField] private bool _doTurnOnWallJump;

    //[Header("Slide")]
    //[SerializeField] float _slideSpeed;
    //[SerializeField] float _slideAccel;

    //[Header("Assists")]
    //[SerializeField] private float _coyoteTime;
    //[SerializeField] private float _JumpInputBUfferTime;

    public int lives = 3;
    public float speed = 5f;
    public float jumpForce = 5f;
    public Material[] materials;
    public float invincibilityTime = 1f;
    public Material invincibilityMaterial;
    private Rigidbody rb;
    private bool isGrounded = true;
    private int materialIndex = 0;
    public bool isInvincible = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeMaterial();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            isGrounded = false;
        }

        if (Input.GetKeyDown(KeyCode.C) && !isInvincible)
        {
            materialIndex = (materialIndex + 1) % materials.Length;
            ChangeMaterial();
        }

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveX, 0, moveZ) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    private void ChangeMaterial()
    {
        GetComponent<MeshRenderer>().material = materials[materialIndex];
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
        if (!isInvincible)
        {
            lives--;
            Debug.Log($"Player Lives: {lives}");

            if (lives <= 0)
            {
                Debug.Log("Player is Dead!");
            }

            StartCoroutine(ActivateInvincibility());
        }
    }

    private System.Collections.IEnumerator ActivateInvincibility()
    {
        isInvincible = true;

        if (invincibilityMaterial != null)
        {
            GetComponent<MeshRenderer>().material = invincibilityMaterial;
        }

        yield return new WaitForSeconds(invincibilityTime);

        isInvincible = false;
        ChangeMaterial();
    }
}
