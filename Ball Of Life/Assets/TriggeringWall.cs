using UnityEngine;
using System.Collections;

public class TriggeringWall : MonoBehaviour {

    [SerializeField]
    private FallingIce ice;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.gameObject.name.Contains("Player"))
        {
            ice.FallTriggered = true;
        }
    }
}
