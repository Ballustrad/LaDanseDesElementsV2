using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class OnButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;

    /*public float hoverScale = 1.2f; // Facteur d'agrandissement lors du survol
    private Vector3 initialScale; // �chelle initiale du bouton*/

    void Start()
    {
        // Assurez-vous que le script est attach� � un GameObject contenant un composant Button
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("Le script doit �tre attach� � un GameObject avec un composant Button.");
            enabled = false; // D�sactivez le script s'il n'est pas correctement configur�.
        }

        /*// S'assurer que le bouton est attribu� dans l'�diteur Unity
        if (button != null)
        {
            // Sauvegarder l'�chelle initiale du bouton
            initialScale = button.transform.localScale;
        }
        else
        {
            Debug.Log("Le bouton n'a pas �t� attribu� dans l'�diteur Unity.");
        }*/
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Code ex�cut� lorsque le pointeur entre dans la zone du bouton
        button.Select(); // S�lectionne le bouton
        //button.transform.localScale = initialScale * hoverScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Code ex�cut� lorsque le pointeur quitte la zone du bouton
        //EventSystem.current.SetSelectedGameObject(null); // D�s�lectionne tous les objets
        //button.transform.localScale = initialScale;
    }
}
