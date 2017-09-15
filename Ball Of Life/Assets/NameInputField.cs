using UnityEngine;
using System.Collections;

public class NameInputField : MonoBehaviour {

    public string name;
    private static NameInputField inputField;

    void Start()
    {
        inputField = this;
    }

	public void SetName(string n)
    {
        name = n;
    }

    void Update()
    {
       
    }

    public void SetConfirmedName()
    {
        for (int i = 1; i <= 3;i++ )
        {
            if(PlayerPrefs.GetString("NAME"+i) == "" || !PlayerPrefs.HasKey("NAME"+i))
            {
                PlayerPrefs.SetString("NAME"+i, name);
                PlayerPrefs.SetString("CURRENT NAME", name);
                Debug.Log(i);
                break;
            }
        }

        BlackImage.GetBlackImage().FinishScene("StageSelection");
    }

    public void Reset()
    {
        name = "";
    }

    public static NameInputField GetInputField()
    {
        return inputField;
    }
}
