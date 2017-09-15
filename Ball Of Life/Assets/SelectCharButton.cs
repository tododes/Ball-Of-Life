using UnityEngine;
using System.Collections;

public class SelectCharButton : MonoBehaviour {

    public void ChangeAccount()
    {
        PlayerPrefs.SetString("CURRENT NAME", AccountButton.CurrentSelectedAccount);
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}
}
