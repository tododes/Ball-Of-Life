using UnityEngine;
using System.Collections;

public class BumperWall : MonoBehaviour {

    [SerializeField]
    private float JumpForce;
	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (JumpForce == 0f)
            JumpForce = 12f;
	}

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.name.Contains("Player"))
        {
            coll.collider.GetComponent<Player>().GetJumpForce(JumpForce);
        }
    }
}
