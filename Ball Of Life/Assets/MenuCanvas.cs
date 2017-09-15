using UnityEngine;
using System.Collections;

public class MenuCanvas : MonoBehaviour {

    [SerializeField]
    private Canvas RetryCanvas, exitLevelCanvas, exitGameCanvas;

    public void Resume()
    {
        GetComponent<Canvas>().enabled = false;
        Time.timeScale = 1f;
    }
	public void Retry()
    {
        RetryCanvas.enabled = true;
        GetComponent<Canvas>().enabled = false;
    }

    public void ExitLevel()
    {
        exitLevelCanvas.enabled = true;
        GetComponent<Canvas>().enabled = false;
    }

    public void ExitGame()
    {
        exitGameCanvas.enabled = true;
        GetComponent<Canvas>().enabled = false;
    }
}
