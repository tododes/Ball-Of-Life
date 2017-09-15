using UnityEngine;
using System.Collections;

public class ForceTest : MonoBehaviour {

    private Rigidbody rigid;
	// Use this for initialization
	void Start () {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = new Vector3(10, 0, 0);
        rigid.AddForce(new Vector3(0, 80, 0), ForceMode.Impulse);
	}
	
	// Update is called once per frame
	void Update () 
    {
        
	}
}
