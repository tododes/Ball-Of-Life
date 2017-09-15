using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TitleText : MonoBehaviour {

    private Text text;
    private float alpha;
	// Use this for initialization
	void Start () 
    {
	    text = GetComponent<Text>();
        alpha = 1;
	}
	
	// Update is called once per frame
	void Update () 
    {
        text.color = Color.Lerp(Color.white, Color.clear, alpha);
        alpha -= 0.6f * Time.deltaTime;
	}
}
