using UnityEngine;
using System.Collections;

public class ExitLevelCanvas : AreYouSureCanvas 
{
    public override void Yes()
    {
        Time.timeScale = 1f;
        BlackImage.GetBlackImage().FinishScene("StageSelection");
    }
}
