using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IA : MonoBehaviour
{
    public GameObject[] MeuGrafo = new GameObject[36];
    private bool NotFound=false;
    private bool Trabalhando;
    public GameObject[] Caminho = new GameObject[36];
    public GameObject[] Filhos = new GameObject[8];
    private Vector3[] Estradas = new Vector3[36];
    private GameObject PontoPartida;
    public GameObject PontoChegada;
    public GameObject PontoBusca;
    public GameObject PontoNext;
    public GameObject PontoAnterior;
    private float MenorDistancia;
    private float MenorMahattan;
    private float MenorPeso;
    public float PercorridaDistancia, PercorridaManhattan, PercorridaPeso;
    public int Casas;
    private Color c;
    private float largux;
    private float larguy;
    public Text MatrizTxt;
    public Text DistanciaTxt;
    private string stgMatriz;
    private string stgDistancia;



    private int NumMax;
    private float TT=0.25f, tt;
    private string[] Nomes = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z", "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" };



    void Update()
    {
        CriarMatriz();
        GetComponent<Script>().NaoChega = NotFound;

        if (PontoPartida != null && PontoChegada != null && GetComponent<Script>().telas == Script.Telas.IA )
        {
            #region ia
            Trabalhando = (PontoBusca != PontoChegada);
            if (Trabalhando && !NotFound)
            {
                if (PontoBusca != null)
                {
                    int mf = 0;
                    for (mf = 0; mf < Filhos.Length; mf++) //limpar os filhos do ponto de busca
                        Filhos[mf] = null;
                    mf = 0;
                    #region Achar os filhos do PONTO DE BUSCA
                    for (int ig = 0; ig < PontoBusca.GetComponent<MyNameIs>().IndexVert; ig++)
                        if (MeuGrafo[ig] != null)
                        {
                            for (int kv = 0; kv < MeuGrafo[ig].GetComponent<MyNameIs>().Vizinho.Length; kv++)
                                if (MeuGrafo[ig].GetComponent<MyNameIs>().Vizinho[kv] == PontoBusca
                                    && MeuGrafo[ig].GetComponent<MyNameIs>().busca != MyNameIs.Busca.Preto)
                                {
                                    while (Filhos[mf] != null)
                                        mf++;
                                    Filhos[mf] = MeuGrafo[ig];
                                }
                        }
                    for (int kv = 0; kv < PontoBusca.GetComponent<MyNameIs>().Vizinho.Length; kv++)
                        if (PontoBusca.GetComponent<MyNameIs>().Vizinho[kv] != null
                         && PontoBusca.GetComponent<MyNameIs>().Vizinho[kv].GetComponent<MyNameIs>().busca != MyNameIs.Busca.Preto)
                        {
                            while (Filhos[mf] != null)
                                mf++;
                            Filhos[mf] = PontoBusca.GetComponent<MyNameIs>().Vizinho[kv];
                        }
                    #endregion
                    #region Atulaizar 'COR' (PRETO/CINZA) do Ponto de busca
                    PontoBusca.GetComponent<MyNameIs>().busca = MyNameIs.Busca.Preto;
                    for (mf = 0; mf < Filhos.Length; mf++)
                        if (Filhos[mf] != null)
                            if (Filhos[mf].GetComponent<MyNameIs>().busca == MyNameIs.Busca.Branco)
                                PontoBusca.GetComponent<MyNameIs>().busca = MyNameIs.Busca.Cinza;
                    #endregion
                    #region Achar o mais PROXIMO DA CHEGADA
                    PontoNext = null;
                    MenorDistancia = CalcularDistancia(PontoChegada, PontoPartida) * 2;
                    for (mf = 0; mf < Filhos.Length; mf++)
                        if (Filhos[mf] != null)
                            if ((PontoBusca.GetComponent<MyNameIs>().busca == MyNameIs.Busca.Cinza
                            && Filhos[mf].GetComponent<MyNameIs>().busca == MyNameIs.Busca.Branco)
                            || PontoBusca.GetComponent<MyNameIs>().busca == MyNameIs.Busca.Preto)
                                if (MenorDistancia > CalcularDistancia(PontoChegada, Filhos[mf]))
                                {
                                    MenorDistancia = CalcularDistancia(PontoChegada, Filhos[mf]);
                                    PontoNext = Filhos[mf];
                                }
                    NotFound = (PontoNext == null);
                    #endregion
                    #region Define quem é o PAI na ARVORE
                    if (PontoNext != null)
                        if (PontoNext.GetComponent<MyNameIs>().MeuPai == null)
                            PontoNext.GetComponent<MyNameIs>().MeuPai = PontoBusca;
                    #endregion
                    Colorir();
                    PontoAnterior = PontoBusca;
                    PontoBusca = PontoNext;
                }
            }
            else
            {
                #region Finaliza e atualiza o resultado
                if (PontoBusca != null)
                    AddCasaNoCaminho(PontoBusca);
                if (!NotFound)
                    GetComponent<Script>().telas = Script.Telas.Fim;
                CriarMatriz();
                PontoBusca = PontoPartida;
                #endregion

            }
            #endregion
            int casas = 0;
            for (int i = 0; i < Caminho.Length; i++)
                if (Caminho[i] != null)
                {
                    Estradas[i] = Caminho[i].transform.position;
                    casas++;
                }
                else if (!Trabalhando) Estradas[i] = PontoChegada.transform.position;
                else Estradas[i] = new Vector3(0, 5, 0);
            GetComponent<LineRenderer>().positionCount = casas;
            GetComponent<LineRenderer>().SetPositions(Estradas);
        }
        else if(GetComponent<Script>().telas !=Script.Telas.Fim)
            GetComponent<LineRenderer>().positionCount = 0;
        
    }
    private void AddCasaNoCaminho(GameObject PontoNew)
    {
        PontoPartida.GetComponent<MyNameIs>().MeuPai = null;
        PercorridaDistancia = 0;
        PercorridaManhattan = 0;
        PercorridaPeso = 0;
        int i = 0;
        Caminho[i] = PontoChegada;
        while (Caminho[i] != PontoPartida && i<Caminho.Length)
        {
            i++;
            Caminho[i] = Caminho[i - 1].GetComponent<MyNameIs>().MeuPai;
            PercorridaDistancia += CalcularDistancia(Caminho[i] , Caminho[i - 1]);
            PercorridaManhattan += CalcularManhattan(Caminho[i], Caminho[i - 1]);
            PercorridaPeso += CalcularPeso(Caminho[i], Caminho[i - 1]);
        }
        CriarTxtDistancia();
    }
    private void CriarMatriz()
    {

        stgMatriz = "    ";
        if (MeuGrafo[0] != null)
            NumMax = GetComponent<Script>().NumeroColunas * GetComponent<Script>().NumeroLinhas;
        else
        {
            tt += Time.deltaTime;
            if (tt > TT)
            {
                NumMax++;
                tt = 0;
            }
            if (NumMax > 20)
                NumMax = 0;
            // NumMax = 16;
        }
        for (int i = 0; i < NumMax; i++)
            stgMatriz += " | " + Nomes[i] + " |";
        // stgMatriz += "\n";
        for (int j = 0; j < NumMax; j++)
        {
            stgMatriz += "\n";
            stgMatriz += "" + Nomes[j] + " ";
            for (int i = 0; i < NumMax; i++)
            {
                stgMatriz += " | ";
                if (i < j)
                    stgMatriz += " _";
                else
                {
                    bool ZeroUm = ((i + j) % 2 == 1);

                    if (i == j)
                        ZeroUm = false;
                    else {
                        if (MeuGrafo[i] != null)
                            if(true)
                        {
                            ZeroUm = false;
                            for (int k = 0; k < MeuGrafo[j].GetComponent<MyNameIs>().Vizinho.Length; k++)
                                if (MeuGrafo[j].GetComponent<MyNameIs>().Vizinho[k] == MeuGrafo[i])
                                    ZeroUm = true;
                        }
                    }

                    if (ZeroUm) stgMatriz += " ";
                    stgMatriz += ZeroUm ? 1 : 0;
                }
                stgMatriz += " |";
            }

        }
        MatrizTxt.text = stgMatriz;


    }
    private void CriarTxtDistancia()
    {
        float Dm = 0;
        if (PontoChegada != null && PontoPartida != null)
            Dm = CalcularManhattan(PontoPartida, PontoChegada);
        stgDistancia = "Algoritmo usado:   A*  com auxilio do Depth-First Search.\n\n";
        stgDistancia += "Distancia percorrida:   " + PercorridaDistancia + ".\n\n";
        stgDistancia += "Distancia Manhattan do Ponto Inicial ao Ponto Final:   " + Dm + ".\n\n";
        stgDistancia += "Cidades percorridas:";
        for (int i = 0; i < Caminho.Length; i++)
            if (Caminho[i] != null)
            {
                if (i != 0)
                {
                    if (Caminho[i + 1] == null)
                        stgDistancia += "    e ";
                    else
                        stgDistancia += " , ";
                }
                if (i % 10 == 0)
                    stgDistancia += "\n\n";
                stgDistancia += "   " + GameObject.Find("Canvas").GetComponent<MenuInicioDoJogo>().AsCidades[Caminho[i].GetComponent<MyNameIs>().IndexVert];
            }
        stgDistancia += ".\n\n";
        DistanciaTxt.text = stgDistancia;
    }
    public void CalcularRota(GameObject pfim, GameObject pcomeca, GameObject[] grafo)
    {
        largux = GetComponent<Script>().Passx;
        larguy = GetComponent<Script>().PassY;
        PontoChegada = pfim;
        PontoPartida = pcomeca;
        MeuGrafo = grafo;
        PontoBusca = PontoPartida;
        NotFound = false;
        Casas = 0;
        PercorridaDistancia = 0;
        PercorridaManhattan = 0;
        PercorridaPeso = 0;
        for (int i = 0; i < Caminho.Length; i++)
            Caminho[i] = null;
        for (int i = 0; i < MeuGrafo.Length; i++)
        {
            MeuGrafo[i].GetComponent<MyNameIs>().busca = MyNameIs.Busca.Branco;
            MeuGrafo[i].GetComponent<MyNameIs>().MeuPai = null;
        }
    }
    float CalcularDistancia(GameObject PontoA, GameObject PontoB)
    {
        float xA = PontoA.transform.position.x;
        float yA = PontoA.transform.position.y;
        float xB = PontoB.transform.position.x;
        float yB = PontoB.transform.position.y;
        float xD = (xB - xA)/largux;
        float yD = (yB - yA)/larguy;
        float Distancia;

        Distancia = Mathf.Sqrt((xD * xD) + (yD * yD));
        return Distancia;
    }
    float CalcularManhattan(GameObject PontoA, GameObject PontoB)
    {
        float xA = PontoA.transform.position.x;
        float yA = PontoA.transform.position.y;
        float xB = PontoB.transform.position.x;
        float yB = PontoB.transform.position.y;
        float xD = (xB - xA) / largux;
        float yD = (yB - yA) / larguy;
        float Manhattan;
        //dm = | x1 - x2 | + | y1 - y2 |
        Manhattan = Mathf.Sqrt(xD * xD) + Mathf.Sqrt(yD * yD);

        return Manhattan;
    }
    float CalcularPeso(GameObject PontoA, GameObject PontoB)
    {
        float xA = PontoA.transform.position.x;
        float yA = PontoA.transform.position.y;
        float xB = PontoB.transform.position.x;
        float yB = PontoB.transform.position.y;
        float xD;
        float yD;
        float Peso;

        if (xA == xB)
            xD = 0;
        else xD = 1;
        if (yA == yB)
            yD = 0;
        else yD = 1;


        Peso = Mathf.Sqrt(xD + yD);
        return Peso;
    }
    void Colorir()
    {
        for (int i = 0; i < MeuGrafo.Length; i++)
            if (MeuGrafo[i] != null)
            {
                Color c = Color.red;
                if (MeuGrafo[i] == PontoChegada)
                    c = Color.green;
                else if (MeuGrafo[i] == PontoPartida)
                    c = Color.blue;
                if(MeuGrafo[i].GetComponent<MyNameIs>().busca==MyNameIs.Busca.Branco)
                {
                    if (MeuGrafo[i] == PontoNext && PontoNext != null)
                        c = Color.cyan;
                    //else if (MeuGrafo[i] == PontoAnterior && PontoAnterior != null)
                    //{
                    //    c = Color.magenta; Debug.Log(PontoAnterior);
                    //}
                }

                MeuGrafo[i].GetComponent<SpriteRenderer>().color = c;
            }
    }
}