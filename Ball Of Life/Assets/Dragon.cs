using UnityEngine;
using System.Collections;

public class Dragon : MonoBehaviour {

    public Sprite[] leftSprites, rightSprites, attackSprites;
    private int HP, Attack;

    public GameObject Fire15, Fire45, Fire75, Fire5, Fire85;
    
    private int leftCounter, rightCounter, attackCounter;

    [SerializeField]
    private bool left, right, attack, attackMid;

    private float AttackTimer;
   

    void Start()
    {
        right = true;
        StartCoroutine(DragonAnimate());
    }

    void Update()
    {
        if(transform.position.x >= 8.3f)
        {
            left = true;
            right = false;
            attack = true;
        }
        else if (transform.position.x <= -8.3f)
        {
            left = false;
            right = true;
        }

        if(right && !attack)
        {
            transform.Translate(Vector3.right * 4f * Time.deltaTime);
        }
        else if (left && !attack)
        {
            transform.Translate(Vector3.left * 4f * Time.deltaTime);
        }

        if(transform.position.x == 0f)
        {
            attackMid = true;
        }

        if (attackMid)
        {
            if(right)
                transform.position = new Vector3(1f, transform.position.y, transform.position.z);
            else if(left)
                transform.position = new Vector3(-1f, transform.position.y, transform.position.z);

            AttackTimer += Time.deltaTime;
            if (AttackTimer >= 5f)
            {
                attack = false;
                AttackTimer = 0f;
            }
        }

        if(attack)
        {
            transform.position = new Vector3(8f, transform.position.y, transform.position.z);
            AttackTimer += Time.deltaTime;
            if(AttackTimer >= 5f)
            {
                attack = false;
                AttackTimer = 0f;
            }
        }
    }

    IEnumerator DragonAnimate()
    {
        while(true)
        {
            if(attack)
            {
                GetComponent<SpriteRenderer>().sprite = attackSprites[attackCounter++];
                if(attackCounter >= attackSprites.Length)
                {
                    Instantiate(Fire15, transform.position, Fire15.transform.rotation);
                    Instantiate(Fire45, transform.position, Fire45.transform.rotation);
                    Instantiate(Fire75, transform.position, Fire75.transform.rotation);
                    attackCounter = 0;
                }
            }
            else if (attackMid)
            {
                GetComponent<SpriteRenderer>().sprite = attackSprites[attackCounter++];
                if (attackCounter >= attackSprites.Length)
                {
                    Instantiate(Fire15, transform.position, Fire15.transform.rotation);
                    Instantiate(Fire45, transform.position, Fire45.transform.rotation);
                    Instantiate(Fire75, transform.position, Fire75.transform.rotation);
                    Instantiate(Fire5, transform.position, Fire5.transform.rotation);
                    Instantiate(Fire85, transform.position, Fire85.transform.rotation);
                    attackCounter = 0;
                }
            }
            else
            {
                if(left)
                {
                    GetComponent<SpriteRenderer>().sprite = leftSprites[leftCounter++];
                    if (leftCounter >= leftSprites.Length)
                    {
                        leftCounter = 0;
                    }
                }
                else if(right)
                {
                    GetComponent<SpriteRenderer>().sprite = rightSprites[rightCounter++];
                    if (rightCounter >= rightSprites.Length)
                    {
                        rightCounter = 0;
                    }
                }
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
}
