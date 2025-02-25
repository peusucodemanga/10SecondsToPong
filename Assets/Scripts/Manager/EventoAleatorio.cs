using System.Collections;
using UnityEngine;

public class EventoAleatorio : MonoBehaviour
{
    public float intervalo = 10f; 
    private Legenda legenda;
    public GameObject golf;
    private void aux() => GameManager.instancia.CriarNovaBola(golf);

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
                GameManager.instancia.CriarNovaBola(golf);
                legenda.CarregarMensagens("case0");
                break;

            case 1:
                Debug.Log("Evento: 2 bolas extras");
                GameManager.instancia.CriarNovaBola(golf);
                StartCoroutine(AguardarExecutar(() => GameManager.instancia.CriarNovaBola(golf), 1f));
                legenda.CarregarMensagens("case1");
                break;

            case 2:
                Debug.Log("Evento: Tela de TV");
                EffectManager.instancia.TvBugada(new float[] { 0.5f, 2f, 0.5f, 1f, 0.5f, 2f, 0.5f, 1f, 0.5f });
                legenda.CarregarMensagens("case2");
                break;

            case 3:
                Debug.Log("Evento: Pong Classico");
                SceneController.instancia.MudarParaScene(2, 9f);
                break;

            case 4:
                Debug.Log("Evento: BugCentro");
                EffectManager.instancia.BugCentro();
                legenda.CarregarMensagens("case4");
                break;

            case 5:
                Debug.Log("Evento: criancas invadem campo");
                legenda.CarregarMensagens("case5");
                break;
        }
    }

    private IEnumerator AguardarExecutar(System.Action metodo, float tempo)
    {
        yield return new WaitForSeconds(tempo);
        metodo?.Invoke();
    }
}
