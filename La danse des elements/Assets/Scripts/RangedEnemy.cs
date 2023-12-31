using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RangedEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float shootingDistance = 10.0f;
    public float shootingCooldown = 2.0f;
    public Transform target;
    private bool canShoot = true;
    public NavMeshAgent agent;
    public Transform playerTransform;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (playerTransform == null)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, playerTransform.position);

        if (distanceToPlayer <= shootingDistance)
        {
            agent.isStopped = true; // Arr�te le d�placement via NavMeshAgent

            // Rotate towards the player
            Vector3 targetDirection = playerTransform.position - transform.position;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime);

            if (canShoot)
            {
                Shoot();
                canShoot = false;
                Invoke("ResetShootingCooldown", shootingCooldown);
            }
        }
        else
        {
            agent.isStopped = false; // Reprend le d�placement via NavMeshAgent
            agent.SetDestination(playerTransform.position); // D�finit la destination du NavMeshAgent vers le joueur
        }
    }
   
    private void Shoot()
    {
        // Instantiate the projectile and set its direction towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (playerTransform.position - transform.position) + new Vector3(0, 1, 0).normalized;
        projectile.GetComponent<EnemyProjectile>().SetDirection(direction);
       
    }

    private void ResetShootingCooldown()
    {
        canShoot = true;
    }
}

