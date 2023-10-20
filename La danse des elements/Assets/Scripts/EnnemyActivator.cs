using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnnemyActivator : MonoBehaviour
{
    public GameObject ennemy1;
    public GameObject ennemy2;
    public GameObject ennemy3;
    private void OnTriggerEnter(Collider other)
    {
        ennemy1.SetActive(true);
        ennemy2.SetActive(true);
        ennemy3.SetActive(true);
    }
}
