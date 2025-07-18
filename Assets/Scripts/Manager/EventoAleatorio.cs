using System.Collections;
using UnityEngine;

public class EventoAleatorio : MonoBehaviour
{
    public float intervalo = 10f; 
    private Legenda legenda;
    public GameObject golf;

    public void Start()
    {
        InvokeRepeating("AtivarEvento", intervalo, intervalo);
    }

    public void Reiniciar(){
        
            CancelInvoke("AtivarEvento");
            InvokeRepeating("AtivarEvento", intervalo, intervalo);
    }

    public void Parar(){
        
            CancelInvoke("AtivarEvento");
    }

    void AtivarEvento()
    {
        legenda = FindFirstObjectByType<Legenda>(); 
        int[] permitidos = { 0, 2, 3, 4, 5, 6}; // excluindo 3 e 5
        int evento = permitidos[Random.Range(0, permitidos.Length)];

        switch (evento)
        {
            case 0:
                //Evento: 1 bola extra
                GameManager.instancia.CriarNovaBola(golf);
                legenda.CarregarMensagens("case0");
                break;

            case 1:
                //Evento: 2 bolas extras
                GameManager.instancia.CriarNovaBola(golf);
                StartCoroutine(AguardarExecutar(() => GameManager.instancia.CriarNovaBola(golf), 1f));
                legenda.CarregarMensagens("case1");
                break;

            case 2:
                //Evento: Tela de TV
                EffectManager.instancia.TvBugada(new float[] { 0.5f, 2f, 0.5f, 1f, 0.5f, 2f, 0.5f, 1f, 0.5f });
                legenda.CarregarMensagens("case2");
                break;

            case 3:
                //Evento: Pong Classico
                SceneController.instancia.MudarParaScene(2, 8f);
                break;

            case 4:
                //Evento: BugCentro
                EffectManager.instancia.BugCentro();
                legenda.CarregarMensagens("case4");
                break;

            case 5:
                //Evento: tela preto e branco
                EffectManager.instancia.AtivarPretoEBranco(9f);
                legenda.CarregarMensagens("case5");
                break;

            case 6:
                //Evento: tv de tubo
                CameraController.instancia.MoverCamera();
                break;

            case 7:
                //Evento: tela invertida
                CameraController.instancia.Inverter(9f);
                legenda.CarregarMensagens("case7");
                break;
        }
    }

    private IEnumerator AguardarExecutar(System.Action metodo, float tempo)
    {
        yield return new WaitForSeconds(tempo);
        metodo?.Invoke();
    }
}
