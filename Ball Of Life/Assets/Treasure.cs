using UnityEngine;
using System.Collections;

public class Treasure : MonoBehaviour {

    public string Name;
    [SerializeField]
    private Sprite[] sprites;
    public Sprite OriSprite;
    private SpriteRenderer render;
    private int AnimCounter;

	void Start () 
    {
        AnimCounter = 0;
        render = GetComponent<SpriteRenderer>();
        OriSprite = render.sprite;
        StartCoroutine(Animate());
	}
	
	IEnumerator Animate()
    {
        while(true)
        {
            AnimCounter++;
            if (AnimCounter >= sprites.Length)
            {
                AnimCounter = 0;
            }
            render.sprite = sprites[AnimCounter];
            yield return new WaitForSeconds(0.1f);
            
        }
     
    }

  
}
