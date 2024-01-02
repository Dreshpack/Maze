using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WebViewController : MonoBehaviour
{
    [SerializeField] string URL;
    private UniWebView uniWebView;


    public void ShowWebView()
    {
        Init();
        uniWebView.Show();
    }



    private void Init()
    {
        uniWebView = gameObject.AddComponent<UniWebView>();

        uniWebView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        uniWebView.Load(URL, true);
    }
}
