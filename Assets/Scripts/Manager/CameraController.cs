using System.Collections;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController instancia;
    public float zoomOutSize = 10f;
    public float duracaoMovimento = 1f;
    public float tempoEspera = 2f;
    public Transform destinoCamera;

    private Camera cam;
    private float zoomOriginal;
    private Vector3 posicaoOriginal;

    private bool invertida = false;
    public float tempoInvertido = 3f;

    void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        cam = Camera.main;
        zoomOriginal = cam.orthographicSize;
        posicaoOriginal = transform.position;
    }

    public void MoverCamera()
    {
        StartCoroutine(MoverEZoom());
    }

    private IEnumerator MoverEZoom()
    {
        Vector3 destinoCorrigido = new Vector3(destinoCamera.position.x, destinoCamera.position.y, posicaoOriginal.z);

        yield return StartCoroutine(MudarZoomEPosicao(zoomOriginal, zoomOutSize, posicaoOriginal, destinoCorrigido, duracaoMovimento));

        yield return new WaitForSeconds(tempoEspera);

        yield return StartCoroutine(MudarZoomEPosicao(zoomOutSize, zoomOriginal, destinoCorrigido, posicaoOriginal, duracaoMovimento));
    }

    private IEnumerator MudarZoomEPosicao(float zoomInicio, float zoomFim, Vector3 posicaoInicio, Vector3 posicaoFim, float duracao)
    {
        float tempoPassado = 0f;

        while (tempoPassado < duracao)
        {
            cam.orthographicSize = Mathf.Lerp(zoomInicio, zoomFim, tempoPassado / duracao);

            Vector3 novaPosicao = Vector3.Lerp(posicaoInicio, posicaoFim, tempoPassado / duracao);
            novaPosicao.z = posicaoOriginal.z; 

            transform.position = novaPosicao;
            tempoPassado += Time.deltaTime;
            yield return null;
        }

        cam.orthographicSize = zoomFim;
        transform.position = new Vector3(posicaoFim.x, posicaoFim.y, posicaoOriginal.z); 
    }

    public void Inverter(float tempo)
    {
        StartCoroutine(InverterPorTempo(tempo));
    }

    private IEnumerator InverterPorTempo(float tempo)
    {
        invertida = true;
        transform.rotation = Quaternion.Euler(0, 0, 180);

        yield return new WaitForSeconds(tempo);

        invertida = false;
        transform.rotation = Quaternion.Euler(0, 0, 0); 
    }
}
