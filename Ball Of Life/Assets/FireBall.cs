using UnityEngine;
using System.Collections;

public class FireBall : MonoBehaviour {

    public Sprite[] sprites;
    private int counter;
	// Use this for initialization
	void Start () 
    {
        StartCoroutine(Animate());
	}
	
    IEnumerator Animate()
    {
        while(true)
        {
            GetComponent<SpriteRenderer>().sprite = sprites[counter++];
            if(counter >= sprites.Length)
            {
                counter = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    void Update()
    {
        transform.Translate(Vector3.left * 7f * Time.deltaTime);
        if(transform.position.y < -12f)
        {
            gameObject.SetActive(false);
        }
    }
}
