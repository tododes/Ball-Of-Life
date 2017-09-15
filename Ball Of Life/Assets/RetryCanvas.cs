using UnityEngine;
using System.Collections;

public class RetryCanvas : AreYouSureCanvas {

    public override void Yes()
    {
        Time.timeScale = 1f;
        BlackImage.GetBlackImage().FinishScene(Application.loadedLevelName);
    }  
}
