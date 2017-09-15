using UnityEngine;
using System.Collections;

public class Mirror : MonoBehaviour {

    public bool CanPass;
	// Use this for initialization
	void Start () 
    {
        CanPass = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.name.Contains("Player"))
        {
            BlackImage.GetBlackImage().FinishScene(Game.GetGame().NextScene);
        }
    }
}
