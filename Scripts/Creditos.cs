using UnityEngine;
using System.Collections;

public class Creditos : MonoBehaviour {

	public GameObject camara;
	public int velocidad;
	public string nivel;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		camara.transform.Translate (Vector3.down*Time.deltaTime*velocidad);
	}
	IEnumerator esperar(){

		yield return new WaitForSeconds (20);
		Application.LoadLevel (nivel);
	}
}
