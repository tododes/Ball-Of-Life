using UnityEngine;
using System.Collections;

public class AccounText : MonoBehaviour {

    private UnityEngine.UI.Text text;
	// Use this for initialization
	void Start () {
        text = GetComponent<UnityEngine.UI.Text>();
	}
	
	// Update is called once per frame
	void Update () {
	    if(text.text != "Hi, " + PlayerPrefs.GetString("CURRENT NAME"))
        {
            text.text = "Hi, " + PlayerPrefs.GetString("CURRENT NAME");
        }
	}
}
