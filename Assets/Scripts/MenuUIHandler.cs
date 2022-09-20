using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public TMP_InputField NameInput;
    public TextMeshProUGUI TitleText;
   
    private void Start()
    {
        TitleText.SetText(string.Format("Mejor puntuación : {0} : {1}", MenuManager.Instance.BestScorePlayer, MenuManager.Instance.BestScorePoints));
        NameInput.text = MenuManager.Instance.BestScorePlayer;
    }

    public void StartNew()
    {
        SetPlayerName();
        SceneManager.LoadScene(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }

    private void SetPlayerName()
    {
        MenuManager.Instance.PlayerName = NameInput.text;
    }
}
