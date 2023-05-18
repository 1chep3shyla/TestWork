using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float detectionRadius = 10f;
    public float attackRadius = 2f;
    public float movementSpeed = 5f;
    public float attackDelay = 2f;
    public int attackDamage = 10;

    private GameObject player;
    private bool isAttacking = false;
    private bool canAttack = true;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (player == null)
        {
            return;
        }

        float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            if (distanceToPlayer > attackRadius)
            {
                MoveTowardsPlayer();
            }
            else
            {
                AttackPlayer();
            }
        }
    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = player.transform.position - transform.position;
        transform.Translate(direction.normalized * movementSpeed * Time.deltaTime, Space.World);
    }

    private void AttackPlayer()
    {
        if (!canAttack || isAttacking)
        {
            return;
        }

        StartCoroutine(AttackDelay());
        isAttacking = true;

        // Perform attack logic here
        Debug.Log("Enemy attacked player!");

        // Apply damage to the player
        Player playerHealth = player.GetComponent<Player>();
        if (playerHealth != null)
        {
            playerHealth.TakeDamage(attackDamage);
        }

        // Reset attack state after attack delay
        Invoke(nameof(ResetAttack), attackDelay);
    }

    private IEnumerator AttackDelay()
    {
        canAttack = false;
        yield return new WaitForSeconds(attackDelay);
        canAttack = true;
    }

    private void ResetAttack()
    {
        isAttacking = false;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}