using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public ScorePlayers novoScoreP1;
    public ScorePlayers novoScoreP2;

    void Start()
    {
        GameManager.instancia.scoreP1 = novoScoreP1;
        GameManager.instancia.scoreP2 = novoScoreP2;
        GameManager.instancia.UpdateScores();
    }
}
