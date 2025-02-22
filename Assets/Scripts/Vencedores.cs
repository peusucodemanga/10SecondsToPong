using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Vencedores : MonoBehaviour
{
    public int QG1,QG2;

    public RawImage P1;
    public RawImage P2;
    void Awake(){
        P1.enabled=false;
        P2.enabled=false;
        Time.timeScale=0f;
    }
    void Start(){
        QG1=PlayerPrefs.GetInt("Player1");
        QG2=PlayerPrefs.GetInt("Player2");
        Vencedor();
        

    }
    public void Vencedor(){

        if(QG1==1){
            P1.enabled=true;
            Time.timeScale=0f;
            Debug.Log("2");
        }
        if(QG2==1){
            P2.enabled=true;
            Time.timeScale=0f;
            Debug.Log("2");
        }
    }
    public void Reiniciar(){
        Time.timeScale = 1f; 
        SceneManager.LoadScene(1);
    }
    public void Menu(){
        SceneManager.LoadSceneAsync(0);
    }
    public void SairJogo(){
        Application.Quit();

}

}