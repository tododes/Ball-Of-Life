using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class AccountManager : MonoBehaviour {

    [SerializeField]
    private List<Button> buttons = new List<Button>();

    [SerializeField]
    private List<string> saveStrings = new List<string>();
    private static AccountManager am;

    public static AccountManager GetAccountManager()
    {
        return am;
    }

	void Start () 
    {
        am = this;
      
	   for(int i=0;i<3;i++)
       {
           if (PlayerPrefs.GetString("NAME" + (i + 1)) != "")
               saveStrings.Add(PlayerPrefs.GetString("NAME"+(i+1)));
           else
               saveStrings.Add("ADD NEW");
       }

       
	}

    public void Delete()
    {
       DeleteSavedStrings(AccountButton.CurrentSelectedAccount);


       if (PlayerPrefs.GetString("NAME1") == AccountButton.CurrentSelectedAccount)
       {
           PlayerPrefs.SetString("NAME1", PlayerPrefs.GetString("NAME2"));
           PlayerPrefs.SetString("NAME2", PlayerPrefs.GetString("NAME3"));
           PlayerPrefs.DeleteKey("NAME3");
       }
       else if (PlayerPrefs.GetString("NAME2") == AccountButton.CurrentSelectedAccount)
       {
           PlayerPrefs.SetString("NAME2", PlayerPrefs.GetString("NAME3"));
           PlayerPrefs.DeleteKey("NAME3");
       }
       else if (PlayerPrefs.GetString("NAME3") == AccountButton.CurrentSelectedAccount)
       {
           PlayerPrefs.DeleteKey("NAME3");
       }
       
        AccountButton.CurrentSelectedAccount = "";
    }


    public void DeleteSavedStrings(string s)
    {
        if (s != "ADD NEW")
            saveStrings.Remove(s);
    }

	void Update () 
    {
        saveStrings.Clear();
        for (int i = 0; i < 3; i++)
        {
            if (PlayerPrefs.GetString("NAME" + (i + 1)) != "")
                saveStrings.Add(PlayerPrefs.GetString("NAME" + (i + 1)));
            else
                saveStrings.Add("ADD NEW");
        }
        for (int i = 0; i < 3; i++)
        {
            buttons[i].gameObject.GetComponentInChildren<Text>().text = saveStrings[i];
        }
	}
}
