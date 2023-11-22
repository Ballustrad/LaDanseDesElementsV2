using KinematicCharacterController.Examples;
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
    public ExamplePlayer player;
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
        switch (player.currentElement)
        {
            case 1:
                GameObject energyFragmentEarth = Instantiate(energyFragments[2], transform.position, Quaternion.identity);
                break;

            case 2:
                GameObject energyFragmentWater = Instantiate(energyFragments[3], transform.position, Quaternion.identity);
                break;
            case 3:
                GameObject energyFragmentWind = Instantiate(energyFragments[4], transform.position, Quaternion.identity);
                break;
            case 4:
                GameObject energyFragmentFire = Instantiate(energyFragments[1], transform.position, Quaternion.identity);
                break;
            default: break;
        }
        

        // Instancie un fragment d'énergie aléatoire à la position de l'ennemi
        //GameObject energyFragment = Instantiate(energyFragments[randomIndex], transform.position, Quaternion.identity);
        //this.gameObject.SetActive(false);
        Destroy(this.gameObject);
    }
    void HealHealth(int damage)
    {
        currentHealth += damage;

        healthBar.SetHealth(currentHealth);
    }
}
