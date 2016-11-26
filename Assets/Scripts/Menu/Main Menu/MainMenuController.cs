using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    float lastFrameDirection;
    int currentlySelected;
    bool mainMenuOpen = false;
    Text text;


    [Serializable]
    public struct Opcao
    {
        public string name;
        public Action action;
        public Opcao(string n, Action a)
        {
            name = n;
            action = a;
        }

    }
    private List<Opcao> opcoes;

    void Start()
    {
        lastFrameDirection = 0;
        text = gameObject.GetComponent<Text>();
        opcoes = new List<Opcao>();
        opcoes.Add(new Opcao("Novo Jogo", startNewGame));
        opcoes.Add(new Opcao("Créditos", goToCredits));
        opcoes.Add(new Opcao("Sair", quit));
    }

    private void quit()
    {
        Application.Quit();
    }

    private void goToCredits()
    {
        GameObject.Find("MainMenu").BroadcastMessage("animateStart", "Credits");
        GameObject.Find("Agradecimentos").BroadcastMessage("setAtivo");
    }

    private void startNewGame()
    {
        GameObject.FindGameObjectWithTag("SceneChanger").BroadcastMessage("changeScene", 1);
    }

    void Update()
    {
        if (mainMenuOpen)
        {
            if (hasChangedDirection(Input.GetAxisRaw("Horizontal")))
            {
                currentlySelected = (opcoes.Count + currentlySelected + (int)lastFrameDirection) % opcoes.Count;
                text.text = opcoes[currentlySelected].name;
            }
            else if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump"))
            {
                mainMenuOpen = false;
                opcoes[currentlySelected].action();
            }
        }   
    }

    void enableMenu()
    {
        mainMenuOpen = true;
    }

    bool hasChangedDirection(float input)
    {
        if (Math.Sign(input) == lastFrameDirection)
        {
            return false;
        }
        else
        {
            lastFrameDirection = Math.Sign(input);
            return true;
        }
    }

}
