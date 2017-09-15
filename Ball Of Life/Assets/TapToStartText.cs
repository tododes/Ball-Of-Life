using UnityEngine;
using System.Collections;

public class TapToStartText : MonoBehaviour {

    private UnityEngine.UI.Text text;
	// Use this for initialization
	void Start () 
    {
        text = GetComponent<UnityEngine.UI.Text>();
        StartCoroutine(FadeInOut());
	}
	
	IEnumerator FadeInOut()
    {
        while(true)
        {
            text.text = "TAP TO START";
            yield return new WaitForSeconds(0.5f);
            text.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
