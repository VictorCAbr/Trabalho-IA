using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyNameIs : MonoBehaviour
{
    public int IndexVert;
    public Vector3 Posi;
    public GameObject MeuPai;
    public GameObject[] Vizinho = new GameObject[5];
    public Vector3[] positions = new Vector3[9];
    public enum Busca { Branco, Cinza, Preto}
    public Busca busca;
    private LineRenderer lr;
    private Color c;

    void OnMouseDown()
    {
        // Debug.Log("bvf");
      //  Debug.Log(gameObject);
        GameObject.Find("Objeto Controle").GetComponent<Script>().ClickMe(gameObject);
    }
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = 9;
        busca = Busca.Branco;
    }
    // Update is called once per frame
    void Update()
    {
        int j = 0;
        for (int i = 0; i < 9; i++)
        {
            if (i % 2 == 1 && Vizinho[j] != null)
            {
                positions[i] = Vizinho[j].transform.position;
                j++;
            }
            else
                positions[i] = transform.position;
        }
        lr.SetPositions(positions);



    }
}
