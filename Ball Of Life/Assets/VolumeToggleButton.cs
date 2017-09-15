using UnityEngine;
using System.Collections;

public class VolumeToggleButton : MonoBehaviour {

	public void OnPress()
    {
        if(!PlayerPrefs.HasKey("Original Volume"))
            PlayerPrefs.SetFloat("Original Volume",-1f);

        if(PlayerPrefs.GetFloat("Original Volume") <= -1f)
        {
            Debug.Log("MUTE");
            PlayerPrefs.SetFloat("Original Volume", PlayerPrefs.GetFloat("Volume"));
            //PlayerPrefs.SetFloat("Volume", 0f);
        }
        else
        {
            Debug.Log("UNMUTE");
            PlayerPrefs.SetFloat("Volume", PlayerPrefs.GetFloat("Original Volume"));
            PlayerPrefs.SetFloat("Original Volume", -1f);
        }
    }
}
