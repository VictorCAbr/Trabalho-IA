using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuInicioDoJogo : MonoBehaviour
{
    public int LinhasQtd=2;
    public int ColunasQtd=2;
    public int ArestaQtd = 2000;
    private int MaxAresta, MinAresta=1;
    private string Historia;
    private string NomeCidade;
    [Range(0, 15)]
    public float TempoLeitura=5;
    public int Leitor;
    private float tempo;
    public GameObject[] Percuso = new GameObject[36];
    public GameObject Player;

    #region historias
    private string[] AsHistorias = {"Essa cidade não tem nada, pois o roteirista não foi pago para fazer o texto da mesma","Você chegou em Avalon, o feudo conhecido por suas guerreiras corajosas e de coração nobre.\nVocê comprou a espada She-lia (-75 moedas), no qual pertencia a uma guerreira com o mesmo nome, que há muito deixou essas terras. \n","Bem-vindo á Mareleus, uma cidade portuária conhecida pelos seus piratas excêntricos.\n Enquanto estava no bar, você sente com sorte e decide jogar Faronora. As coisas acabam indo de mal a pior e começa uma briga de bar. Você consegue fugir, mas perdeu 100 moedas no caminho. \n","Você começa a sentir cheiro de cerveja no ar, e então sabe onde poderia ser. Budeske, a cidade das cervejarias. \nPara melhorar a situação, era o dia da Budesfest, o dia de rodízio de cervejas. Você gasta, sem arrependimentos, 25 moedas para entrar. \n","Os cidadãos de Mrah te dão boas vindas, uma cidade calorosa com uma cultura a agricultura. \nVocê decide comprar suprimentos (-30 moedas) para continuar a viagem. \n","Bem-vindo a Kutaya, uma vila conhecida pela seus cogumelos Kuts. \nVocê decide experimentar um, cortesia do produtor. Ao comer você sente meio tonto. \nAo acordar percebe que sumiu 50 moedas de sua bolsa. \n","Você chega nas portas de Insomnia, uma cidade exuberante e exagerada em tamanho e perfeição. \nPara entrar, deve se pagar uma tarifa de 500 moedas. \nPor ser muito caro, você decide ficar fora dos muros. \n","No meio das cordilheiras frias, você encontra Noveria, uma cidade tão hospitaleira quanto seu clima. \n Foi necessário pagar as autoridades cidade para eles parassem de coagir você. Você gastou 60 moedas. \n","Depois de estar muito perdido, você se depara com uma cidade esquecida pelo tempo. Shangri-la, a cidade paradisíaca. \nInfelizmente, você não encontrou ninguém, a cidade estava em ruínas. A sombra do que já foi. \n","Ao adentrar em um desfiladeiro, onde havia várias correntes gigantes e estátuas presas a ela você se arrepende imediatamente de onde está se aproximando. \nVocê chega em Kirkwall, a última cidade-estado do mundo que ainda permite a escravidão. \nVocê decide comprar e libertar o maior número de escravos o possível. Cada um custando 1 moeda. \nAo comprar 250 (-250 moedas), você os liberta na fronteira da cidade. \n","No meio de um deserto escaldante, você chega num pequeno vilarejo chamado Echo, conhecido pelo histórico de inúmeros ataques de histeria. \nReceoso, você dorme na estalagem lá por um dia, custando 10 moedas. \n","O frio de Winterfell te da boas-vindas, a cidade mais antiga de todo o mundo conhecido. \nVocê decide dormir na estalagem Pedriburg, onde o grande NitHawer já dormiu. \nVocê paga 100 moedas para passar a noite no mesmo quarte que ele o herói de eras atrás dormiu.","Você encontra com uma montanha de formação estranha. Olhando melhor, você vê que na verdade é uma cidade, Markarth, a cidade feita por anões. \nAo entrar, você se deparou com um assassinato. Por estar na cena do crime os guardas, os guardas o mantem na cidade. \nPara conseguir sair, você teve de subornar “voluntariamente” sua saída, custando 75 moedas. \n","Você teve o infortúnio de chegar em Yarhamn, a cidade tomada por bestas. O lugar é conhecido pelas suas caçadas de monstros nas ruas da cidade que vive em constante medo. \nCaçadores de todo o mundo vêm para caça e coletar espólios. \nApós participar da caça, você ganha 200 moedas em espólios. \n","Bem-Vindo a Cão Saetano, a pequena vila de idosos. Todos os jovens deixaram esse lugar indo em busca de aventuras. \nVocê come comida caseira de vó, gastando 5 moedas, mas ganha um buxo cheio e saudades de casa. \n","Phral, a cidade portuária conhecida pelo seu farol de tamanho colossal, te da boas-vindas. \nO dia se encontrava nebuloso, e nevoa se alastrava por todos os cantos. Até que você escuta dos cidadãos que alguém precisaria subir até o farol para acendê-lo, antes que um navio errasse o caminho ao porto, ou pior. \nApós todo o esforço exaustante de chegar até o topo, você acende a pira do farol, salvando um navio mercante bem a tempo. \nUm dos mercadores o recompensa com 300 moedas por tê-lo salvado. \n","Ao se aproximar de uma cidade, você vê uma placa em sua entrada: Elpípido, a maior cidade mercantil desse lado do mundo. \n A cidade tem as mais variadas quinquilharias e especiarias, e você decide comprar algumas. No final do dia, foi gasto 120 moedas. \n","Após atravessar quilômetros de deserto imperdoável e infernal. Você se aproxima de um vilarejo em torno de um oásis. Você corre como desesperadamente para matar sua sede. \nAo chegar perto do lago, tudo some com um vento. Era uma miragem. \nVocê se levanta despombalizado e volta a andar sem rumo no deserto nada misericordioso. \n","Enquanto caminha numa floresta, você tropeça numa plataforma de metal. Ela começa a se me mexer e posteriormente se abre. Ao adentrar no buraco recém surgido, você encontra pessoas vivendo normalmente lá. \nDepois de escutar sobre o que era aquele lugar e por que eles estavam lá, os cidadãos do abrigo pedem para você eliminar baratas radioativas do lugar. Após o trabalho de dedetização, você é pago com 50 moedas. \n","Bem-vindo a Nautilus, a cidade dos sonhos. A cidade onde o entretenimento, festas e casinos reinam. Com tantas opções de diversão você passa a noite fazendo tudo o que está no alcance. \nDepois de perder em 100 ouros em fichas, você tenta sua sorte mais uma vez numa máquina caça-níquel. Felizmente, o destino estava seu favor nessa vez. Você ganha 1000 ouros. \n","No meio de uma planície seca e rasteira, você encontra Rabanastre, uma cidade oásis com uma arquitetura sublime. Você vai até uma das estalagens e percebe que eles precisam de suprimentos, mas o comboio ainda não chegou na cidade. \nVocê deixa a cidade a procura do comboio, e encontra ele num deserto das redondezas, dominado por monstros que parecem cactos. Após espantá-los, você consegue escolta os mercadores em segurança. \nApesar da metade das mercadorias ter sido desperdiçadas por conta dos cactos, os mercadores te recompensam com 70 moedas pela ajuda. ","Bevelle, a cidade de templos religiosos, artes belas e arquiteturas surreais. O mais incrível ela ser construída em cima de um lago. \nVocê é logo barrado pelos acolitas da cidade, alegando que você é um herege procurado pelas autoridades do templo. \nApós ser preso, você consegue fugir da cidade, infelizmente, você não conseguiu pegar suas bolsas de moeda a tempo. Mas conseguiu achar 100 moedas escondidas num poço da sorte. \n(Perde tudo, depois ganha 100)","Você vê uma cidade a distância com prédios majestosos, rodeados por estandartes do império de Galahad. Seria perigo entrar numa cidade controlada pelo império. Você acha melhor desviar o caminho. \nApós desviar, você encontra o acampamento dos rebeldes, que estão organizando uma incursão para retomar Ala Mhigo. Eles te dão um lugar para dormir e comida para continuar a viagem. \n","Bem-vindo a Baron, a cidade conhecida pelo seu castelo luxuriante, e pelos caçadores de dragões. \nO rei de Baron decide fazer uma competição, onde o vencedor ganha a maravilhosa lança Highwind. \nPor sorte e habilidades impressionantes, você ganha a competição, no entanto, descobre que a lança foi roubada. Para compensar, o rei lhe dá 250 moedas pelo prêmio.","Você chega na cidade de Midgar, onde é impossível de ver o céu, devido a poluição de sua industrialização selvagem. Chaminés se alastram a quilômetros e a criminalidade mais alta de todo o mundo. \nNos seus dez primeiros dez minutos na cidade, você já foi roubado 3 vezes por batedores de moedas. Você desiste de se aventurar na cidade, e está 35 moedas mais pobre. \n","Bem-vindo a Serdin, a cidade dos magos. Aqui todas as escolas de magia e magos se concentram. \nQuando estava passando pela entrada, uma maga de cabelo purpura corre para falar com você. Ela diz que precisava de ajuda para matar um monstro da floresta das redondezas, para que ela participar de uma guilda que ela estava anos tentando entrar. \nDepois de ajudá-la, ela o recompensa com 120 moedas de ouro. \n","Você se aproxima da capital imperial Nilfheim. Para entrar é necessário um passaporte. \n Mesmo depois de toda a burocracia, documentação e dinheiro investido, você desiste de entrar, já que estava 300 moedas mais pobre, e sua aprovação só seria aprovada daqui a quatro meses. \n","Você encontra as ruídas de Thundera. Um antigo império de felinos antropomórficos, no qual hoje só resta ruinas de seu passado. \nAs ruinas já foram saqueadas por anos e não restava nada, mas olhando bem para uma das estatuas dos antigos governantes, você que um dos olhos de uma estátua estava brilhando. Ao escalá-la você retira a pedra brilhante, que parecia mais um rubi. \nVocê decide vender para um mercador que tinha aparecido coincidentemente após você ter descido da estátua. Você ganha 500 moedas e em sequencia o mercador desaparece como fumaça.","Naboo, a cidade conhecida por suas bebidas suaves, clima ameno e quedas d’agua de tirar o folego. Apesar de tudo isso, mora intrigas políticas, e você cai em uma delas. \nVocê é processado por um senado de Naboo e deve pagar o preço de 300 moedas para não ser preso, você faz.","Ao passar por um nevoeiro pesado, você encontra a lendária Hogwart, mas o que lhe da boas-vindas não são feiticeiros, mas sim chamas. O lugar não parecia ter ninguém, apenas fogo, você tenta se aproximar, mas algo diz para você voltar, você acaba acatando.","Bem-vindo a Eitah, onde coisas estranhas acontecem. A primeira coisa que você fez ao entrar foi escorregar numa casca de banana. O povo do vilarejo grita “eba!” e dão 300 moedas em seguida. Logo após uma mulher da um tapa na sua cara e pergunta da raposa dela. \n Depois um senhor vem explicar que a raposa da mulher na verdade é a sobrinha dela que se veste de panda, que na verdade estava nadando no lago da vila. Por fim o homem decide cobrar a informação por 150 moedas, caso contrário, ele o ameaçou de morte. \nVocê paga o senhor e corre daquela vila, sem entender nada.","Você se sente feliz ao adentrar o reino de Canaban, conhecido por seus guerreiros honrados, bravos e sagazes. Você conhece um jovem de cabelo vermelho, que estava à procura de sua irmã. \n Você tenta ajudar ele, mas depois de dias em busca, ele acaba querendo ir em uma jornada semelhante à sua, visitar o mundo em busca dela, Elesis. Você o convida para ir com você, mas ele acaba negando e preferindo ir sozinho. \nEle te recompensa pelo esforço com 60 moedas.","Konichiwa, bem-vindo a vila de Konoha, onde os melhores ninjas shinobis treinam. Você maravilhado com as artes marciais e armas que são estrangeiras para a seus olhos, afina, era uma cultura do outro lado do mundo. \nVocê se aproxima de uma barraca de comidas locais, lá você um Rámem Naruto, uma espécie de macarrão de Konoha, você paga 10 moedas e come o macarrão. \nVocê sai da vila satisfeito.","Orleau te da boas-vindas, uma cidade nobre, totalmente requintada com adornos supérfluos, mas majestosos. Você se apaixona pelas artes locais, inúmeras peças, restaurantes e parques. \nPor fim você encontra uma loja que vendia apenas um item, uma caixa. Você decide perguntar ao vendedor do que poderia se tratar, ele responde que é um segredo. Por curiosidade você decide comprá-la, ao abri-la você encontra uma folha, na qual estava escrito segredo. Furioso, você vai atrás do vendedor, mas ele tinha sumido. \nVocê agora está 250 moedas mais pobre, e com um segredo em mãos.","Você se aproxima do condado de Tevinter, conhecida por seus vinhais e história. Uma vez um antigo império que quase dominou o mundo todo, hoje é um lugar que atraí turista por suas riquezas culturais. \nNão resistindo a tentação, você decide comprar uma garrafa de vinho do local, sendo 150 moedas mais bem gastas da sua vida. \n","Eden, a cidade banhada a ouro onde as pessoas não morrem de fome, sede, ou qualquer outro motivo. A cidade abençoada pelos deuses, onde apenas os mais puros podem entrar. \nPara entrar, é necessário ser julgado por Barthandelus, o arcanjo que decide quem passa ou não dos portões. \nInfelizmente, ele o considerou impuro. Sua passagem foi negada."
    };
        //"Texto - Vault 76","autilus","Texto – Rabanastre","Texto – Bevelle","Texto – Ala Mhigo",  "Texto – Baron","Texto – Midgar","Texto – Serdin","Texto – Nilfheim","Texto – Thundera","Texto – Naboo","Texto – Hogwarts","Texto – Eitah","Texto – Canaban","Texto – Konoha","Texto – Orleau","Texto – Tevinter","Texto – Eden" };
       
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
    public Text ArestaText;

    public GameObject controle;
    public int Num;
    private int deletethis=0;
    // Update is called once per frame
    void Update()
    {

        MaxAresta = ((LinhasQtd) * (ColunasQtd - 1) + (LinhasQtd - 1) * (ColunasQtd) + ((LinhasQtd - 1) * (ColunasQtd - 1)) * 2);
        if (controle.GetComponent<Script>().telas != Script.Telas.Arestas)
            GetTecladoNum();

        if ((ArestaQtd < MinAresta) && controle.GetComponent<Script>().telas == Script.Telas.Arestas)
            ArestaQtd = MinAresta;
        else
            if (ArestaQtd > MaxAresta)
            ArestaQtd = MaxAresta;
        ArestaText.text = "Digite o numero de Arestas:   " + ArestaQtd;

        UpdateLinhas((int)LinhasQtd);
        UpdateColunas((int)ColunasQtd);
        UpdateHistoria(Historia);
        UpdateCidade(NomeCidade);

        controle.GetComponent<Script>().NumeroLinhas = LinhasQtd;
        controle.GetComponent<Script>().NumeroColunas = ColunasQtd;
        controle.GetComponent<Script>().NUmeroMaxAresta = ArestaQtd;

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
    void GetTecladoNum()
    {
        Num = 1111;
        if (Input.GetKeyDown(KeyCode.Space))
            ArestaQtd = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha1))
            Num = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha2))
            Num = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha3))
            Num = 3;
        else if (Input.GetKeyDown(KeyCode.Alpha4))
            Num = 4;
        else if (Input.GetKeyDown(KeyCode.Alpha5))
            Num = 5;
        else if (Input.GetKeyDown(KeyCode.Alpha6))
            Num = 6;
        else if (Input.GetKeyDown(KeyCode.Alpha7))
            Num = 7;
        else if (Input.GetKeyDown(KeyCode.Alpha8))
            Num = 8;
        else if (Input.GetKeyDown(KeyCode.Alpha9))
            Num = 9;
        else if (Input.GetKeyDown(KeyCode.Alpha0))
            Num = 0;
        if (Num!=1111)
        ArestaQtd = ArestaQtd * 10 + Num;
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
            Debug.Log(AsHistorias.Length);
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
