using UnityEngine;
using System.Collections;
using TODOENGINE;

public class BlackImage : TD_LOADING_PANEL {

    private static BlackImage blackImage;

    void Awake()
    {
        blackImage = this;
    }

    public static BlackImage GetBlackImage()
    {
        return blackImage;
    }
    //protected override void Update()
    //{
    //    base.Update();
    //    if (GameStateManager.Win && STATE != MENUSTATE.FINISHED)
    //    {
    //        FinishScene("Win");
    //    }
    //    else if (GameStateManager.Lose && STATE != MENUSTATE.FINISHED)
    //    {
    //        FinishScene("Lose");
    //    }
    //}
	
}
