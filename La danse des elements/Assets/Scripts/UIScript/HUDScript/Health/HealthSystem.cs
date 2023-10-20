using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public GameObject[] energyFragments;
    public HealthBar healthBar;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadMinus))
        {
            TakeDamage(20);
        }
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            Death();
        }
        if (Input.GetKeyDown(KeyCode.KeypadPlus))
        {
           HealHealth(20);
        }

        //Pour que la vie n'aille pas en dessous de 0
        if (currentHealth < 0) { currentHealth = 0; }
        //Pour que la vie n'aille pas au dessus du MaxHealth
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }

        //Tue le joueur si sa vie atteint 0
        if (currentHealth == 0) { Death(); }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }
    private void Death()
    {
        int randomIndex = Random.Range(0, energyFragments.Length);

        // Instancie un fragment d'énergie aléatoire à la position de l'ennemi
        GameObject energyFragment = Instantiate(energyFragments[randomIndex], transform.position, Quaternion.identity);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    void HealHealth(int damage)
    {
        currentHealth += damage;

        healthBar.SetHealth(currentHealth);
    }
}
