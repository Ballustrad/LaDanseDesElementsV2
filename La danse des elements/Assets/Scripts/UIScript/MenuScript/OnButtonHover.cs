using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;

    /*public float hoverScale = 1.2f; // Facteur d'agrandissement lors du survol
    private Vector3 initialScale; // Échelle initiale du bouton*/

    void Start()
    {
        // Assurez-vous que le script est attaché à un GameObject contenant un composant Button
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("Le script doit être attaché à un GameObject avec un composant Button.");
            enabled = false; // Désactivez le script s'il n'est pas correctement configuré.
        }

        /*// S'assurer que le bouton est attribué dans l'éditeur Unity
        if (button != null)
        {
            // Sauvegarder l'échelle initiale du bouton
            initialScale = button.transform.localScale;
        }
        else
        {
            Debug.Log("Le bouton n'a pas été attribué dans l'éditeur Unity.");
        }*/
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Code exécuté lorsque le pointeur entre dans la zone du bouton
        button.Select(); // Sélectionne le bouton
        //button.transform.localScale = initialScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Code exécuté lorsque le pointeur quitte la zone du bouton
        //EventSystem.current.SetSelectedGameObject(null); // Désélectionne tous les objets
        //button.transform.localScale = initialScale;
    }
}
