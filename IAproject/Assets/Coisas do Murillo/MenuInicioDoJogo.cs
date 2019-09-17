using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicioDoJogo : MonoBehaviour
{
    private int LinhasQtd;
    private int ColunasQtd;
    private string Historia;
    private string NomeCidade;

    public Text LinhasQtdText;
    public Text ColunasQtdText;
    public Text HistoriaText;
    public Text NomeCidadeText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LinhasQtd += 1;
        ColunasQtd += 2;
        Historia = "Chocolate Meio Amargo"; // Por favor, insira nessa linha programação do tipo Bitão 
        NomeCidade = "Cao Saetano"; // Por favor, insira nessa linha programação do tipo Bitão

        UpdateLinhas((int)LinhasQtd);
        UpdateColunas((int)ColunasQtd);
        UpdateHistoria(Historia);
        UpdateCidade(NomeCidade);
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
}
