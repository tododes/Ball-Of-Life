using UnityEngine;
using System.Collections;

public class MirrorBox : MonoBehaviour {

    [SerializeField]
    private Sprite OriginSprite, StoneSprite;
    private SpriteRenderer MyRenderer;
    [SerializeField]
    private Mirror mirror;

	// Use this for initialization
	void Start () 
    {
        MyRenderer = GetComponent<SpriteRenderer>();
        OriginSprite = MyRenderer.sprite;
	}
	
	// Update is called once per frame
	void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.name.Contains("Player"))
        {
            MyRenderer.sprite = StoneSprite;
            GetComponent<BoxCollider>().isTrigger = true;
            coll.collider.GetComponent<Player>().box = this;
            transform.parent = coll.collider.GetComponent<Player>().ItemHolder;
        }
    }

    public void EnableMirror()
    {
        mirror.CanPass = true;
    }
}
