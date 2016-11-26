using UnityEngine;
using System.Collections;
using System;

public class GameOverMenuController : MonoBehaviour {

    private Character player;
    float lastFrameDirection;
    int currentlySelected;
    GameObject[] opcoes;
    bool gameIsOver = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        player.OnHpChange += Die;
        lastFrameDirection = 0;
        opcoes = GameObject.FindGameObjectsWithTag("OpcaoGameOver");
        currentlySelected = opcoes.Length - 1;
    }

    private void gameOver()
    {
        currentlySelected = opcoes.Length - 1;
        hasChangedDirection(Input.GetAxisRaw("Vertical"));
        gameIsOver = true;
    }

    private void Die(object sender, HpChangeArgs args)
    {
        if (args.Hp <= 0)
        {
            currentlySelected = opcoes.Length - 1;
            hasChangedDirection(Input.GetAxisRaw("Vertical"));
            gameIsOver = true;
        }
        
    }

    void Update () {
        if (gameIsOver)
        {
            if (hasChangedDirection(Input.GetAxisRaw("Vertical")))
            {
                currentlySelected = (opcoes.Length + currentlySelected + (int)lastFrameDirection) % opcoes.Length;
            }
            if(Input.GetButtonDown("Interact"))
            {
                opcoes[currentlySelected].SendMessage("execute");
            }
            for (int i = 0; i < opcoes.Length; i++)
            {
                opcoes[i].BroadcastMessage("selected", i == currentlySelected);
            }
        }
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
