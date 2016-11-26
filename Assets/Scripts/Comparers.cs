using UnityEngine;
using System.Collections.Generic;

public class CharacterSpeedComparer : IComparer<GameObject>
{
    public int Compare(GameObject x, GameObject y)
    {
        CombatCharacter charX = x.GetComponent<CombatCharacter>();
        CombatCharacter charY = y.GetComponent<CombatCharacter>();
        if (charX.Speed > charY.Speed)
            return 1;
        else if (charX.Speed < charY.Speed)
            return -1;
        else
            return 0;
    }
}

public class CharacterPriorityComparer : IComparer<GameObject>
{
    public int Compare(GameObject x, GameObject y)
    {
        CombatCharacter charX = x.GetComponent<CombatCharacter>();
        CombatCharacter charY = y.GetComponent<CombatCharacter>();

        if (charX.Priority + charX.PriorityModifier > charY.Priority + charY.PriorityModifier)
            return 1;
        else if (charX.Priority + charX.PriorityModifier < charY.Priority + charY.PriorityModifier)
            return -1;
        else
        {
            if (charX.Priority == charY.Priority)
                return 0;
            else
                return charX.Priority > charY.Priority ? 1 : -1;
        }
    }
}

public class HierarchyComparer : IComparer<GameObject>
{
    public int Compare(GameObject x, GameObject y)
    {
        if (x.transform.GetSiblingIndex() < y.transform.GetSiblingIndex())
            return 1;
        else if (x.transform.GetSiblingIndex() > y.transform.GetSiblingIndex())
            return -1;
        else
            return 0;
    }
}
