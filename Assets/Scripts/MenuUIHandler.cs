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
    [SerializeField] private TMP_InputField NameInput;
    [SerializeField] private TextMeshProUGUI TitleText;
   
    private void Start()
    {
        TitleText.SetText(string.Format("Mejor puntuación : {0} : {1}", DataManager.Instance.BestScorePlayer, DataManager.Instance.BestScorePoints));
        NameInput.text = DataManager.Instance.BestScorePlayer;
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
        DataManager.Instance.PlayerName = NameInput.text;
    }
}
