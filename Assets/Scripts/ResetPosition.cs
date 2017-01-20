using UnityEngine;
using System.Collections;

public class ResetPosition : MonoBehaviour {
	private Vector3 p0;
	private Vector3 p1;
	private Vector3 p2;
	private Vector3 p3;
	private Vector3 p4;
	private Vector3 p5;
	private Vector3 p6;
	private Vector3 rotation;
	public GameObject cube0; 
	public GameObject cube1; 
	public GameObject cube2; 
	public GameObject cube3; 
	public GameObject sphere0;
	public GameObject sphere1;
	public GameObject sphere2;
	// Use this for initialization
	void Start () {
		p0 = cube0.transform.position;
		p1 = cube1.transform.position;
		p2 = cube2.transform.position;
		p3 = cube3.transform.position;
		p4 = sphere0.transform.position;
		p5 = sphere1.transform.position;
		p6 = sphere2.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		rotation = new Vector3 (0, 0, 0);
	}
	public void Reset(){
		cube0.transform.position=p0;
		cube1.transform.position=p1;
		cube2.transform.position=p2;
		cube3.transform.position=p3;
		sphere0.transform.position=p4;
		sphere1.transform.position=p5;
		sphere2.transform.position=p6;


		cube0.transform.localRotation=Quaternion.Euler(rotation) ;
		cube1.transform.localRotation=Quaternion.Euler(rotation) ;
		cube2.transform.localRotation=Quaternion.Euler(rotation) ;
		cube3.transform.localRotation=Quaternion.Euler(rotation) ;
		sphere0.transform.localRotation=Quaternion.Euler(rotation) ;
		sphere1.transform.localRotation=Quaternion.Euler(rotation) ;
		sphere2.transform.localRotation=Quaternion.Euler(rotation) ;

	}
}
