using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float _gravityForce;
    [SerializeField] private float _playerGravity;
    [SerializeField] private float _fallGravityMult;
    [SerializeField] private float _maxFallSpeed;
    [SerializeField] private float _fastFallGravityMult;
    [SerializeField] private float _maxFastFallSpeed;

    [Header("Run")]
    [SerializeField] private float _runMaxSpeed;
    [SerializeField] private float _runAcceleration;
    [SerializeField] private float _runAccelAmount;
    [SerializeField] private float _runDecceleration;
    [SerializeField] private float _runDeccelAmount;
    [SerializeField] private float _accelInAir;
    [SerializeField] private float _deccelInAir;
    [SerializeField] private bool _doConserveMomentum = true;

    [Header("Jump")]
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _jumpTimeToApex;
    [SerializeField] private float _jumpForce;

    [Header("Both Jumps")]
    [SerializeField] private float _jumpCutGravityMult;
    [SerializeField] private float _jumpHangGravityMult;
    [SerializeField] private float _jumpHangTimeThreshold;
    [SerializeField] private float _jumpHangAccelerationMult;
    [SerializeField] private float _jumpHangMaxSpeedMult;

    [Header("Wall Jump")]
    [SerializeField] private Vector3 _wallJumpForce;
    [SerializeField] private float _wallJumpRunLerp;
    [SerializeField] private float _wallJumpTime;
    [SerializeField] private bool _doTurnOnWallJump;

    [Header("Slide")]
    [SerializeField] float _slideSpeed;
    [SerializeField] float _slideAccel;

    [Header("Assists")]
    [SerializeField] private float _coyoteTime;
    [SerializeField] private float _JumpInputBUfferTime;


}
