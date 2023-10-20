using UnityEngine;

public class Disapear : MonoBehaviour
{
    public float disappearTime = 3f; // Temps en secondes avant de dispara�tre

    private bool isCollided = false;
    private float elapsedTime = 0f;

    private void Update()
    {
        if (!isCollided)
        {
            // Incr�mente le temps �coul�
            elapsedTime += Time.deltaTime;

            // V�rifie si le temps �coul� est sup�rieur � la valeur de disparition
            if (elapsedTime >= disappearTime)
            {
                Disappear();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Lorsque le GameObject entre en collision avec quelque chose, il dispara�t
        if (!isCollided)
        {
            isCollided = true;
            Disappear();
        }
    }

    private void Disappear()
    {
        // D�sactive le GameObject pour le faire dispara�tre
        gameObject.SetActive(false);
    }
}
