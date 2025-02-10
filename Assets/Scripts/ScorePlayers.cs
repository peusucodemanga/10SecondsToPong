using UnityEngine;
using TMPro;
public class ScorePlayers : MonoBehaviour
{
    public TextMeshProUGUI text;
    public void SetScore(int value)
    {
        text.text = value.ToString();
    }
}
