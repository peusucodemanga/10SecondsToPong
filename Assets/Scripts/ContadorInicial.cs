using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class ContadorInicial : MonoBehaviour
{
public int Contador;
public Text ContadorDisplay;

private void Start(){
    StartCoroutine(ContadorIni());
}

IEnumerator ContadorIni(){

while (Contador>0){
ContadorDisplay.text = Contador.ToString();
yield return new WaitForSeconds(1f);
Contador--;
}

//Bola.InicioPartida();
    
ContadorDisplay.text = "VAI!";




yield return new WaitForSeconds(1f);

ContadorDisplay.gameObject.SetActive(false);

}
}

