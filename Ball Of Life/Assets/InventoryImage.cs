using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class InventoryImage : MonoBehaviour {
    
    
    [SerializeField]
    private int index;
	// Use this for initialization
	void Start () 
    {
        
	}
	
	// Update is called once per frame
	void Update () 
    {
        GetComponent<Image>().sprite = Game.GetGame().gemSprites[index - 1];
	}
}
