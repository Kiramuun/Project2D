using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu]
public class UIManager : ScriptableObject
{
    private int playerChoice;

    public void NewGame()
    {
        SceneManager.LoadScene("PlayerChoose",LoadSceneMode.Additive);
    }

    /*public void Start()
    {
        SceneManager.UnloadSceneAsync("PlayerChoose");
    }*/

    public void Resume()
    {
        SceneManager.UnloadSceneAsync("PauseMenu");
        Time.timeScale = 1f;
    }

    public void Continue()
    {
        
    }

    /*public void RetourMainMenu()
    {
        SceneManager.UnloadSceneAsync("SampleScene");
        Time.timeScale = 1f;
    }*/

    public void Exit()
    {
        //EditorApplication.isPlaying = false;
        Application.Quit();
    }

    public void ButtonMale()
    {
        playerChoice = 0;
        PlayerPrefs.SetInt("playerChoice", playerChoice);
    }

    public void ButtonFemale()
    {
        playerChoice = 1;
        PlayerPrefs.SetInt("playerChoice", playerChoice);
    }
}
