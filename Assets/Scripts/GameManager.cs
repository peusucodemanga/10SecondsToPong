using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instancia;
    public System.Action onReset;
    public int pontoP1, pontoP2;
    public ScorePlayers scoreP1, scoreP2;
    public GameObject bolaPrefab; 

    private List<Bola> bolasAtivas = new List<Bola>(); 

    private void Awake()
    {
        if (instancia)
            Destroy(gameObject);
        else
            instancia = this;
    }

    public void CriarNovaBola()
    {
        GameObject novaBola = Instantiate(bolaPrefab, Vector2.zero, Quaternion.identity);
        Bola bolaScript = novaBola.GetComponent<Bola>();
        bolasAtivas.Add(bolaScript);
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
