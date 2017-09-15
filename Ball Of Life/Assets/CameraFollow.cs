using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private Transform player;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (transform.position.y > -3f)
        {
            transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        }
       
	}
}
