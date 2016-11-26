using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Creditos : MonoBehaviour {

    static System.Random rand;
    bool ativo = false;

    Text text;
    private string[] memorias = {
        "e suas caixas de doces na cabeceira da cama",
        "que só foi presa depois de velha",
        "e suas partidas de poker a dinheiro",
        "e sua gentileza com estranhos",
        "e seu inigualável pudim de leite"
    };

	void Start () {
        rand = new System.Random();
        text = gameObject.GetComponent<Text>();
        text.text += "Amélia, " + memorias[rand.Next(memorias.Length)];
	}

    void Update()
    {
        if (ativo)
        {
            if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump"))
            {
                ativo = false;
                GameObject.Find("MainMenu").BroadcastMessage("animateStop", "Credits");
            }
        }
    }

    void setAtivo()
    {
        ativo = true;
    }
	
}
