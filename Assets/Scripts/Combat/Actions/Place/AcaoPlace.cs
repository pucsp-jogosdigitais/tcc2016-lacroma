using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.UI;

public abstract class AcaoPlace : MonoBehaviour
{
    float lastFrameDirection = 0;
    protected CombatController controller;
    private int currentlySelected = 0;
    bool set = false;
    Image pointerImage; 

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>();
        pointerImage = GameObject.Find("TurnPointerImage").GetComponent<Image>();
    }

    public abstract int setPlace();

    protected int selectPlace()
    {
        if (!set)
        {
            pointerImage.color = Color.white;
            set = true;
        }

        List<Acao> currentList = controller.standardActions;
        int result = int.MinValue;

        if (currentList.Count == 0)
        {
            result = 0;
            set = false;
            pointerImage.color = new Color(1, 1, 1, 0);
        }
        else if (hasChangedDirection(Input.GetAxisRaw("Horizontal")))
            currentlySelected = (currentList.Count + 1 + currentlySelected + (int)lastFrameDirection) % (currentList.Count + 1);
        else if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump"))
        {
            result = currentlySelected;
            set = false;
            pointerImage.color = new Color(1, 1, 1, 0);
            currentlySelected = 0;
        }

        setPointerPosition();

        /*if (Input.GetKeyDown(KeyCode.Alpha1) || currentList.Count == 0)
        {
            result = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currentList.Count >= 1)
        {
            result = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && currentList.Count >= 2)
        {
            result = 2;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4) && currentList.Count >= 3)
        {
            result = 3;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5) && currentList.Count >= 4)
        {
            result = 4;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6) && currentList.Count >= 5)
        {
            result = 5;
        }*/

        return result;
    }

    private void setPointerPosition()
    {
        RectTransform pointerTransform = GameObject.Find("TurnPointer").GetComponent<RectTransform>();
        int position = controller.earlyActions.Count + currentlySelected;
        pointerTransform.anchoredPosition = new Vector2(50.0f + position * 150, 0);
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
