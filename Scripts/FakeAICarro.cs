using UnityEngine;
using System.Collections;

public class FakeAICarro : MonoBehaviour {

	public WheelCollider llantaUno,llantaDos,llantaTres,llantaCuatro;
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		llantaUno.motorTorque=5000*1;
		llantaDos.motorTorque=5000*1;
		llantaTres.motorTorque=5000*1;
		llantaCuatro.motorTorque=5000*1;
	}
}
