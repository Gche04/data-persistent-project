using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    public void NewStart()
    {
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
    }
}
