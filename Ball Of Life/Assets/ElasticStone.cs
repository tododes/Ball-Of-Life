using UnityEngine;
using System.Collections;

public class ElasticStone : MonoBehaviour {

    [SerializeField]
    private Sprite[] TightSprites;

    [SerializeField]
    private Sprite[] StretchSprites;
    protected SpriteRenderer MyRenderer;
    protected int TightAnimationCounter;
    protected int StretchAnimationCounter;

    private BoxCollider[] colliders;
	
	void Start () 
    {
        MyRenderer = GetComponent<SpriteRenderer>();
        colliders = GetComponents<BoxCollider>();
	}
	
	IEnumerator Tight()
    {
        while(TightAnimationCounter < TightSprites.Length - 1)
        {
            Debug.Log("Tighting");
            MyRenderer.sprite = TightSprites[TightAnimationCounter++];
            
            yield return new WaitForSeconds(0.1f);
        }
        TightAnimationCounter = 0;
        yield return null;
    }

    IEnumerator Stretch()
    {
        while (StretchAnimationCounter < StretchSprites.Length)
        {
            Debug.Log("Stretching");
            MyRenderer.sprite = StretchSprites[StretchAnimationCounter++];
            
            yield return new WaitForSeconds(0.1f);
        }
        StretchAnimationCounter = 0;
        yield return null;
    }

    void OnCollisionEnter(Collision coll)
    {
        if(coll.collider.name.Contains("Player"))
        {
            StartCoroutine(Tight());
            coll.collider.GetComponent<Player>().GetJumpForce(7.5f);
        }
            
    }
    void OnCollisionExit(Collision coll)
    {
        if (coll.collider.name.Contains("Player"))
            StartCoroutine(Stretch());
    }

}
