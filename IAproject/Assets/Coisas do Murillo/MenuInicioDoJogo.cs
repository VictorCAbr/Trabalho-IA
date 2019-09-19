using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicioDoJogo : MonoBehaviour
{
    private int LinhasQtd=2;
    private int ColunasQtd=2;
    private string Historia;
    private string NomeCidade;
    [Range(0, 15)]
    public float TempoLeitura=5;
    public int Leitor;
    private float tempo;
    public GameObject[] Percuso = new GameObject[36];
    public GameObject Player;
    
    #region historias
    private string[] AsHistorias = {"Essa cidade não tem nada, pois o roteirista não foi pago para fazer o texto da mesma","Texto – Avalon","Texto – Mareleus","Texto – Budeske","Texto – Mrah","Texto – Kutayacebe","Texto – Insomnia","Texto – Noveria","Texto – Shangri-la","Texto – Kirkwall","Texto – Echo","Texto – Winterfell","exto – Markarth","Texto – Yharnam","Texto – Cão Saetano","Texto – Pahral","Texto – Elpípido","Texto – Siúa",
        "Texto - Vault 76","autilus","Texto – Rabanastre","Texto – Bevelle","Texto – Ala Mhigo",  "Texto – Baron","Texto – Midgar","Texto – Serdin","Texto – Nilfheim","Texto – Thundera","Texto – Naboo","Texto – Hogwarts","Texto – Eitah","Texto – Canaban","Texto – Konoha","Texto – Orleau","Texto – Tevinter","Texto – Eden" };

    #endregion   
    #region cidades
    public string[] AsCidades =
    {"Orlandia","Avalon","Maraleus","Budeske","Mrah","Kutaya","Insomnia","Noveria","Shangri-la","Kirkwall","Echo","Winterfell","Markarth","Yharnam"," Cão Saetano","Pahral","Elpípido","Siúa",
"Vault 76","Nautilus","Rabanastre","Bevelle","Ala","Mhigo","Baron","Midgar","Serdin","Nilfheim","Thundera","Naboo","Hogwats","Eitah","Canaban","Konoha","Orleau","Tevinter","Eden"
    };
    #endregion
    public Text LinhasQtdText;
    public Text ColunasQtdText;
    public Text HistoriaText;
    public Text NomeCidadeText;
    public GameObject controle;
    // Update is called once per frame
    void Update()
    {
       // Historia = "Chocolate Meio Amargo"; // Por favor, insira nessa linha programação do tipo Bitão 
       // NomeCidade = "Cao Saetano"; // Por favor, insira nessa linha programação do tipo Bitão

        UpdateLinhas((int)LinhasQtd);
        UpdateColunas((int)ColunasQtd);
        UpdateHistoria(Historia);
        UpdateCidade(NomeCidade);

        controle.GetComponent<Script>().NumeroLinhas = LinhasQtd;
        controle.GetComponent<Script>().NumeroColunas = ColunasQtd;

        if (controle.GetComponent<Script>().telas == Script.Telas.Fim)
            Aventurando();
        else
        {
            Leitor = 0;
            tempo = 0;
            Percuso[0] = null;
            Player.transform.position = new Vector3(-38, 8, 0);
        }
    }
    void GetPercuso()
    {
        for (int i = 0; i < Percuso.Length; i++)
            Percuso[i] = controle.GetComponent<IA>().Caminho[i];
    }
    void Aventurando()
    {
        if (Percuso[0] == null)
            GetPercuso();
        if (Percuso[Leitor] != null)
        {
            tempo += Time.deltaTime;
            int ler = Percuso[Leitor].GetComponent<MyNameIs>().IndexVert;
            NomeCidade = AsCidades[ler];
            Historia = AsHistorias[ler];
            Player.transform.position = Percuso[Leitor].transform.position;

            if (tempo > TempoLeitura)
            {
                tempo = 0;
                Leitor++;
            }
        }

    }
    public void UpdateLinhas(int LinhasQtd)
    {
        LinhasQtdText.text = "" + LinhasQtd;
    }

    public void UpdateColunas(int ColunasQtd)
    {
        ColunasQtdText.text = "" + ColunasQtd;
    }

    public void UpdateHistoria(string historia)
    {
        HistoriaText.text = Historia;
    }

    public void UpdateCidade(string NomeCidade)
    {
        NomeCidadeText.text = NomeCidade;
    }

    public void ColetarLinhas(float linhas)
    {
        LinhasQtd = ((int)(linhas * 4) + 2);
    }
    public void ColetarColuna(float colunas)
    {
        ColunasQtd = ((int)(colunas * 4) + 2);
    }
}
