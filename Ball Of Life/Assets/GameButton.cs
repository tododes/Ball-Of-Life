using UnityEngine;
using System.Collections;

public class GameButton : MonoBehaviour {

    private Animation animation;
    private bool pressed;
    private float PressedYPos, OriginYPos;
	// Use this for initialization
	void Start () 
    {
        pressed = false;
        PressedYPos = transform.position.y - 1.5f;
        OriginYPos = transform.position.y;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(pressed && transform.position.y > PressedYPos)
        {
            transform.Translate(Vector3.down * 1.5f * Time.deltaTime);
        }
        else if (!pressed && transform.position.y < OriginYPos)
        {
            transform.Translate(Vector3.up * 1.5f * Time.deltaTime);
        }
	}

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.name.Contains("Player"))
        {
            pressed = true;
        }
    }

    void OnCollisionExit(Collision coll)
    {
        if (coll.collider.name.Contains("Player"))
        {
            pressed = false;
        }
    }
}
