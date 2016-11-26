using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class PortraitController : MonoBehaviour {

    public Sprite none;
    public List<Image> portraits;
    private CombatController controller;    

    public CombatController Controller
    {
        set { controller = value; }
    }

    void Start()
    {
        List<GameObject> children = new List<GameObject>();
        foreach (Transform child in gameObject.transform)
            children.Add(child.gameObject);

        children.Sort(new HierarchyComparer());
        children.Reverse();

        foreach (GameObject obj in children)
            if (obj.GetComponent<Image>())
                portraits.Add(obj.GetComponent<Image>());
    }

    public void refreshPortraits()
    {
        for(int i = 0; i < controller.earlyActions.Count; i++)
            portraits[i].sprite = controller.earlyActions[i].Sender.GetComponent<CombatCharacter>().portrait;

        for (int i = 0; i < controller.standardActions.Count; i++)
        {
            int portraitIndex = controller.earlyActions.Count + i;
            portraits[portraitIndex].sprite = controller.standardActions[i].Sender.GetComponent<CombatCharacter>().portrait;
        }

        for (int i = 0; i < controller.lateActions.Count; i++)
        {
            int portraitIndex = controller.earlyActions.Count + controller.standardActions.Count + i;
            portraits[portraitIndex].sprite = controller.lateActions[i].Sender.GetComponent<CombatCharacter>().portrait;
        }
    }

    public void newTurn()
    {
        foreach (Image portrait in portraits)
            portrait.sprite = none;
    }

}
