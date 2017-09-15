using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TutorImage : MonoBehaviour {

	// Use this for initialization
	void Start () 
    {
        if (PlayerPrefs.GetInt("TUTOR FINISHED") < 2 || !PlayerPrefs.HasKey("TUTOR FINISHED"))
        {
            StartCoroutine(Display());
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator Display()
    {
        GetComponent<Image>().enabled = true;
        GetComponentInChildren<Text>().enabled = true;
        yield return new WaitForSeconds(3.5f);
        GetComponent<Image>().enabled = false;
        GetComponentInChildren<Text>().enabled = false;
        PlayerPrefs.SetInt("TUTOR FINISHED", PlayerPrefs.GetInt("TUTOR FINISHED") + 1);
        yield return null;
    }
}
