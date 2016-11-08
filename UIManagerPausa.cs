using UnityEngine;
using UnityEngine.UI;
using System.Collections;
/*
 * Universidad Tecnologica de Tecamac - Pedro Ramos Millan
 * Proposito: Mandar a llamar el panel de pausa durante el juego
 */
public class UIManagerPausa : MonoBehaviour {
	public bool estaPausado=false;
    public bool reprodMusica = true;
	public GameObject panelPausa;//Este objeto permite asociar el panel de la vista
	void Start () {
		estaPausado=false;//Inicia el juego sin pausa
	}	
	void Update () {
		if (estaPausado) {
			PauseGame (true);
		} else {
			PauseGame(false);
		}
		if (Input.GetKeyDown("joystick 1 button 7")) {//Se pausa con el botón start
			CambiaAPausa();
		}
	}
	private void PauseGame(bool valor){
		if (valor) {
			panelPausa.SetActive (true);//Se muestra el panel derecho
			Time.timeScale=0.0f;
		} else {
			Time.timeScale=1.0f;
			panelPausa.SetActive(false);//Se oculta el panel derecho
		}//Final de else
	}//Final de metodo
	private void CambiaAPausa(){
		if (estaPausado) {
			estaPausado = false;
		} else {
			estaPausado=true;
		}//Fin de else
		}//Final de metodo
}//Final de clase
