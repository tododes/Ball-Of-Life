using UnityEngine;
using System.Collections;

public class InvisibleWall : MonoBehaviour {

    [SerializeField]
    private ElasticStone stone;
	// Use this for initialization
	void Start () 
    {
	    
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    public void CreateStone()
    {
        stone.gameObject.SetActive(true);
        //Instantiate(stone.gameObject, GetComponentInChildren<Transform>().position, Quaternion.identity);
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.name.Contains("Player"))
        {
            CreateStone();
            Destroy(coll.collider.GetComponent<Player>().box.gameObject);   
        }
    }
}
