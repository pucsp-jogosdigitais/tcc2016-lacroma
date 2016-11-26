using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System;

public class CombatStarter : Response {

    public GameObject combatController;

    private GameObject combatGroup;

    public List<GameObject> enemies;

    private GameObject sceneChanger;

    private bool hasStarted = false;

    void Start()
    {
        combatGroup = GameObject.FindGameObjectWithTag("CombatGroup");
        sceneChanger = GameObject.FindGameObjectWithTag("SceneChanger");
        setTriggers();
    }

    protected override void triggerResponse(object sender, EventArgs e)
    {
        if(!hasStarted)
            startCombat();
    }

    private void startCombat()
    {
        hasStarted = true;
        Time.timeScale = 0;
        sceneChanger.BroadcastMessage("enterCombat", true);

        foreach (GameObject enemy in enemies)
        {
            GameObject instance = Instantiate(enemy);
            instance.transform.parent = combatGroup.transform;
        }

        //set bg

        GameObject combatControllerInstance = Instantiate(combatController);
        combatControllerInstance.GetComponent<CombatController>().Starter = this;
        GameObject[] playerChars = GameObject.FindGameObjectsWithTag("PlayerParty");
    }
}
