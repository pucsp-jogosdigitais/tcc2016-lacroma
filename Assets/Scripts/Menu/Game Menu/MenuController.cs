using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {

    private Pause pauseController;
    float lastFrameDirection;
    int currentlySelected;
    List<GameObject> opcoes;
    

    void Start()
    {
        pauseController = GameObject.FindWithTag("WorldController").GetComponent<Pause>();
        pauseController.OnPause += resetPause;
        lastFrameDirection = 0;
        opcoes = new List<GameObject>(GameObject.FindGameObjectsWithTag("OpcaoMenu"));
        opcoes.Sort(new HierarchyComparer());
        currentlySelected = opcoes.Count-1;
    }

    private void resetPause(object sender, PauseEventArgs args)
    {
        currentlySelected = opcoes.Count - 1;
        hasChangedDirection(Input.GetAxisRaw("Vertical"));
    }

    void Update () {
        if (pauseController.IsPaused)
        {
            if (hasChangedDirection(Input.GetAxisRaw("Vertical")))
            {
                currentlySelected = (opcoes.Count + currentlySelected + (int)lastFrameDirection) % opcoes.Count;
            }
            for (int i = 0; i < opcoes.Count; i++)
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
