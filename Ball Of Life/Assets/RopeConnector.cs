using UnityEngine;
using System.Collections;

public class RopeConnector : MonoBehaviour {

    private CharacterJoint joint;
	// Use this for initialization
	void Start () 
    {
        joint = GetComponent<CharacterJoint>();
        joint.connectedBody = transform.parent.GetComponent<Rigidbody>();
        if(gameObject.name.Contains("(3)"))
        {
            transform.eulerAngles = new Vector3(0, 0, 60);
        }
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}
}
