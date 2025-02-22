using System.Collections;
using UnityEngine;

public class EventoAleatorio : MonoBehaviour
{
    public float intervalo = 10f; 
    private Legenda legenda;

    void Start()
    {
        InvokeRepeating("AtivarEvento", intervalo, intervalo);
    }

    public void Reiniciar(){
        
            CancelInvoke("AtivarEvento");
            InvokeRepeating("AtivarEvento", intervalo, intervalo);

    }

    void AtivarEvento()
    {
        legenda = FindFirstObjectByType<Legenda>(); 
        int evento = Random.Range(0, 5);

        switch (evento)
        {
            case 0:
                Debug.Log("Evento: 1 bola extra");
                GameManager.instancia.CriarBolaGolf();
                legenda.CarregarMensagens("case0");
                break;

            case 1:
                Debug.Log("Evento: 2 bolas extras");
                GameManager.instancia.CriarBolaGolf();
                GameManager.instancia.Invoke("CriarBolaGolf", 1f);
                legenda.CarregarMensagens("case1");
                break;

            case 2:
                Debug.Log("Evento: Tela de TV");
                GameManager.instancia.TvBugada();
                legenda.CarregarMensagens("case2");
                break;

            case 3:
                Debug.Log("Evento: Pong Classico");
                SceneController.instancia.MudarParaScene(2, 9f);
                break;

            case 4:
                Debug.Log("Evento: BugCentro");
                GameManager.instancia.BugCentro();
                legenda.CarregarMensagens("case4");
                break;

            case 5:
                Debug.Log("Evento: criancas invadem campo");
                legenda.CarregarMensagens("case5");
                break;
        }
    }
}
