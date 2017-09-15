using UnityEngine;
using System.Collections;

public class LevelButton : MonoBehaviour {

    [SerializeField]
    private GameObject MyPanel;

    [SerializeField]
    private GameObject[] otherPanels;
	
    public void ActivatePanel()
    {
        MyPanel.SetActive(true);
        foreach(GameObject g in otherPanels)
        {
            g.SetActive(false);
        }
    }
}
