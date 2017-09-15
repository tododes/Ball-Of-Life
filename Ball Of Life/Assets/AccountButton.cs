using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AccountButton : MonoBehaviour {

    public static string CurrentSelectedAccount;
    private Text MyText;
    private int StateCode;

    [SerializeField]
    private Button SelectButton, DeleteButton, NewButton;

	void Start () 
    {
        MyText = GetComponentInChildren<Text>();
        StateCode = 0;
	}

	void Update () 
    {
	    if(MyText.text != "ADD NEW")
        {
            StateCode = 1;
        }
        else
        {
            StateCode = 0;
        }
	}

    public void Pressed()
    {
        if(StateCode == 1)
        {
            SelectButton.enabled = true;
            SelectButton.gameObject.GetComponent<Image>().enabled = true;
            SelectButton.gameObject.GetComponentInChildren<Text>().enabled = true;

            DeleteButton.enabled = true;
            DeleteButton.gameObject.GetComponent<Image>().enabled = true;
            DeleteButton.gameObject.GetComponentInChildren<Text>().enabled = true;

            NewButton.enabled = false;
            NewButton.gameObject.GetComponent<Image>().enabled = false;
            NewButton.gameObject.GetComponentInChildren<Text>().enabled = false;
        }
        else
        {
            Application.LoadLevel("NameInputScene");
        }
    }

    public void SetCurrentAccount()
    {
            if (GetComponentInChildren<Text>().text != "" && GetComponentInChildren<Text>().text != "ADD NEW")
                CurrentSelectedAccount = gameObject.GetComponentInChildren<Text>().text;
            else if (GetComponentInChildren<Text>().text == "ADD NEW")
                CurrentSelectedAccount = "";
    }
}
