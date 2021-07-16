using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{

    public TextMeshProUGUI BestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        BestScoreText.text = GameManager.Instance.getBestScoreText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
        }
    }

    public void SetPlayerName(string name)
    {
            GameManager.Instance.playerName = name;
    }
}
