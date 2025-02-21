using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vencedores : MonoBehaviour
{
    public int QGanhou;

    public RawImage P1;
    public RawImage P2;
    void Awake(){
        P1.enabled=false;
        P2.enabled=false;
        Time.timeScale=0f;
    }
    void Start(){
        QGanhou=PlayerPrefs.GetInt("Qganhou");
        Vencedor();
        

    }
    public void Vencedor(){

        if(QGanhou==0){
            P1.enabled=true;
        }
        if(QGanhou==1){
            P2.enabled=true;
        }
    }
    public void Reiniciar(){
        SceneManager.LoadSceneAsync(1);
    }
    public void Menu(){
        SceneManager.LoadSceneAsync(0);
    }
    public void SairJogo(){
        Application.Quit();

}

}