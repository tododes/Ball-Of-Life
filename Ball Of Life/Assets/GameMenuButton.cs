using UnityEngine;
using System.Collections;

public class GameMenuButton : MonoBehaviour {

    [SerializeField]
    private Canvas GameMenuCanvas;

    public void EnableGamemenuCanvas()
    {
        GameMenuCanvas.enabled = true;
        Time.timeScale = 0f;
    }
}
