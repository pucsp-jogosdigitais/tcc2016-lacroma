using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class CombatCharacter : MonoBehaviour {

    public bool isEnemy = false;
    public Shader shader;

    #region Moves
    public List<GameObject> moves;

    internal GameObject getAttack(int currentlySelectedExpanded)
    {
        GameObject attack = Instantiate(moves[currentlySelectedExpanded]);
        return attack;
    }
    #endregion

    #region Events

    public event EventHandler<EventArgs> OnDie;

    #endregion

    #region Speed
    public int speed;

    public int Speed
    {
        get { return speed; }
        set { speed = value; }
    }
    #endregion

    #region Priority

    private int priority;

    public int Priority
    {
        get { return priority; }
        set { priority = value; }
    }
    public int PriorityModifier
    {
        get
        {
            int priorityModifier = 0;
            StatModifier[] modifiers = gameObject.GetComponents<StatModifier>();
            foreach (StatModifier modifier in modifiers)
            {
                if (modifier.IsActive)
                    priorityModifier += modifier.Priority;
            }
            return priorityModifier + Math.Sign(priorityModifier);
        }
    }
    #endregion

    #region Attack

    public int attack;

    public int Attack
    {
        get { return attack + AttackModifier; }
        set { attack = value; }
    }
    public int AttackModifier
    {
        get
        {
            int attackModifier = 0;
            StatModifier[] modifiers = gameObject.GetComponents<StatModifier>();
            foreach (StatModifier modifier in modifiers)
            {
                if (modifier.IsActive)
                    attackModifier += modifier.Attack;
            }
            return attackModifier;
        }
    }

    #endregion

    #region Defense
    public int defense;

    public int Defense
    {
        get { return defense + DefenseModifier; }
        set { defense = value; }
    }
    public int DefenseModifier
    {
        get
        {
            int defenseModifier = 0;
            StatModifier[] modifiers = gameObject.GetComponents<StatModifier>();
            foreach (StatModifier modifier in modifiers)
            {
                if (modifier.IsActive)
                    defenseModifier += modifier.Defense;
            }
            return defenseModifier;
        }
    }
    #endregion

    #region HP
    public int currentHP;
    public int maxHP;
    public int damageThisTurn;

    public void takeDamage(int damage)
    {
        currentHP -= damage;
        damageThisTurn += damage;
        if (currentHP < 0)
            currentHP = 0;
        if (currentHP <= 0)
            die();
    }

    public void healDamage(int heal)
    {
        currentHP += heal;
        if (currentHP > maxHP)
            currentHP = maxHP;
        BroadcastMessage("currentLife", (float)currentHP / maxHP);
    }

    public void setSaturation()
    {
        if (!isEnemy)
            foreach (SpriteRenderer rend in model)
                rend.material.SetFloat("_Sat", (float)currentHP / maxHP);
        else
            foreach (SpriteRenderer rend in model)
                rend.material.SetFloat("_Sat", 1 - (float)currentHP / maxHP);
    }

    public void heal(int restore)
    {
        currentHP += restore;
        if (currentHP > maxHP)
            currentHP = maxHP; 
    }

    private void getHit(Acao sender)
    {
        BroadcastMessage("damaged", sender);
        BroadcastMessage("currentLife", (float)currentHP / maxHP);
        setSaturation();
    }

    public bool isAlive()
    {
        return currentHP > 0;
    }
    #endregion

    public Sprite portrait;
    private List<SpriteRenderer> model;

    private void die()
    {
        if (OnDie != null)
            OnDie(this, new EventArgs());
        //animate death
    }

    void Start()
    {
        currentHP = maxHP;
        model = getAllRenderers(gameObject.transform);
        foreach (SpriteRenderer rend in model)
        {
            rend.material = new Material(shader);
        }
    }

    public void setSortingLayer(string layer)
    {
        foreach (SpriteRenderer renderer in model)
            renderer.sortingLayerName = layer;
    }

    private List<SpriteRenderer> getAllRenderers(Transform obj)
    {
        List<SpriteRenderer> result = new List<SpriteRenderer>();
        if (obj.GetComponent<SpriteRenderer>())
            result.Add(obj.GetComponent<SpriteRenderer>());

        foreach (Transform child in obj.transform)
            result.AddRange(getAllRenderers(child));

        return result;
    }

    public void nextTurn()
    {
        damageThisTurn = 0;
    }
}
