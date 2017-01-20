using UnityEngine;
using System.Collections;


public class RandomGaim : MonoBehaviour {
	string[] arr = { "0.6", "0.7", "0.8", "0.9", "1.0", "1.1", "1.2", "1.3", "1.4"};
	// Use this for initialization
	void Awake(){
		GameObject.Find ("GainController").GetComponent<ChangeGain> ().gain = float.Parse( getRandom (arr));
	}
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public string getRandom(string[] arr){
		int n=Random.Range (0,arr.Length);
		return arr [n];
	
	}
}
