using UnityEngine;
using System.Collections;

public class WinCanvas : MonoBehaviour 
{
    public void GoToNextLevel(string s)
    {
        BlackImage.GetBlackImage().FinishScene(s);
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
