using UnityEngine;
//using UnityEngine.UI;
using System.Collections;

public class MainMenuButton : MonoBehaviour {

    [SerializeField]
    private string ScenePath;

	public void OpenScene()
    {
        if(ScenePath == "QUIT")
        {
            Application.Quit();
        }
        else
            BlackImage.GetBlackImage().FinishScene(ScenePath);
    }
}
