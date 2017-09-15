using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AudioVolumeBar : MonoBehaviour {

    private Slider slider;
	// Use this for initialization
	void Start () {
        slider = GetComponent<Slider>();
        slider.maxValue = 100f;
       
      
	}

    void Update()
    {
        if (PlayerPrefs.GetFloat("Original Volume") > -1f)
            PlayerPrefs.SetFloat("Volume", 0f);
        slider.value = PlayerPrefs.GetFloat("Volume");
    }
	
	public void OnChange()
    {
        PlayerPrefs.SetFloat("Volume", slider.value);
    }
}
