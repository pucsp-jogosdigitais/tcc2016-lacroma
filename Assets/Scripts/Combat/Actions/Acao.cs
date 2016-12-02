using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class Acao : MonoBehaviour {

    public string acaoName = "";

    private static readonly ColorRef[] COLOR_REFENCE = {
        new ColorRef(0, 1),
        new ColorRef(230.0f, 1.2f),
        new ColorRef(165.0f, 1.2f),
        new ColorRef(300, 1.6f)
    };

    public struct ColorRef
    {
        public float hue;
        public float val;

        public ColorRef(float h, float v)
        {
            hue = h;
            val = v;
        }
    }

    public ColorName moveColor;
    public ColorRef color;
    public string description;

    public void getColor()
    {
        color = COLOR_REFENCE[(int)moveColor];
    }

    private int place = int.MinValue;

    private bool started = false;
    private int hitCounter;

    private GameObject sender;
    public GameObject Sender{ get { return sender; } set { sender = value; } }
    public List<GameObject> target = new List<GameObject>();
    public bool interrupted = false;

    #region Ended
    private bool ended;
    public bool Ended
    {
        get { return ended; }
    }
    #endregion

    public int Place { get { return place; } set { place = value; } }

    public bool Started { get { return started; } set { started = value; } }

    public List<GameObject> Target { get { return target; } set { target = value; } }

    public void execute()
    {
        bool targetDead = false;
        foreach(GameObject t in target)
        {
            CombatCharacter character = t.GetComponent<CombatCharacter>();
            if (!character.isAlive())
            {
                targetDead = true;
                break;
            }
        }
        if (targetDead)
        {
            ActionRetarget retarget = gameObject.GetComponent<ActionRetarget>();
            retarget.retarget(this);
        }

        applyEffects();
        started = true;
        Sender.BroadcastMessage("animateAttack", acaoName);
        hitCounter = 0;
        //ended = true; // placeHolderCode
    }

    private void hit()
    {
        foreach(GameObject t in target)
        {
            t.BroadcastMessage("getHit", this);
        }
    }

    public void targetHit()
    {
        hitCounter++;
        if (hitCounter >= target.Count)
            ended = true;
    }

    private void end()
    {
        ended = true;
    }

    private void applyEffects()
    {
        foreach (ActionEffects effect in gameObject.GetComponents<ActionEffects>())
        {
            if(!interrupted)
                effect.earlyExecute(sender, target);
        }
        foreach (ActionEffects effect in gameObject.GetComponents<ActionEffects>())
        {
            if (!interrupted)
                effect.standardExecute(sender, target);
        }
        foreach (ActionEffects effect in gameObject.GetComponents<ActionEffects>())
        {
            if (!interrupted)
                effect.lateExecute(sender, target);
        }
    }

}
