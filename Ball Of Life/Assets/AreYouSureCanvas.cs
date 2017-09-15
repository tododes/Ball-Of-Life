using UnityEngine;
using System.Collections;

public class AreYouSureCanvas : MonoBehaviour {

    [SerializeField]
    protected Canvas MenuCanvas;

    public virtual void Yes()
    {

    }

    public void No()
    {
        GetComponent<Canvas>().enabled = false;
        MenuCanvas.enabled = true;
    }
}
