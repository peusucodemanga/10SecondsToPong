using UnityEngine;
using System.Collections.Generic;

public class Legenda : MonoBehaviour
{
    public TextoLegenda TextoLegendaPrefab;
    public float duracao = 5.0f;

    private List<string> mensagens = new List<string>();
    private float largura;
    private float pixelPorSegundo;
    private TextoLegenda textoAtual;
    private Queue<string> filaMensagens = new Queue<string>();

    void Start()
    {
        largura = GetComponent<RectTransform>().rect.width;
        pixelPorSegundo = largura / duracao;
    }

    public void CarregarMensagens(string nomeArquivo)
    {
        TextAsset arquivo = Resources.Load<TextAsset>(nomeArquivo);

        if (arquivo != null)
        {
            mensagens = new List<string>(arquivo.text.Split('\n')); 

            ResetarMensagens(); 
            EmbaralharMensagens();
            AdicionarTexto(filaMensagens.Dequeue());
        }
        else
        {
        }
    }

    void Update()
    {
        if (textoAtual != null && textoAtual.GetXPos <= -textoAtual.GetLargura)
        {
            if (filaMensagens.Count == 0)
                EmbaralharMensagens();

            string novaMensagem = filaMensagens.Dequeue();
            AdicionarTexto(" | " + novaMensagem);
        }
    }

    void AdicionarTexto(string texto)
    {
        if (textoAtual != null)
        {
            Destroy(textoAtual.gameObject); 
        }

        textoAtual = Instantiate(TextoLegendaPrefab, transform);
        textoAtual.Inicializar(largura, pixelPorSegundo, texto);
    }

    void EmbaralharMensagens()
    {
        filaMensagens.Clear();
        List<string> tempMensagens = new List<string>(mensagens);
        while (tempMensagens.Count > 0)
        {
            int index = Random.Range(0, tempMensagens.Count);
            filaMensagens.Enqueue(tempMensagens[index]);
            tempMensagens.RemoveAt(index);
        }
    }

    void ResetarMensagens()
    {
        filaMensagens.Clear();
        if (textoAtual != null)
        {
            Destroy(textoAtual.gameObject);
            textoAtual = null;
        }
    }
}
