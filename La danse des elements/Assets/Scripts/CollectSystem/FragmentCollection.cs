using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using KinematicCharacterController.Examples;

public class FragmentCollection : MonoBehaviour, IDataPersistence
{
    public ExamplePlayer examplePlayer;
    private int FireFragments = 0;
    private int WaterFragments = 0;
    private int WindFragments = 0;
    private int RockFragments = 0;

    public GameObject uiFragmentText;
    public bool uiFragmentVisible = false;

    private Vector2 uiFragmentHiddenPosition = new Vector2(-195f, 0f); // Position when hidden
    private Vector2 uiFragmentVisiblePosition = new Vector2(25f, 0f);   // Position when visible

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Fragment"))
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("FireFragment"))
            {
                FireFragments++;
                examplePlayer.currentEnergyFire++;
                
                Debug.Log("Fire Fragments: " + FireFragments);
                Destroy(other.gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("WaterFragment"))
            {
                WaterFragments++;
                examplePlayer.currentEnergyWater++;
                
                Debug.Log("Water Fragments: " + WaterFragments);
                Destroy(other.gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("WindFragment"))
            {
                WindFragments++;
                examplePlayer.currentEnergyWind++;
                
                Debug.Log("Wind Fragments: " + WindFragments);
                Destroy(other.gameObject);
            }
            if (other.gameObject.layer == LayerMask.NameToLayer("RockFragment"))
            {
                RockFragments++;
                examplePlayer.currentEnergyEarth++;
                
                Debug.Log("Rock Fragments: " + RockFragments);
                Destroy(other.gameObject);
            }
        }
    }

    //revoir le deathCount, pas compris pourquoi on ne peut mettre que deathCount
    public void LoadData(GameData data)
    {
        this.FireFragments = data.fireFragments;
        this.WaterFragments = data.waterFragments;
        this.WindFragments = data.windFragments;
        this.RockFragments = data.rockFragments;
    }
    public void SaveData(ref GameData data) 
    {
        data.fireFragments = this.FireFragments;
        data.waterFragments = this.WaterFragments;
        data.windFragments = this.WindFragments;
        data.rockFragments = this.RockFragments;
    }

    private void Update()
    {
        if (Keyboard.current.tabKey.wasPressedThisFrame)
        {
            Debug.Log("Tab is Pressed");
            uiFragmentVisible = !uiFragmentVisible;

            if (uiFragmentVisible)
            {
                // Slide the UI in
                Debug.Log("UI Fragment ON");
                
                StartCoroutine(MoveUITo(uiFragmentVisiblePosition));
            }
            else
            {
                // Slide the UI out
                Debug.Log("UI Fragment OFF");
                StartCoroutine(MoveUITo(uiFragmentHiddenPosition, () => uiFragmentText.SetActive(false)));
            }
        }

        
    }

    private IEnumerator MoveUITo(Vector2 targetPosition, System.Action onComplete = null)
    {
        float duration = 0.5f; // You can adjust the duration as needed
        float elapsedTime = 0f;
        RectTransform rectTransform = uiFragmentText.GetComponent<RectTransform>();
        Vector2 initialPosition = rectTransform.anchoredPosition;

        while (elapsedTime < duration)
        {
            rectTransform.anchoredPosition = Vector2.Lerp(initialPosition, targetPosition, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        rectTransform.anchoredPosition = targetPosition;

        onComplete?.Invoke();
    }
}