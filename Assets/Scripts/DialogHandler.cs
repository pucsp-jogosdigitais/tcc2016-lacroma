using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;

public class DialogHandler : MonoBehaviour {


    public GameObject backdrop;
    public GameObject textbox;

    public int currentLine;
    private Dictionary<string, GameObject> actorsHash;
    private Dictionary<string, CallTrigger> triggerHash;
    private Actor leftActor;
    private Actor rightActor;
    public string[] textLines;

    private Text shownText;
    private Text speakerName;
    private GameObject dialogCanvas;

    private bool lastFrameState;

    [Serializable]
    public struct ActorHash
    {
        public string name;
        public GameObject actor;
    }

    [Serializable]
    public struct TriggerHash
    {
        public string name;
        public CallTrigger trigger;
    }


    public ActorHash[] actors;
    public TriggerHash[] triggers;
    public TextAsset script;


    // Use this for initialization
    void Start () {
        actorsHash = new Dictionary<string, GameObject>();
        triggerHash = new Dictionary<string, CallTrigger>();

        #region Dictionary Conversions
        foreach (ActorHash actor in actors)
        {
            GameObject actorChar = Instantiate(actor.actor);
            actorsHash.Add(actor.name, actorChar);
        }

        if (actorsHash.Count != actors.Length)
            throw new Exception("Actor array not properly converted, check actor names");

        foreach (TriggerHash trigger in triggers)
            triggerHash.Add(trigger.name, trigger.trigger);

        if (triggerHash.Count != triggers.Length)
            throw new Exception("Trigger array not properly converted, check trigger names");
        #endregion

        Time.timeScale = 0;

        textLines = script.text.Split('$');

        //Setup
        dialogCanvas = GameObject.FindGameObjectWithTag("DialogCanvas");
        dialogCanvas.GetComponent<Canvas>().enabled = true;
        foreach(string actorName in actorsHash.Keys)
        {
            actorsHash[actorName].transform.parent = dialogCanvas.transform;
            actorsHash[actorName].GetComponent<Actor>().enabledImage(false);
        }

        GameObject.FindWithTag("TextArea").transform.SetAsLastSibling();
        shownText = GameObject.FindWithTag("TextBox").GetComponent<Text>();
        speakerName = GameObject.FindWithTag("SpeakerBox").GetComponent<Text>();

        lastFrameState = true;

    }

    void Update () {

        bool getNextLine = (Input.GetButtonDown("Interact") || Input.GetButtonDown("Jump")) && !lastFrameState;
        parse(textLines[currentLine], getNextLine);
        lastFrameState = getNextLine;
        
	}

    private void parse(string line, bool getNextLine)
    {
        //Comentários no script
        if (line.StartsWith("##"))
        {
            currentLine++;
            parse(textLines[currentLine], getNextLine);
        }

        /*Acoes de personagem no dialogo, seguem a estrutura:
                >> nomeDoAtor.acao.argumento*/
        else if (line.StartsWith(">>"))
        {
            line = line.Replace(">>", "").Replace("\n", "").Replace("\r", "");
            line.Trim();

            string[] action = line.Split('.');
            if (action.Length > 2)
                actorsHash[action[0]].BroadcastMessage(action[1], action[2]);
            else
                actorsHash[action[0]].BroadcastMessage(action[1]);
            currentLine++;
            parse(textLines[currentLine], false);
        }
        /*Acoes da cena no dialogo seguem a estrutura:
                -- acao.argumento*/
        else if (line.StartsWith("--"))
        {


            line = line.Replace("--", "").Replace("\n", "").Replace("\r", "");
            line.Trim();

            string[] action = line.Split('.');
            if (action.Length > 1)
                SendMessage(action[0], action[1]);
            else
                SendMessage(action[0]);
            if (currentLine < textLines.Length-1)
            {
                currentLine++;
                parse(textLines[currentLine], getNextLine);
            }
        }

        else if (textLines[currentLine].Trim() == "")
        {
            currentLine++;
            parse(textLines[currentLine], getNextLine);
        }
        else
        {
            shownText.text = textLines[currentLine];
            if (getNextLine)
                currentLine++;
        }
    }

    private void enterLeft(string actor)
    {
        if (leftActor != null)
            leftActor.enabledImage(false);
        leftActor = actorsHash[actor].GetComponent<Actor>();
        leftActor.enabledImage(true);
        leftActor.setStagePosition(1);
        leftActor.BroadcastMessage("lookRight");
    }

    private void enterRight(string actor)
    {
        if (rightActor != null)
            rightActor.enabledImage(false);
        rightActor = actorsHash[actor].GetComponent<Actor>();
        rightActor.enabledImage(true);
        rightActor.setStagePosition(0);
        rightActor.BroadcastMessage("lookLeft");
    }

    private void enterCenter(string actor)
    {
        if (leftActor != null)
            leftActor.enabledImage(false);
        leftActor = actorsHash[actor].GetComponent<Actor>();
        leftActor.enabledImage(true);
        leftActor.setStagePositionCenter();
        leftActor.BroadcastMessage("lookRight");
    }

    private void exitRight()
    {
        if (rightActor != null)
            rightActor.enabledImage(false);
        rightActor = null;
    }

    private void exitLeft()
    {
        if (leftActor != null)
            leftActor.enabledImage(false);
        leftActor = null;
    }

    private void exitCenter()
    {
        if (leftActor != null)
            leftActor.enabledImage(false);
        leftActor = null;
    }

    private void speak(string actor)
    {
        if (actor != "none")
        {
            Actor characterActor = actorsHash[actor].GetComponent<Actor>();
            speakerName.text = characterActor.Name;
            speakerName.color = characterActor.Color;
            shownText.color = characterActor.Color;
            foreach (string actorName in actorsHash.Keys)
            {
                if (actorName == actor)
                    actorsHash[actorName].GetComponent<Image>().color = Color.white;
                else
                    actorsHash[actorName].GetComponent<Image>().color = new Color(100, 100, 100);
            }
        }
        else
        {
            speakerName.text = "";
            speakerName.color = Color.black;
            shownText.color = Color.black;
            foreach (string actorName in actorsHash.Keys)
            {
                actorsHash[actorName].GetComponent<Image>().color = new Color(100, 100, 100);
            }
        }
    }

    private void endDialog()
    {
        dialogCanvas.GetComponent<Canvas>().enabled = false;
        foreach (string actor in actorsHash.Keys)
            Destroy(actorsHash[actor], 0.1f);
        Time.timeScale = 1;
        Destroy(gameObject, 0.1f);
    }

    private void trigger(string trigger)
    {
        triggerHash[trigger].callTrigger();
    }

    private void triggerLeave(string trigger)
    {
        triggerHash[trigger].callLeave();
    }


}
