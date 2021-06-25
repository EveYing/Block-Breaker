using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneLoader : MonoBehaviour {

    GameSession gs;

    private void Start()
    {
        gs = FindObjectOfType<GameSession>();
    }

    public void LoadNextScene()
    {
        //Debug.Log("I'm Here!");
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log(currentSceneIndex + " " + SceneManager.sceneCountInBuildSettings);
        if (currentSceneIndex < SceneManager.sceneCountInBuildSettings - 1)
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("Success Menu");
        }
    }

    public void LoadStartScene()
    {
        gs.DestroyStatus();
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void LoadSelectedLevelScene(Button button)
    {
        string buttonText = button.GetComponentInChildren<TextMeshProUGUI>().text;
        SceneManager.LoadScene(buttonText);
    }

    public void LoadSelectionMenu()
    {
        gs.DestroyStatus();
        SceneManager.LoadScene("Main Menu");
    }
}
