using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour{

    [SerializeField]
    private GameObject[] nextFloors;

    [SerializeField]
    private GameObject spike;


    [SerializeField]
    protected Sprite[] Sprites;
    protected SpriteRenderer MyRenderer;

    private int stateCode;

    public bool canSwitch;
    protected void Start()
    {
        MyRenderer = GetComponent<SpriteRenderer>();
        stateCode = 0;
        canSwitch = false;
    }

    void Update()
    {
        foreach(GameObject g in nextFloors)
        {
            g.GetComponent<BoxCollider>().enabled = g.GetComponent<SpriteRenderer>().enabled = (stateCode == 1);
        }
        spike.GetComponent<BoxCollider>().enabled = spike.GetComponent<SpriteRenderer>().enabled = (stateCode == 0);
    }

    public void OnMouseDown()
    {
        if(canSwitch)
        {
            if (stateCode == 1)
                stateCode = 0;
            else
                stateCode = 1;
        }
        MyRenderer.sprite = Sprites[stateCode];
    }
}
