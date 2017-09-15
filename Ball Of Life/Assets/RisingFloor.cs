using UnityEngine;
using System.Collections;

public class RisingFloor : MonoBehaviour 
{
    private Vector3 Origin;
	// Use this for initialization
	void Start () 
    {
        Origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    if(transform.position.y < 8f)
        {
            transform.Translate(Vector3.up * 2f * Time.deltaTime);
        }
        else
        {
            transform.position = Origin;
        }
	}
}
