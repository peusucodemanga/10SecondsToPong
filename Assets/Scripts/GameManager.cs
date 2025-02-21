using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public System.Action onReset;
    public int pontoP1, pontoP2;
    public ScorePlayers scoreP1, scoreP2;
    public GameObject bola1;
    public GameObject bola2;
    public GameObject bola3;
     private GameObject bolaAtual;

    public Image ColorBar;
    private List<Bola> bolasAtivas = new List<Bola>(); 
    private Legenda legenda;

    private void Awake()
    {
        if (instancia == null)
        {
            instancia = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded; 
    }

    private void Start()
    {
        legenda = FindFirstObjectByType<Legenda>(); 
        legenda.CarregarMensagens("padrao");
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        ColorBar = GameObject.Find("ColorBar")?.GetComponent<Image>(); 
        IniciarJogo();

        if (scene.buildIndex == 1 && ColorBar != null) 
        {
            StartCoroutine(TvBugadaEvento(new float[] {0.25f}));
        }
    }

    public void IniciarJogo()
    {
        Debug.Log(SceneManager.GetActiveScene().name);
        SelecionarBola();
        ResetarPartida();
        CriarNovaBola();
    }

    private void SelecionarBola()
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (sceneIndex == 1)
            bolaAtual = bola1;
        else if (sceneIndex == 2)
            bolaAtual = bola2;
        else
            bolaAtual = bola3;
    }

    private void ResetarPartida()
    {
        foreach (Bola bola in bolasAtivas)
        {
            if (bola != null)
                Destroy(bola.gameObject);
        }
        bolasAtivas.Clear();

        onReset?.Invoke(); 
    }

    public void CriarNovaBola()
    {
        GameObject novaBola = Instantiate(bolaAtual, Vector2.zero, Quaternion.identity);
        Bola bolaScript = novaBola.GetComponent<Bola>();
        bolasAtivas.Add(bolaScript);
    }

    public void CriarBolaGolf()
    {
        GameObject novaBola = Instantiate(bola3, Vector2.zero, Quaternion.identity);
        Bola bolaScript = novaBola.GetComponent<Bola>();
        bolasAtivas.Add(bolaScript);
    }

    public void RemoverBola(Bola bola)
    {
        bolasAtivas.Remove(bola);
        Destroy(bola.gameObject);

        if (bolasAtivas.Count == 0)
        {
            CriarNovaBola();
        }
    }

    public void PontoMarcado(int id)
    {
        if (id == 1) pontoP1++;
        if (id == 2) pontoP2++;
        UpdateScores();
    }

    public void UpdateScores()
    {
        scoreP1.SetScore(pontoP1);
        scoreP2.SetScore(pontoP2);
    }

    public void ReiniciarJogo()
    {
        pontoP1 = pontoP2 = 0;
        SceneManager.LoadScene(1);
    }

        public void TvBugada()
    {
        StartCoroutine(TvBugadaEvento(new float[]{0.5f, 2f, 0.5f, 1f, 0.5f, 2f, 0.5f, 1f, 0.5f}));
    }

    public IEnumerator TvBugadaEvento(float[] interrupcoes)
    {
        ColorBar.enabled = true;
        foreach (float interrupcao in interrupcoes)
        {
            yield return new WaitForSeconds(interrupcao);
            ColorBar.enabled = !ColorBar.enabled;
        }
    }
}
