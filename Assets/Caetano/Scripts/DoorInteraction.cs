using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorInteraction : MonoBehaviour
{
    [SerializeField] private string sceneToLoad; // Nome da cena a ser carregada

    private void OnMouseDown()
    {
        // Detecta o clique e carrega a cena
        if (!string.IsNullOrEmpty(sceneToLoad))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
        else
        {
            Debug.LogWarning("A cena não foi especificada para a porta.");
        }
    }
}
