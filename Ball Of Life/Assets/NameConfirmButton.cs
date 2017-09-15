using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NameConfirmButton : MonoBehaviour {

    [SerializeField]
    private Canvas confirmCanvas;

    [SerializeField]
    private Text text; 
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public bool isNameBeingUsed(string n)
    {
        for (int i = 0; i < 3;i++ )
        {
            if (PlayerPrefs.GetString("NAME" + i) == n)
                return true;
        }
        return false;
    }

    public void EnableConfirmationCanvas()
    {
        if (!isNameBeingUsed(NameInputField.GetInputField().name))
        {
            confirmCanvas.enabled = true;
            text.text = "Are you sure you want to give the \n name " + NameInputField.GetInputField().name + " ?";
        }
    }

    public void DisableConfirmationCanvas()
    {
        confirmCanvas.enabled = false;
    }
}
