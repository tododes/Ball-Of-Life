using UnityEngine;
using System.Collections;

public class LoseCanvas : MonoBehaviour 
{
    public void ExitGame()
    {
        Application.Quit();
    }

    public void Retry()
    {
        BlackImage.GetBlackImage().FinishScene(Application.loadedLevelName);
    }

    public void ExitLevel()
    {
        BlackImage.GetBlackImage().FinishScene("StageSelection");
    }
}
