using UnityEngine;
using System.Collections;

public class ButtonsHolder : MonoBehaviour {

    private RectTransform rect;
	// Use this for initialization
	void Start () 
    {
        rect = GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(rect.localPosition.y < -5f)
        {
            rect.Translate(Vector3.up * 360f * Time.deltaTime);
        }
	}
}
