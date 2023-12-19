using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;

    void Start()
    {
        // Assurez-vous que le script est attach� � un GameObject contenant un composant Button
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("Le script doit �tre attach� � un GameObject avec un composant Button.");
            enabled = false; // D�sactivez le script s'il n'est pas correctement configur�.
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Code ex�cut� lorsque le pointeur entre dans la zone du bouton
        button.Select(); // S�lectionne le bouton
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Code ex�cut� lorsque le pointeur quitte la zone du bouton
        //EventSystem.current.SetSelectedGameObject(null); // D�s�lectionne tous les objets
    }
}
