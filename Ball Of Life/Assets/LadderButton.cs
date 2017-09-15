using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class LadderButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

    private bool pressed;
    private Player player;
    private Button button;
    private Image image;
    private Text text;

    public void OnPointerDown(PointerEventData e)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData e)
    {
        pressed = false;
    }
	// Use this for initialization
	void Start () {
        player = Player.GetPlayerInstance();
        button = GetComponent<Button>();
        image = GetComponent<Image>();
        text = GetComponentInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        button.enabled = image.enabled = text.enabled = player.OnLadder;
	    if(pressed)
        {
            player.Walk(Vector3.up);
        }
	}
}
