using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public System.Action onReset;
    public int pontoP1, pontoP2;
    public ScorePlayers scoreP1, scoreP2;
    public GameObject bolaPrefab; 

    public Image ColorBar;
    private List<Bola> bolasAtivas = new List<Bola>(); 

    private void Awake()
    {
        if (instancia)
            Destroy(gameObject);
        else
            instancia = this;

            
    }

    void Start()
    {
        StartCoroutine(TvBugadaEvento(new float[]{0.25f}));
    }

    public void CriarNovaBola()
    {
        GameObject novaBola = Instantiate(bolaPrefab, Vector2.zero, Quaternion.identity);
        Bola bolaScript = novaBola.GetComponent<Bola>();
        bolasAtivas.Add(bolaScript);
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
    public void RemoverBola(Bola bola)
    {
        bolasAtivas.Remove(bola);

        if (bolasAtivas.Count == 0)
        {
            onReset?.Invoke(); 
            CriarNovaBola(); 
        }
        Destroy(bola.gameObject);
    }

    public void PontoMarcado(int id)
    {
        if (id == 1) pontoP1++;
        if (id == 2) pontoP2++;
        UpdateScores();
    }

    private void UpdateScores()
    {
        scoreP1.SetScore(pontoP1);
        scoreP2.SetScore(pontoP2);
    }
}
