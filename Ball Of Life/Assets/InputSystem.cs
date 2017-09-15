using UnityEngine;
using System.Collections;

public class InputSystem : MonoBehaviour {

    private static InputSystem inputSystem;

    private bool swiping;
    private Vector3 StartSwipePos;
    private Vector3 EndSwipePos;
    private Player player;
	// Use this for initialization
	void Awake () 
    {
        inputSystem = this;
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        swiping = false;
	}

    public static InputSystem GetInputSystem()
    {
        return inputSystem;
    }
	
	// Update is called once per frame
	void Update () 
    {
	    if(Input.GetMouseButtonDown(0))
        {
            StartSwipePos = Input.mousePosition;
            swiping = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            EndSwipePos = Input.mousePosition;
            if (EndSwipePos.x > StartSwipePos.x && swiping)
            {
                player.Walk(Vector3.right * 7f);
            }
            else if (EndSwipePos.x < StartSwipePos.x && swiping)
            {
                player.Walk(Vector3.left * 7f);
            }
            if(EndSwipePos.y > StartSwipePos.y && swiping)
            {
                player.GetJumpForce(6.5f);
                swiping = false;
            }
        }
	}
}
