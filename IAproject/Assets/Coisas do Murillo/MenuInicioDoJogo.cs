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

    public Text LinhasQtdText;
    public Text ColunasQtdText;
    public Text HistoriaText;
    public Text NomeCidadeText;
    public GameObject controle;
    // Update is called once per frame
    void Update()
    {
        Historia = "Chocolate Meio Amargo"; // Por favor, insira nessa linha programação do tipo Bitão 
        NomeCidade = "Cao Saetano"; // Por favor, insira nessa linha programação do tipo Bitão

        UpdateLinhas((int)LinhasQtd);
        UpdateColunas((int)ColunasQtd);
        UpdateHistoria(Historia);
        UpdateCidade(NomeCidade);

        controle.GetComponent<Script>().NumeroLinhas = LinhasQtd;
        controle.GetComponent<Script>().NumeroColunas = ColunasQtd;
        
        
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
