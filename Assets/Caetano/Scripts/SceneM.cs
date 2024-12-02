using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneM : MonoBehaviour
{   
    public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
