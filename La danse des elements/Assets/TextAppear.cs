using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAppear : MonoBehaviour
{
    public GameObject worldText;

    private void OnTriggerEnter(Collider other)
    {
        worldText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        worldText.SetActive(false);
    }
}
