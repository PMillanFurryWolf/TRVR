using UnityEngine;
using System.Collections;

	/*Pedro Ramos Millan
	Universidad Tecnologica de Tecamac  - Integradora
	Proposito: definir los checkpoints del juego y regresar al jugador a la pista si
	este se sale
 */

public class Checkpoints : MonoBehaviour {

	Vector3 check;
	void Start () {
		check = new Vector3 (0,7,0);
	}
	

	void Update () {
		if (transform.position.y < 8) {
			transform.position=check;
		}
	}
}
