using KinematicCharacterController.Examples;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemmeActivate : MonoBehaviour
{
    private bool gemEnable = false;
    [SerializeField] ExamplePlayer player;
    [SerializeField] GameObject gem;
    [SerializeField] GameObject bridge1;
    [SerializeField] GameObject bridge2;
    [SerializeField] GameObject bridge3;
    [SerializeField] GameObject bridge4;
    [SerializeField] GameObject bridge5;
    [SerializeField] GameObject bridge6;
    [SerializeField] GameObject bridge7;
    [SerializeField] GameObject bridge8;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && player.hasFragmentKey == true )
        {
            player.interactText.SetActive(true);
            if (  Input.GetKey(KeyCode.X) && !gemEnable)
            {
                gemEnable = true;
                gem.SetActive(true);
                StartCoroutine(ShowBridge());
                player.UpdateQuestText("Traversez le pont");
                player.hasFragmentKey = false;
            }
           
        }
    }
    private IEnumerator ShowBridge()
    {
        bridge1.SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge2.SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge3.SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge4 .SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge5 .SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge6 .SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge7 .SetActive(true);
        yield return new WaitForSeconds(1f);
        bridge8 .SetActive(true);
        player.interactText.SetActive (false);
        
        yield return null;
    }
}
