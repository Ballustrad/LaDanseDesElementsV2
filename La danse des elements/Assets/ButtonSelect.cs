using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Button button;

    void Start()
    {
        // Assurez-vous que le script est attaché à un GameObject contenant un composant Button
        button = GetComponent<Button>();

        if (button == null)
        {
            Debug.LogError("Le script doit être attaché à un GameObject avec un composant Button.");
            enabled = false; // Désactivez le script s'il n'est pas correctement configuré.
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Code exécuté lorsque le pointeur entre dans la zone du bouton
        button.Select(); // Sélectionne le bouton
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        // Code exécuté lorsque le pointeur quitte la zone du bouton
        //EventSystem.current.SetSelectedGameObject(null); // Désélectionne tous les objets
    }
}
