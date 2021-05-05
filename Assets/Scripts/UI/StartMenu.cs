using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    public void OpenPanel(GameObject pannel)
    {
        pannel.SetActive(true);
    }

    public void ClosePanel(GameObject pannel)
    {
        StartCoroutine(SetAnimationDelay(1f, pannel));
    }

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void EndGane()
    {
        Application.Quit();
    }

    private IEnumerator SetAnimationDelay(float delayTime, GameObject pannel)
    {
        var delay = new WaitForSeconds(delayTime);
        yield return delay;

        pannel.SetActive(false);
    }
}
