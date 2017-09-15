using UnityEngine;
using System.Collections;

public class ExitGameCanvas : AreYouSureCanvas {

    public override void Yes()
    {
        Application.Quit();
    }

}
