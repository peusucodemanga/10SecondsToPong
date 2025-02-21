using UnityEngine;

public class EventoAleatorio : MonoBehaviour
{
    public float intervalo = 10f; 

    void Start()
    {
        // Chama um evento aleatorio a cada 10 segs
        InvokeRepeating("AtivarEvento", intervalo, intervalo);
    }

    void AtivarEvento()
    {
        int evento = Random.Range(0, 4);

        switch (evento)
        {
            case 0:
                Debug.Log("Evento: 1 bola extra");
                GameManager.instancia.CriarBolaGolf();
                break;
            case 1:
                Debug.Log("Evento: 2 bolas extras");
                GameManager.instancia.CriarBolaGolf();
                GameManager.instancia.Invoke("CriarBolaGolf", 1f);
                break;
            case 2:
                Debug.Log("Evento: Tela de TV");
                GameManager.instancia.TvBugada();
                break;
            case 3:
                Debug.Log("Evento: Pong Classico");
                SceneController.instancia.MudarParaScene(2, 9f);
                break;
        }
    }
}
