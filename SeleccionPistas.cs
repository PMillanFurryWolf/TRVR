using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class SeleccionPistas : MonoBehaviour {

	/*Pedro Ramos Millán - Universidad Tecnológica de Tecámac
    Propósito: Permitir la selección de pistas dentro del menú*/

	public GameObject pistaA;
	public GameObject pistaB;
	public static int valorPista=0;
	public Text txtPista;

	void Start () {
		TrackA ();
	}
	
	void Update () {
		pistaA.transform.Rotate (0,0.15f,0);
		pistaB.transform.Rotate (0,0.15f,0);
	}
	public void TrackA(){
		pistaA.SetActive (true);
		pistaB.SetActive (false);
		txtPista.text = "Fast Track v1";
		valorPista=1;
	}
	public void TrackB(){
		pistaA.SetActive (false);
		pistaB.SetActive (true);
		txtPista.text = "The motion lapse V1";
		valorPista = 2;
	}
}
