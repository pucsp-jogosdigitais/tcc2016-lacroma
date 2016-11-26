using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Actor : MonoBehaviour {

    public float width;
    public Vector2 pos;
    public string actorName;
    public Color color;

    public float Width { get { return width; } set { width = value; } }
    public Vector2 Pos { get { return pos; } set { pos = value; } }
    public string Name { get { return actorName; } set { actorName = value; } }
    public Color Color { get { return color; } set { color = value; } }

    private Image actorImage;
    private RectTransform rectTransform;

    void Awake()
    {
        actorImage = gameObject.GetComponent<Image>();
        rectTransform = gameObject.GetComponent<RectTransform>();
    }


    public void enabledImage(bool state)
    {
        actorImage.enabled = state;
    }

    private void lookRight()
    {
        rectTransform.transform.localScale = new Vector3(1, 1, 1);
    }

    private void lookLeft()
    {
        rectTransform.transform.localScale = new Vector3(-1, 1, 1);
    }

    private void emote (string emotion)
    {
        SendMessage("animateOnce", emotion);
    }

    public void setStagePosition(int left)
    {
        rectTransform.anchorMin = new Vector2(1 - left, 0.5f);
        rectTransform.anchorMax = new Vector2(1 - left, 0.5f);
        rectTransform.sizeDelta = new Vector2(Width, 1080);
        rectTransform.anchoredPosition = new Vector2((-1 + 2* left) * Pos.x, Pos.y);
    }

    public void setStagePositionCenter()
    {
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(1, 1);
        rectTransform.anchoredPosition = new Vector2(Pos.x, Pos.y);
    }
}
