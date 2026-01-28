using UnityEngine;

public class PrimerScript : MonoBehaviour
{
    private int numeroEntero = 5;
    private float numeroDecimal = 7;
    private double decimalLargo= 8.4;
    private bool verdaderoFalse = false;
    //variable para almacenar texto
    private string cadenaTexto = "Hola";
    //variable para almacenar letras
    private char letra = 'a';

    public int[] intArray = new int [5] {2, 9, 5, 4, 3};

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        intArray[2] = 27;
        
        numeroEntero = 37;

        cadenaTexto = "Hola Mundo";

        Debug.Log(cadenaTexto);
        Debug.Log(numeroEntero);

        Calculo();
    }

    public void Calculo ()
    {
        numeroEntero = 7 + 5;
        numeroEntero = 2 - 7;
        numeroEntero = 6 * 9;
        numeroEntero = 4 / 3;

        numeroEntero = numeroEntero + 2;
        numeroEntero += 2;
        numeroEntero -= 2;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
