using UnityEngine;
using System.Collections;

public class MovingTrap : MonoBehaviour {

    private Vector3 StartingPosX;
    private bool MovingLeft;
	
	void Start () 
    {
        StartingPosX = transform.position;
        MovingLeft = true;
	}
	
	void Update () 
    {
        if(MovingLeft)
        {
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
           
        else
        {
            transform.Translate(Vector3.left * 2f * Time.deltaTime);
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
           
        if(transform.position.x < -7f)
        {
            MovingLeft = false;
        }

        if(transform.position.x >= StartingPosX.x)
        {
            MovingLeft = true;
        }

	}
}
