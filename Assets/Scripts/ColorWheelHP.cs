using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class ColorWheelHP : MonoBehaviour {

    Character character;

    void Start()
    {
        character = GameObject.FindGameObjectWithTag("Player").GetComponent<Character>();
        character.OnHpChange += changeWheel;
        gameObject.GetComponent<Image>().material.SetFloat("_Sat", 1.0f);
    }

    private void changeWheel(object sender, HpChangeArgs args)
    {
        gameObject.GetComponent<RectTransform>().localScale = getScale(args.Hp);
        gameObject.GetComponent<Image>().material.SetFloat("_Sat", getColor(args.Hp));
    }

    private Vector3 getScale(int hp)
    {
        float scale = (1.0f + 2 * ((float)hp / (float)character.maxHP)) / 3.0f;
        return new Vector3(-scale, scale, 1);
    }

    private float getColor(int hp)
    {
        return (float)hp / (float)character.maxHP;
    }
}
