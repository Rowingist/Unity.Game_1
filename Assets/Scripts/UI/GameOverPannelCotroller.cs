using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverPannelCotroller : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverPannel;

    public void OpenPanel()
    {
        _gameOverPannel.SetActive(true);
    }

    public void RestartGame(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
