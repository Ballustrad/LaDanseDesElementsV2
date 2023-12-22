using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform[] patrolPoints;
    public float detectionRange = 10f;
    public LayerMask playerLayer;
    public float chaseSpeed = 5f;
    public float rotationSpeed = 5f;

    private NavMeshAgent navMeshAgent;
    private Transform player;
    private int currentPatrolIndex = 0;
    private bool isPatrolling = true;
    private bool canShoot = true;
    public GameObject projectilePrefab;
    public float shootingDistance = 10.0f;
    public float shootingCooldown = 2.0f;
    [SerializeField] AudioSource audiosource;
    [SerializeField] AudioClip attacksound;
    
    [SerializeField] AudioClip triggered;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.autoBraking = false; // Pour permettre des mouvements continus
        SetNextPatrolPoint();
    }

    void Update()
    {
        if (isPatrolling)
        {
            if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
            {
                SetNextPatrolPoint();
            }
            CheckForPlayer();
        }
        else
        {
            ChasePlayer();
            RotateTowardsPlayer();
        }
        if (!isPatrolling)
        {
            if (player != null)
            {
                float distanceToPlayer = Vector3.Distance(transform.position, player.position);

                if (distanceToPlayer <= shootingDistance)
                {
                    navMeshAgent.isStopped = true; // Arrête le déplacement via NavMeshAgent

                    // Rotate towards the player
                    Vector3 targetDirection = player.position - transform.position;
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
                    navMeshAgent.isStopped = false; // Reprend le déplacement via NavMeshAgent
                    navMeshAgent.SetDestination(player.position); // Définit la destination du NavMeshAgent vers le joueur
                }
            }
        }
    }

    void SetNextPatrolPoint()
    {
        if (patrolPoints.Length == 0) return;

        navMeshAgent.destination = patrolPoints[currentPatrolIndex].position;
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
    private bool detected;
    void CheckForPlayer()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, detectionRange, playerLayer);
        
        if (hitColliders.Length > 0 && !detected)
        {
            if (audiosource != null && triggered != null)
            {
                // Joue le son depuis l'AudioSource du soundManager
                audiosource.PlayOneShot(triggered);
            }
            player = hitColliders[0].transform;
            detected = true;
            isPatrolling = false;
        }

    }
    private void Shoot()
    {
        if (audiosource != null && attacksound != null)
        {
            // Joue le son depuis l'AudioSource du soundManager
            audiosource.PlayOneShot(attacksound);
        }
        // Instantiate the projectile and set its direction towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Vector3 direction = (player.position - transform.position) + new Vector3(0, 1, 0).normalized;
        projectile.GetComponent<EnemyProjectile>().SetDirection(direction);
    }

    private void ResetShootingCooldown()
    {
        canShoot = true;
    }
    void ChasePlayer()
    {
        if (player == null) return;
        
        navMeshAgent.destination = player.position;
        navMeshAgent.speed = chaseSpeed;
        navMeshAgent.isStopped = false;
    }

    void RotateTowardsPlayer()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }

    // Fonction pour attaquer le joueur (à implémenter)
    void AttackPlayer()
    {
        // Logique pour attaquer le joueur
    }

    // Fonction pour prendre des dégâts (à implémenter)
 
}
