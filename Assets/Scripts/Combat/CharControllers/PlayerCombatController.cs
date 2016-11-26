using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;

public class PlayerCombatController : CombatCharacterController
{
    float lastFrameDirection;
    static int currentlySelected;
    bool expandedMenu = false;
    static int currentlySelectedExpanded;
    static List<GameObject> opcoes;

    static List<GameObject> moves;

    CombatController controller;
    CombatCharacter character;

    void Start()
    {
        currentAction = null;
        lastFrameDirection = 0;
        if (opcoes == null || opcoes[0] == null)
        {
            opcoes = new List<GameObject>(GameObject.FindGameObjectsWithTag("OpcaoCombate"));
            opcoes.Sort(new HierarchyComparer());
        }
        #region Move List
        if (moves == null || moves[0] == null)
        {
            moves = new List<GameObject>(GameObject.FindGameObjectsWithTag("StandardMove"));
            moves.Sort(new HierarchyComparer());

            foreach(GameObject move in moves)
                move.GetComponent<Image>().material = new Material(moves[0].GetComponent<Image>().material);
        }

        #endregion
        currentlySelected = - 1;
        character = gameObject.GetComponent<CombatCharacter>();

        for (int i = 0; i < opcoes.Count; i++)
            opcoes[i].SendMessage("selected", i == currentlySelected);
    }

    public override Acao getAction()
    {
        if (currentAction == null)
        {
            getNextAction();
            return null;
        }

        else if (currentAction.Target.Count == 0)
        {
            getActionTarget();
            return null;
        }

        else if (currentAction.Place == int.MinValue)
        {
            getActionPlace();
            return null;
        }
        else
            return currentAction;
    }

    private void getNextAction()
    {
        GameObject attack;
        if (currentlySelected < 0)
        {
            currentlySelected = opcoes.Count - 1;
            for (int i = 0; i < opcoes.Count; i++)
                opcoes[i].SendMessage("selected", i == currentlySelected);
        }

        if (hasChangedDirection(Input.GetAxisRaw("Vertical")))
        {
            if (!expandedMenu)
            {
                currentlySelected = (opcoes.Count + currentlySelected + (int)lastFrameDirection) % opcoes.Count;
                if (currentlySelected == 0)
                {
                    GameObject.Find("AcaoNome").GetComponent<Text>().text = "Fugir";
                    GameObject.Find("AcaoDescricao").GetComponent<Text>().text = "Escapa dos oponentes e evita o confronto, porém não recebe prêmios";
                }
                if (currentlySelected == 1)
                {
                    GameObject.Find("AcaoNome").GetComponent<Text>().text = "Aguardar";
                    GameObject.Find("AcaoDescricao").GetComponent<Text>().text = "Não realiza qualquer ação nessa rodada, uma escolha para quando todas as outras parecerem ruins";
                }
                if (currentlySelected == 2)
                {
                    GameObject.Find("AcaoNome").GetComponent<Text>().text = "Itens";
                    GameObject.Find("AcaoDescricao").GetComponent<Text>().text = "Utiliza um de seus itens.";
                }
                if (currentlySelected == 3)
                {
                    GameObject.Find("AcaoNome").GetComponent<Text>().text = "Lutar";
                    GameObject.Find("AcaoDescricao").GetComponent<Text>().text = "Utiliza um de seus ataques.";
                }
                for (int i = 0; i < opcoes.Count; i++)
                    opcoes[i].SendMessage("selected", i == currentlySelected);
            }
            else
            {
                currentlySelectedExpanded = (character.moves.Count + currentlySelectedExpanded + (int)lastFrameDirection) % character.moves.Count;
                GameObject.Find("AcaoNome").GetComponent<Text>().text = character.moves[currentlySelectedExpanded].name;
                GameObject.Find("AcaoDescricao").GetComponent<Text>().text = character.moves[currentlySelectedExpanded].GetComponent<Acao>().description;
                if (moves[0].activeSelf)
                    for (int i = 0; i < moves.Count; i++)
                        moves[i].SendMessage("selectedMove", i == currentlySelectedExpanded);
            }
        }
        else if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump"))
        {
            if (!expandedMenu)
            {
                controller = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>();
                if (currentlySelected == 0)
                    controller.SendMessage("endCombat", false);
                else if (currentlySelected == 1)
                {
                    //Empty Action
                    attack = new GameObject();
                    attack.tag = "Action";
                    currentAction = attack.AddComponent<Acao>();
                    currentAction.Target = new List<GameObject> { gameObject };
                    currentAction.Place = 0;
                    attack.transform.parent = gameObject.transform;
                    currentAction.Sender = gameObject;
                    currentlySelected = - 1;
                }
                else if (currentlySelected == 3)
                {
                    expandedMenu = true;
                    opcoes[currentlySelected].BroadcastMessage("expanded", true);
                    setMoves();
                    currentlySelectedExpanded = 0;
                    for (int i = 0; i < moves.Count; i++)
                        moves[i].SendMessage("selectedMove", i == currentlySelectedExpanded);
                }
                for (int i = 0; i < opcoes.Count; i++)
                    opcoes[i].SendMessage("selected", i == currentlySelected);
            }
            else
            {
                GameObject nextAttack = character.getAttack(currentlySelectedExpanded);
                currentAction = nextAttack.GetComponent<Acao>();
                currentAction.transform.parent = gameObject.transform;
                currentAction.Sender = gameObject;
                expandedMenu = false;
                opcoes[currentlySelected].BroadcastMessage("expanded", false);
                currentlySelected = - 1;
                for (int i = 0; i < opcoes.Count; i++)
                    opcoes[i].SendMessage("selected", i == currentlySelected);
            }
        }
        else if (Input.GetButtonDown("Cancel") && expandedMenu)
        {
            expandedMenu = false;
            opcoes[currentlySelected].BroadcastMessage("expanded", false);
        }
    }

    private void getActionTarget()
    {
        AcaoTargets properties = gameObject.GetComponentInChildren<AcaoTargets>();
        currentAction.Target = properties.setTarget();
    }

    private void getActionPlace()
    {
        AcaoPlace place = gameObject.GetComponentInChildren<AcaoPlace>();
        currentAction.Place = place.setPlace();
    }

    void setMoves()
    {
        for (int i = 0; i < 5; i++)
        {
            if (i < character.moves.Count && character.moves[i] != null)
            {
                Acao move = character.moves[i].GetComponent<Acao>();
                move.getColor();
                moves[i].GetComponentInChildren<Text>().text = move.name;
                moves[i].GetComponent<Image>().material.SetFloat("_HueShift", move.color.hue);
                moves[i].GetComponent<Image>().material.SetFloat("_Val", move.color.val);
            }
            else
            {
                moves[i].SendMessage("expanded", false);
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
