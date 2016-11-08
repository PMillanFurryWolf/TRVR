using UnityEngine;
using System.Collections;
/*
 *Universidad Tecnologica de Tecamac - Pedro Ramos Millan
 *Proposito: Manipular el menu de opciones del videojuego
 */
public class LevelManager : MonoBehaviour {
	public Transform menuPrincipal, menuOpcion;//Componentes de tipo Transform para los menus


	public void IniciarPartida(string nombreNivel){//Este metodo sirve para iniciar la partida
		Application.LoadLevel (nombreNivel);//Recibe como parametro el nombre del nivel
	}
	public void CargarPartida(string nombreActivity){//este metodo sirve para cargar la partida
		Application.LoadLevel (nombreActivity);
	}
	public void MOpciones(bool presionado){//Metodo encargado de llamar el menu de opciones
		if(presionado==true){
			menuOpcion.gameObject.SetActive(presionado);
			menuPrincipal.gameObject.SetActive(false);
			
		}else{
			menuOpcion.gameObject.SetActive(presionado);
			menuPrincipal.gameObject.SetActive (false);			
		}
	}	

	public void ConfigurarOpciones(string nA){
		Application.LoadLevel (nA);
	}
	public void Salir(){
		Application.Quit ();

}

}