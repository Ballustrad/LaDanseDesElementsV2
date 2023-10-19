using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed = 10.0f;
    public int damage = 10;

    private Vector3 direction;



    private void Awake()
    {

    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void SetDirection(Vector3 dir)
    {
        direction = dir;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("damage " + damage);


            // Destroy the projectile
            Destroy(gameObject);
        }
    }
}
