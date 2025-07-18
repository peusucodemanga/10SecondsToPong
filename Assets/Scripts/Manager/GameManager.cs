using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

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
    private List<Bola> bolasAtivas = new List<Bola>();
    private Legenda legenda;
    private bool primeiraPartida = true;

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
        PlayerPrefs.SetInt("Player2", 0);
        PlayerPrefs.SetInt("Player1", 0);
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine(PausaAntesDeIniciarJogo());
    }

    private IEnumerator PausaAntesDeIniciarJogo()
    {
        yield return new WaitForSeconds(1f);
        IniciarJogo();
    }

    public void IniciarJogo()
    {
        SelecionarBola();
        ResetarPartida();
        CriarNovaBola(bolaAtual);

        if (primeiraPartida)
        {
            legenda = FindFirstObjectByType<Legenda>();
            if (legenda)
            {
                legenda.CarregarMensagens("padrao");
                primeiraPartida = false;
            }
        }
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

    public void CriarNovaBola(GameObject bola)
    {
        GameObject novaBola = Instantiate(bola, Vector2.zero, Quaternion.identity);
        Bola bolaScript = novaBola.GetComponent<Bola>();
        bolasAtivas.Add(bolaScript);
    }

    public void RemoverBola(Bola bola)
    {
        bolasAtivas.Remove(bola);
        Destroy(bola.gameObject);

        if (bolasAtivas.Count == 0)
        {
            CriarNovaBola(bolaAtual);
        }
    }

    public void PontoMarcado(int id)
    {
        if (id == 1) pontoP1++;
        if (id == 2) pontoP2++;
        UpdateScores();
        Vencedor();
    }

    public void UpdateScores()
    {
        if (scoreP1 != null) scoreP1.SetScore(pontoP1);
        if (scoreP2 != null) scoreP2.SetScore(pontoP2);
    }

    public void ReiniciarJogo()
    {
        primeiraPartida = true;
        pontoP1 = pontoP2 = 0;
        EventoAleatorio evento = FindFirstObjectByType<EventoAleatorio>();
        if (evento){
            evento.Reiniciar();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Vencedor()
    {
        if (pontoP1 >= 10)
        {
            PlayerPrefs.SetInt("Player1", 1);
            ReiniciarJogo();
            EventoAleatorio evento = FindFirstObjectByType<EventoAleatorio>();
            if (evento){
                evento.Parar();
            }
            SceneManager.LoadSceneAsync(3);
            
        }
        else if (pontoP2 >= 10)
        {
            PlayerPrefs.SetInt("Player2", 1);
            ReiniciarJogo();
            EventoAleatorio evento = FindFirstObjectByType<EventoAleatorio>();
            if (evento){
                evento.Parar();
            }
            SceneManager.LoadSceneAsync(3);
        }
    }
}
