using UnityEngine;
using System.Collections;

public class FallingIce : MonoBehaviour {

    public bool FallTriggered;
    private Rigidbody rigid;
	// Use this for initialization
	void Start () 
    {
        FallTriggered = false;
        rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        rigid.useGravity = FallTriggered;
	}
}
