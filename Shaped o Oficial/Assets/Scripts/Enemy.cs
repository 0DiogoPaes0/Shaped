using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float detectionRange = 5f;
    public float moveDistance = 10f;
    public float speed = 2f;

    [SerializeField] private Transform player;
    [SerializeField] private bool isMoving = false;
    [SerializeField] private Vector3 targetPosition;
    [SerializeField] private float moveDirection;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update()
    {
        if (isMoving) return;

        float distanceToPlayer = player.position.x - transform.position.x;

        if (Mathf.Abs(distanceToPlayer) <= detectionRange)
        {
            moveDirection = distanceToPlayer < 0 ? -1 : 1;
            RotateEnemy();
            StartMovement();
        }
    }

    private void RotateEnemy()
    {
        transform.rotation = Quaternion.Euler(0, moveDirection < 0 ? -45 : 45, 0);
    }

    private void StartMovement()
    {
        isMoving = true;
        targetPosition = new Vector3(transform.position.x + (moveDistance * moveDirection), transform.position.y, transform.position.z);
        StartCoroutine(MoveEnemy());
    }

    private System.Collections.IEnumerator MoveEnemy()
    {
        while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }

        transform.rotation = Quaternion.identity;
        isMoving = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player playerScript = collision.gameObject.GetComponent<Player>();
            if (playerScript != null && !playerScript.isInvincible)
            {
                playerScript.LoseLife();
            }
        }
    }
}
