using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject[] energyFragments;
    public HealthBar healthBar;
    public ExamplePlayer player;
    public int numberofDotFire = 0;
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

        if (Time.time - lastDotTick >= 1f)
        {
            InflictDotDmg();
            lastDotTick = Time.time;
        }
        //Pour que la vie n'aille pas en dessous de 0
        if (currentHealth < 0) { currentHealth = 0; }
        //Pour que la vie n'aille pas au dessus du MaxHealth
        if (currentHealth > maxHealth) { currentHealth = maxHealth; }
        print(numberofDotFire);
        //Tue le joueur si sa vie atteint 0
        if (currentHealth == 0) { Death(); }
    }
    public float fireDOTdmg = 0;    
    public float lastDotTick = 0;
    public void InflictDotDmg()
    {
        fireDOTdmg = 0;
        fireDOTdmg = numberofDotFire * (currentHealth / 100f);
        TakeDamage(fireDOTdmg);
    }

    
    public void addFireDot()
    {
        StartCoroutine(GetDOTFire());
    }
    public IEnumerator GetDOTFire()
    {
        numberofDotFire ++;
        yield return new WaitForSeconds(3f);
        numberofDotFire--;
    }
    public void TakeDamage(float damage)
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
        

        // Instancie un fragment d'�nergie al�atoire � la position de l'ennemi
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
