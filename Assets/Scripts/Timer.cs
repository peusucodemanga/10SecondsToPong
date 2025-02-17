using UnityEngine;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class Timer1 : MonoBehaviour
{
    float tempoRestante=10f;

    [SerializeField] TextMeshProUGUI Timer;

    void Update()
    {
        tempoRestante -= Time.deltaTime;
        
        if (tempoRestante<=0){
            tempoRestante=10f;
        }
        
        Timer.text = tempoRestante.ToString("0");
        
    }
}
