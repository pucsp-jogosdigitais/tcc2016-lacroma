using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public abstract class AcaoTargets : MonoBehaviour
{
    protected List<GameObject> targets;
    protected CombatController controller;
    protected int currentlySelected = 0;
    protected float lastFrameDirection = 0;
    protected GameObject pointer;
    static bool set = false;

    public List<GameObject> Targets
    {
        get { return targets; }
    }

    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("CombatController").GetComponent<CombatController>();
        pointer = GameObject.Find("Pointer");
        setTargetList();
    }

    public void resetTargets()
    {
        setTargetList();
    }

    public abstract void setTargetList();

    public abstract List<GameObject> setTarget();

    protected GameObject selectTarget(GameObject[] possibleTargets)
    {
        GameObject result = null;

        float TargetX = possibleTargets[currentlySelected].transform.localPosition.x;
        float TargetY = possibleTargets[currentlySelected].transform.localPosition.y;
        pointer.transform.localPosition = new Vector2(TargetX - (Math.Sign(TargetX) * 0.7f), TargetY);
        if (!set)
        {
            pointer.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            set = true;
        }

        if (hasChangedDirection(Input.GetAxisRaw("Vertical")))
            currentlySelected = (possibleTargets.Length + currentlySelected + (int)lastFrameDirection) % possibleTargets.Length;
        else if (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump"))
        {
            set = false;
            pointer.GetComponentInChildren<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            result = possibleTargets[currentlySelected];
            currentlySelected = 1;
        }

        return result;
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

    public GameObject getRandomTarget()
    {
        setTargetList();
        System.Random rand = new System.Random();
        return targets[rand.Next(targets.Count)];
    }
}
