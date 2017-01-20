using UnityEngine;
using System.Collections;
using Leap;
using Leap.Unity;


public class Controller : MonoBehaviour {
    public GameObject obj;
    public GameObject obj2;
    public Texture2D wTexture;
    public Texture2D bTexture;
    private Vector3 scale;
    // Use this for initialization
    void Start () {
        scale = obj.transform.localScale;

    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.RightArrow)&&obj.GetComponentInChildren<Renderer>()!=null)
        {
			obj.GetComponentInChildren<Renderer>().material.mainTexture = bTexture;
        }
		if (Input.GetKeyDown(KeyCode.LeftArrow)&&obj.GetComponentInChildren<Renderer>()!=null)
        {
			obj.GetComponentInChildren<Renderer>().material.mainTexture = wTexture;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            scale.x += 0.25f;
            scale.y += 0.25f;
            scale.z += 0.25f;
            obj.transform.localScale = scale;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            scale.x -= 0.25f;
            scale.y -= 0.25f;
            scale.z -= 0.25f;
            obj.transform.localScale = scale;
        }
       
		if (Input.GetKeyDown(KeyCode.S)&&GameObject.Find ("Bip01 R Hand001")!=null)
        {
			GameObject.Find ("Bip01 R Finger043").GetComponent<RiggedFinger> ().modelFingerPointing.y=-0.4f;
			GameObject.Find ("Bip01 R Finger046").GetComponent<RiggedFinger> ().modelFingerPointing.y=0.4f;
			GameObject.Find ("Bip01 R Finger049").GetComponent<RiggedFinger> ().modelFingerPointing.y=-0.4f;
			GameObject.Find ("Bip01 R Finger052").GetComponent<RiggedFinger> ().modelFingerPointing.y=0.4f;
			GameObject.Find ("Bip01 R Finger055").GetComponent<RiggedFinger> ().modelFingerPointing.y=-0.4f;

        }
		if (Input.GetKeyDown(KeyCode.D)&&GameObject.Find ("Bip01 R Hand001")!=null)
		{
			GameObject.Find ("Bip01 R Finger043").GetComponent<RiggedFinger> ().modelFingerPointing.y=0f;
			GameObject.Find ("Bip01 R Finger046").GetComponent<RiggedFinger> ().modelFingerPointing.y=0f;
			GameObject.Find ("Bip01 R Finger049").GetComponent<RiggedFinger> ().modelFingerPointing.y=0f;
			GameObject.Find ("Bip01 R Finger052").GetComponent<RiggedFinger> ().modelFingerPointing.y=0f;
			GameObject.Find ("Bip01 R Finger055").GetComponent<RiggedFinger> ().modelFingerPointing.y=0f;

		}

    }
}
