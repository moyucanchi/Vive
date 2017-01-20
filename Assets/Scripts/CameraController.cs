using UnityEngine;
using System;
using System.Collections;
using System.Text.RegularExpressions;

public class CameraController : MonoBehaviour {

	private Camera cam;
	private Vector3 startPos;
	private Vector3 camRotation;
	private Vector3 camRotationNew;
	private Vector3 positionNew;
	public float gain=1;
//	private Regex regex=new Regex("[0-9]+$^");
	void Start () {
		cam = GetComponentInChildren<Camera>();

	}

	void Update () {
		//transform.localPosition = startPos - cam.transform.localPosition;
		//startPos = transform.Find("TrackingSpace").position;

		camRotation = cam.transform.localRotation.eulerAngles;
		if (!Regex.IsMatch(gain.ToString(),"^[0-9]+$") && camRotation.y >= 180f) {
			camRotationNew.y = (gain-1) * camRotation.y - (gain-1) * 360f;
			
		} else {
			camRotationNew.y = (gain-1) * camRotation.y;
		}
		camRotationNew.x=0;
		camRotationNew.z=0;



		transform.localRotation = Quaternion.Euler(camRotationNew);
		print (camRotationNew);
	}

}
