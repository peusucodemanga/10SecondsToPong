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
            Debug.Log($"Mensagens carregadas de: {nomeArquivo}");

            ResetarMensagens(); // 🔥 Reset total ao carregar novas mensagens

            // Adiciona todas as mensagens na fila aleatoriamente
            EmbaralharMensagens();
            AdicionarTexto(filaMensagens.Dequeue());
        }
        else
        {
            Debug.LogError($"❌ Arquivo não encontrado: {nomeArquivo}");
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
            Destroy(textoAtual.gameObject); // 🔥 Remove o texto anterior antes de criar um novo
        }

        textoAtual = Instantiate(TextoLegendaPrefab, transform);
        textoAtual.Inicializar(largura, pixelPorSegundo, texto);
    }

    void EmbaralharMensagens()
    {
        filaMensagens.Clear(); // 🔥 Garante que a fila está vazia antes de embaralhar
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
        filaMensagens.Clear(); // Limpa a fila de mensagens
        if (textoAtual != null)
        {
            Destroy(textoAtual.gameObject); // 🔥 Remove qualquer texto visível na tela
            textoAtual = null;
        }
    }
}
