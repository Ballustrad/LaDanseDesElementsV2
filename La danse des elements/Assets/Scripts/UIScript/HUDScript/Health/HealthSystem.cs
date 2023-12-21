using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth;
    public GameObject[] energyFragments;
    public HealthBar healthBar;
    public ExamplePlayer player;
    public int numberofDotFire = 0;
    public NavMeshAgent navMeshAgent;

    private void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if ( hasEvaporate == true )
        {
            evaporateTimer -= Time.deltaTime;
        }
        if ( evaporateTimer < 0 )
        {
            hasEvaporate = false;
        }
        if (isWet == true && numberofDotFire > 0 && hasEvaporate == false)
        {
            Evaporate();
        }
        print(isWet);
        
        while (isWet == true)
        {
            navMeshAgent.speed = navMeshAgent.speed - 3f;
            isWetTimer -= Time.deltaTime;
            if (isWetTimer < 0) 
            { 
                isWet = false;
                navMeshAgent.speed = 11;
            }
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
    public bool hasEvaporate;
    public float evaporateTimer;
    public void Evaporate()
    {
        TakeDamage(20);
        hasEvaporate = true;
        evaporateTimer = 5f;
    }
    public float fireDOTdmg = 0;    
    public float lastDotTick = 0;
    public void InflictDotDmg()
    {
        fireDOTdmg = 0;
        fireDOTdmg = numberofDotFire * (currentHealth / 100f);
        TakeDamage(fireDOTdmg);
    }
    public bool isWet = false;
    public float isWetTimer = 0;
   
    public void WetRefresh()
    {
        if (isWet == false)
        {
            isWet = true;
            isWetTimer = 4;
        }
        if (isWet == true)
        {
            isWetTimer = 4;
        }
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
