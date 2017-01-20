using UnityEngine;
using System.Collections;

public class TimeShow : MonoBehaviour {
    private float timer = 0f;

    private int h = 0;

    private int m = 0;

    private int s = 0;


    private string timeStr = string.Empty;
    private GameObject obj;
    public Texture t;
    // Use this for initialization
    void Start () {
        obj = GameObject.Find("Cube");
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            s++;
            timer = 0;
        }
        if (s >= 60)
        {
            m++;
            s = 0;
        }
        if (m >= 60)
        {
            h++;
            m = 0;
        }
        if (h >= 99)
        {
            h = 0;
        }

        if (s >= 2)
        {
            obj.GetComponent<Renderer>().material.mainTexture = t;
        }
    }
    void OnGUI()
    {
        timeStr = string.Format("{0:D2}:{1:D2}:{2:D2}", h, m, s);
        GUI.Label(new Rect(10, 10, 100, 200), timeStr);
    }
}
