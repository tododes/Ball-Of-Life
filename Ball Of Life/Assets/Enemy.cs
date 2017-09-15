using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    [SerializeField]
    protected Sprite[] MySprites;
    protected SpriteRenderer MyRenderer;
    protected int AnimationCounter;
    protected bool IsLife;

    protected void Start()
    {
        IsLife = true;
        MyRenderer = GetComponent<SpriteRenderer>();
        StartCoroutine(Animate());
    }

    protected IEnumerator Animate()
    {
        while(IsLife)
        {
            if (AnimationCounter >= MySprites.Length)
                AnimationCounter = 0;
            MyRenderer.sprite = MySprites[AnimationCounter];
            AnimationCounter++;
            yield return new WaitForSeconds(0.1f);
        }
        yield return null; 
    }
}
