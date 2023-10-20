using UnityEngine;

public class Disapear : MonoBehaviour
{
    public float disappearTime = 3f; // Temps en secondes avant de disparaître

    private bool isCollided = false;
    private float elapsedTime = 0f;

    private void Update()
    {
        if (!isCollided)
        {
            // Incrémente le temps écoulé
            elapsedTime += Time.deltaTime;

            // Vérifie si le temps écoulé est supérieur à la valeur de disparition
            if (elapsedTime >= disappearTime)
            {
                Disappear();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Lorsque le GameObject entre en collision avec quelque chose, il disparaît
        if (!isCollided)
        {
            isCollided = true;
            Disappear();
        }
    }

    private void Disappear()
    {
        // Désactive le GameObject pour le faire disparaître
        gameObject.SetActive(false);
    }
}
