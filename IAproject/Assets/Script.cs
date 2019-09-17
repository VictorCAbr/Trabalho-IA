using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Script : MonoBehaviour
{
    public GameObject SpriteVertices;
    public enum Telas { Menu, Grade, Arestas, Rota, IA }
    public Telas telas;
    private GameObject Vertice1, Vertice2, HoldVertice;
    public GameObject PontoChegada, PontoPartida;
    private GameObject[] Grafo = new GameObject[36];
    private GameObject[] Caminho = new GameObject[36];
    private Vector3[] Estradas = new Vector3[36];
    private float[] FilhosDistancia;
    [Range(2, 6)]
    public int NumeroLinhas;
    [Range(2, 6)]
    public int NumeroColunas;
    private string[] Nomes = { "PontoA", "PontoB", "PontoC", "PontoD", "PontoE", "PontoF", "PontoG", "PontoH", "PontoI", "PontoJ", "PontoK", "PontoL", "PontoM", "PontoN", "PontoO", "PontoP", "PontoQ", "PontoR", "PontoS", "PontoT", "PontoU", "PontoV", "PontoW", "PontoX", "PontoY", "PontoZ", "Ponto0", "Ponto1", "Ponto2", "Ponto3", "Ponto4", "Ponto5", "Ponto6", "Ponto7", "Ponto8", "Ponto9" };
    [HideInInspector]
    public float PontoXo = -7, DeltaX = 14, PontoYo = -4, DeltaY = 8, Passx, PassY;
    private int Cleaner = 0;
    public bool Enter;


    private Color vcor;
    private int coutg;
    private bool ChamaIA;

    public void ClickMe(GameObject vclick)
    {
        if (telas == Telas.Menu) { }
        else if (telas == Telas.Grade) { }
        else if (telas == Telas.Arestas)
        {
            if (HoldVertice == null)
            {
                HoldVertice = vclick;
                Vertice1 = PrimeiroPonto(HoldVertice);
            }
            else
            {
                HoldVertice = SegundoPonto(vclick);
            }
        }
        else if (telas == Telas.Rota)
        {
            if (PontoPartida == vclick)
                PontoPartida = null;
            else if (PontoChegada == vclick)
                PontoChegada = null;
            else if (PontoChegada == null)
                PontoChegada = vclick;
            else            if (PontoPartida == null)
                PontoPartida = vclick;
        }

    }
    GameObject PrimeiroPonto(GameObject p1)
    {
        vcor = p1.GetComponent<SpriteRenderer>().color;
        p1.GetComponent<SpriteRenderer>().color = Color.black;
        return p1;
    }
    GameObject SegundoPonto(GameObject p2)
    {
        float dx = (Vertice1.transform.position.x - p2.transform.position.x) / Passx;
        float DistX = dx * dx;
        float dy = (Vertice1.transform.position.y - p2.transform.position.y) / PassY;
        float DistY = dy * dy;

        if (DistX <= 1 && DistY <= 1 && (DistX != 0 || DistY != 0))
        {
            p2.GetComponent<SpriteRenderer>().color = Color.red;
            Vertice1.GetComponent<SpriteRenderer>().color = Color.red;
            if (p2.GetComponent<MyNameIs>().IndexVert < Vertice1.GetComponent<MyNameIs>().IndexVert)
                AddParentesco(p2, Vertice1);
            else
                AddParentesco(Vertice1, p2);
        }
        else
        {
            Vertice1.GetComponent<SpriteRenderer>().color = vcor;
        }
        return null;
    }
    void AddParentesco(GameObject nwpai, GameObject nwfilho)
    {
        bool brak = false;
        int i = 0;
        while (i < nwpai.GetComponent<MyNameIs>().Vizinho.Length && nwpai.GetComponent<MyNameIs>().Vizinho[i] != null)
        {
            if (nwpai.GetComponent<MyNameIs>().Vizinho[i] == nwfilho)
            {
                ApagarParentesco(nwpai, nwfilho);
                brak = true;
                break;
            }
            i++;
        }
        if (!brak)
            nwpai.GetComponent<MyNameIs>().Vizinho[i] = nwfilho;
    }
    void ApagarParentesco(GameObject nwpai, GameObject nwfilho)
    {
        int i = 0;
        while (i < nwpai.GetComponent<MyNameIs>().Vizinho.Length && nwpai.GetComponent<MyNameIs>().Vizinho[i] != nwfilho)
            i++;

        while (i < nwpai.GetComponent<MyNameIs>().Vizinho.Length && nwpai.GetComponent<MyNameIs>().Vizinho[i] != null)
        {
            nwpai.GetComponent<MyNameIs>().Vizinho[i] = nwpai.GetComponent<MyNameIs>().Vizinho[i + 1];
            i++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (telas == Telas.Menu)
        {
            Play();//botao play
        }
        else if (telas == Telas.Grade)
        {
            if (Input.GetKeyDown(KeyCode.Space))//botao criar
            {
                Enter = true;
                telas = Telas.Arestas;
            }
            if (Enter)
            {
                if (Cleaner > 0)
                {
                    //   GameObject lixo = GameObject.FindGameObjectWithTag("Vertices");
                    Debug.Log("foda-se");
                    // Destroy(lixo);
                    Cleaner--;
                }
                else
                {
                    Enter = false;
                    Passx = (DeltaX / (NumeroColunas - 1));
                    PassY = (DeltaY / (NumeroLinhas - 1));
                    for (int i = 0; i < NumeroColunas; i++)
                        for (int j = 0; j < NumeroLinhas; j++)
                        {
                            Vector3 Posicao = new Vector3(PontoXo + (i * Passx), PontoYo + (j * PassY), 0);
                            SpriteVertices.name = Nomes[(i * NumeroLinhas) + j];
                            SpriteVertices.GetComponent<MyNameIs>().IndexVert = (i * NumeroLinhas) + j;
                            Grafo[(i * NumeroLinhas) + j] =
                            Instantiate(SpriteVertices, Posicao, Quaternion.identity);
                            Cleaner++;
                        }

                }
            }
        }
        else if (telas == Telas.Arestas)
        {
            for (int i = 0; i < NumeroColunas * NumeroLinhas; i++)
            {
                bool TaSozinho = true;
                for (int j = 0; j < NumeroColunas * NumeroLinhas; j++)
                {
                    if (i != j)
                    {
                        GameObject pai, filho;
                        if (i < j)
                        {
                            pai = Grafo[i];
                            filho = Grafo[j];
                        }
                        else
                        {
                            pai = Grafo[j];
                            filho = Grafo[i];
                        }
                        for (int k = 0; k < pai.GetComponent<MyNameIs>().Vizinho.Length; k++)
                            if (pai.GetComponent<MyNameIs>().Vizinho[k] == filho)
                                TaSozinho = false;
                    }
                }
                if (TaSozinho && Grafo[i].GetComponent<SpriteRenderer>().color != Color.black)
                    Grafo[i].GetComponent<SpriteRenderer>().color = Color.white;
            }

            for (int p = 0; p < NumeroColunas * NumeroLinhas; p++)
            {
                coutg = p;
                if (Grafo[p].GetComponent<SpriteRenderer>().color != Color.red)
                    break;
            }

            // if (coutg + 1 == NumeroColunas * NumeroLinhas)
            if (Input.GetKeyDown(KeyCode.Space))//botao criar
                telas = Telas.Rota;
        }
        else if (telas == Telas.Rota)
        {
            for (int i = 0; i < NumeroColunas * NumeroLinhas; i++)
                if (Grafo[i] == PontoChegada)
                    PontoChegada.GetComponent<SpriteRenderer>().color = Color.blue;
                else if (Grafo[i] == PontoPartida)
                    PontoPartida.GetComponent<SpriteRenderer>().color = Color.green;
                else
                    Grafo[i].GetComponent<SpriteRenderer>().color = Color.red;

            if (PontoPartida != null && PontoChegada != null)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {//botao criar
                    telas = Telas.IA;
                    ChamaIA = true;
                }
            }
        }
        else if (telas == Telas.IA)
        {
            if (ChamaIA)
            {
                ChamaIA = false;
                GetComponent<IA>().CalcularRota(PontoPartida, PontoChegada, Grafo);
            }
        }
    }


    void Play()
    {
        telas = Telas.Grade;
    }

}

