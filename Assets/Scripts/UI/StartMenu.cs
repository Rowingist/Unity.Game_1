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
        StartCoroutine(DelayPannelDeactivation(1f, pannel));
    }

    public void StartGame(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void EndGane()
    {
        Application.Quit();
    }

    private IEnumerator DelayPannelDeactivation(float delayTime, GameObject pannel)
    {
        yield return new WaitForSeconds(delayTime);

        pannel.SetActive(false);
    }
}
