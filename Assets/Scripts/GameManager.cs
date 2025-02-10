using UnityEngine;
public class GameManager : MonoBehaviour
{
    public int pontoP1, pontoP2;
    public ScorePlayers scoreP1, scoreP2;
    public void PontoMarcado(int id)
    {
        if (id == 1)
            pontoP1++;
        if (id == 2)
            pontoP2++;
        UpdateScores();
    }
    private void UpdateScores()
    {
        scoreP1.SetScore(pontoP1);
        scoreP2.SetScore(pontoP2);
    }
}