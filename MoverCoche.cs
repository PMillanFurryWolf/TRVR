using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
/*
*Universidad Tecnologica de Tecamac - Pedro Ramos Millan -TIC
*Proposito: Manipular el modelo del automovil del usuario
*/
public class MoverCoche : MonoBehaviour {

    public WheelCollider llantaFR, llantaFL, llantaBR, llantaBL;
    public Transform neumaticoFR, neumaticoFL, neumaticoBR, neumaticoBL;
    public float aceleracion = 1000;//se define la velocidad del coche
    public Text txtVelocidad, txtTiempo, txtPuntaje;
    public float desaceleracion = 60000f;
    public Vector3 vt;
	float velocidad;
    public Rigidbody rb,rbLLantas;
	//Sonido del coche
	public AudioSource sonido;
	public AudioClip sonidoAcelerar, sonidoFrenar,sonidoReversa;
	//Cuerpos elegidos
	public GameObject cuerpo1;
	public GameObject cuerpo2;
	public GameObject cuerpo3;
	public GameObject cuerpo4;
    void Start() {
        //Estas lineas de codigo se encargan de definir el punto de masa del coche
       
		Antiderrapante ();
		rb = GetComponent<Rigidbody>();
		vt = new Vector3 (0,-1f,0);
		rb.centerOfMass = vt;
		
		//Aqui recupero el valor del coche elegido
		if (SeleccionCarro.valorCoche == 1) {
			cuerpo1.SetActive (true);
			cuerpo2.SetActive(false);
			cuerpo3.SetActive(false);
			cuerpo4.SetActive(false);
		} else if (SeleccionCarro.valorCoche == 2) {
			cuerpo1.SetActive (false);
			cuerpo2.SetActive(true);
			cuerpo3.SetActive(false);
			cuerpo4.SetActive(false);
		}else if (SeleccionCarro.valorCoche == 3) {
			cuerpo1.SetActive (false);
			cuerpo2.SetActive(false);
			cuerpo3.SetActive(true);
			cuerpo4.SetActive(false);
		}else if (SeleccionCarro.valorCoche == 4) {
			cuerpo1.SetActive (false);
			cuerpo2.SetActive(false);
			cuerpo3.SetActive(false);
			cuerpo4.SetActive(true);
		}
    }


    void Update() {
        //Se agrega la animacion de las llantas delanteras(Movimiento izquierda,derecha)
        neumaticoFR.localEulerAngles = new Vector3(0, llantaFR.steerAngle * 4, 0);
        neumaticoFL.localEulerAngles = new Vector3(0, llantaFL.steerAngle * 4, 0);
        //Se agrega la animacion de las llantas para su giro(Spin)
        neumaticoBR.Rotate(llantaBR.rpm / 60 * Time.deltaTime, 0, 0);
        neumaticoBL.Rotate(llantaBL.rpm / 60 * Time.deltaTime, 0, 0);
        neumaticoFR.Rotate(llantaFR.rpm / 60 * Time.deltaTime, 0, 0);
        neumaticoFL.Rotate(llantaFL.rpm / 60 * Time.deltaTime, 0, 0);
        //fin de bloque
    }
    void FixedUpdate() {
     
		CuentaRegresiva();

		if (Input.GetKey ("joystick 1 button 1")) {//1==circulo
			Detener();
		} else {
		
			//Se define el movimiento de las llantas traseras y delanteras
			llantaBL.motorTorque = aceleracion * Avanzar();
			llantaBR.motorTorque = aceleracion * Avanzar();
			llantaFL.motorTorque = aceleracion * Avanzar();
			llantaFR.motorTorque = aceleracion * Avanzar();
			//Se define la animacion del giro de las llantas delanteras
			llantaFR.steerAngle = 10 * Input.GetAxis("Horizontal");
			llantaFL.steerAngle = 10 * Input.GetAxis("Horizontal");
			//Fin de bloque

		} 
        if (Avanzar() == 0) {//Si no hay movimiento
            llantaBL.brakeTorque = desaceleracion;
            llantaBR.brakeTorque = desaceleracion;
            llantaFL.brakeTorque = desaceleracion;
            llantaFR.brakeTorque = desaceleracion;
        } else {//Caso contrario
            llantaBL.brakeTorque = 0f;
            llantaBR.brakeTorque = 0f;
            llantaFL.brakeTorque = 0f;
            llantaFR.brakeTorque = 0f;
        }
        //Si la velocidad no es nula
        if (txtVelocidad != null) {
            //Se agrega la cadena de operacion de velocidad
            txtVelocidad.text = "Velocidad: " + CalcularVelocidad().ToString("f1") + " km/h";
            txtPuntaje.text = "Puntaje: ";
        }
    }

    public float CalcularVelocidad() {//Se hace la operacion para el calculo del velocimetro
		return velocidad = (2 * Mathf.PI * llantaBL.radius)*llantaBL.rpm*60/15000;
    }//Final del metodo

	//metodo que permite acelerar con los botones en lugar del Axis del control
	public int Avanzar(){
		int paramBtm = 0;
		if (Input.GetKey ("joystick 1 button 0")) {//0==x
			paramBtm = 1;
			sonido.clip=sonidoAcelerar;
			sonido.Play ();
		} else if (Input.GetKey ("joystick 1 button 2")) {//2==cuadrado
			paramBtm = -1;
			sonido.clip=sonidoReversa;
			sonido.Play ();
		} else {
			paramBtm=0;
		}
		return paramBtm;
	}
	public void Detener(){
		llantaBL.motorTorque = 0;
		llantaBR.motorTorque = 0;
		llantaFR.motorTorque = 0;
		llantaFL.motorTorque = 0;

		sonido.clip=sonidoFrenar;
		sonido.Play ();
	}

    public void CuentaRegresiva() {
		//int tiempo = 0;
		//txtTiempo.text = "Tiempo " + tiempo++;
       }
	public void Antiderrapante(){
		float antiRollVal = 7500f;
		WheelHit hit;
		float travelL=1.0f;
		float travelR=1.0f;
		bool groundedBL = llantaBL.GetGroundHit(out hit);
		bool groundedBR = llantaBR.GetGroundHit(out hit);
		if (groundedBL||groundedBR){
			travelL = (-llantaBR.transform.InverseTransformPoint(hit.point).y - llantaBR.radius) / llantaBR.suspensionDistance;
			travelL=(-llantaBL.transform.InverseTransformPoint(hit.point).y-llantaBL.radius)/llantaBL.suspensionDistance;
		}
		bool groundedFR = llantaFR.GetGroundHit(out hit);
		bool groundedFL = llantaFL.GetGroundHit(out hit);
		if (groundedFR||groundedFL){
			travelR = (-llantaFL.transform.InverseTransformPoint(hit.point).y - llantaFL.radius) / llantaFL.suspensionDistance;
			travelR = (-llantaFR.transform.InverseTransformPoint(hit.point).y - llantaFR.radius) / llantaFR.suspensionDistance;
		}		
		float antiRollForce = (travelL - travelR) * antiRollVal;	
		if (groundedBL&&groundedBR) 			
			rbLLantas.AddForceAtPosition (llantaBL.transform.up * -antiRollForce, llantaBL.transform.position); 		
		    rbLLantas.AddForceAtPosition (llantaBR.transform.up * -antiRollForce, llantaBR.transform.position);
		if (groundedFR&&groundedFL)			
			rbLLantas.AddForceAtPosition(llantaFR.transform.up * antiRollForce,llantaFR.transform.position); 
			rbLLantas.AddForceAtPosition(llantaFL.transform.up * antiRollForce,llantaFL.transform.position);
	
}
}//Final de la clase