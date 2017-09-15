using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    [SerializeField]
    private int minute;

    private UnityEngine.UI.Text text;

    private int second;

    void Start()
    {
        second = 0;
        text = GetComponentInChildren<UnityEngine.UI.Text>();
        StartCoroutine(TimerTick());
    }

    void Update()
    {
        text.text = minute + " : " + second;
    } 

    IEnumerator TimerTick()
    {
        while(minute > 0 || second > 0)
        {
            second--;
            if(second < 0)
            {
                second = 59;
                minute--;
            }
            yield return new WaitForSeconds(1);
        }
        yield return null;
    }
}
