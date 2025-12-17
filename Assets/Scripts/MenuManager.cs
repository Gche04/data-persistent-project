using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{

    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private TMP_Text bestScore;

    public void Start()
    {
        bestScore.text = PersistenceManager.Instance.CreateHighestScoreText();
    }

    public void NewStart()
    {
        SceneManager.LoadScene(1);
        PersistenceManager.Instance.playerName = playerName.text;
    }

    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #endif
    }
}
