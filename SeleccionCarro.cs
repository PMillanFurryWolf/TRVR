using UnityEngine;
using UnityEngine.UI;

public class SeleccionCarro : MonoBehaviour {

    /*Pedro Ramos Millán - Universidad Tecnológica de Tecámac
    Propósito: Permitir la selección de coches dentro del menú
        */
    //Cada uno de estos GameObjects representa un coche
	public GameObject carroA;
	public GameObject carroB;
	public GameObject carroC;
	public GameObject carroD;

	public static int valorCoche=0;
	public Text txtCarro;
   
     
    void Start()
    {
        loadA();
    }

	void Update(){
		carroA.transform.Rotate (0,0.15f,0);
		carroB.transform.Rotate (0,0.15f,0);
		carroC.transform.Rotate (0,0,0.15f);
		carroD.transform.Rotate (0,0.15f,0);
	}

    public void loadA()
    {

		carroA.SetActive(true);
        carroB.SetActive(false);
        carroC.SetActive(false);
		carroD.SetActive(false);
		txtCarro.text = "Dommy de pruebas";
		valorCoche = 1;
    }

    public void loadB()
    {

        carroA.SetActive(false);
        carroB.SetActive(true);
        carroC.SetActive(false);
		carroD.SetActive(false);
		txtCarro.text = "Coche de policía modificado";
		valorCoche = 2;

    }

    public void loadC()
    {

        carroA.SetActive(false);
        carroB.SetActive(false);
        carroC.SetActive(true);
		carroD.SetActive(false);
		txtCarro.text = "Chevrolet(R) Camaro 2016";
		valorCoche = 3;

    }
    public void loadD() {
        carroD.SetActive(true);
        carroA.SetActive(false);
        carroB.SetActive(false);
        carroC.SetActive(false);
		valorCoche = 4;

        txtCarro.text = "Murcielago(R) 2016";

    }

}
