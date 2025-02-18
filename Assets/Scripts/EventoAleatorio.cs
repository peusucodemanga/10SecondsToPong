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
        int evento = Random.Range(0, 3);

        switch (evento)
        {
            case 0:
                Debug.Log("Evento: 1 bola extra");
                GameManager.instancia.CriarNovaBola();
                break;
            case 1:
                Debug.Log("Evento: 2 bolas extras");
                GameManager.instancia.CriarNovaBola();
                GameManager.instancia.Invoke("CriarNovaBola", 1f);
                break;
            case 2:
                Debug.Log("Evento: ");
                break;
        }
    }
}
