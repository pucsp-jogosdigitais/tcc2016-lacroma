using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using UnityEngine.UI;

public class SceneChanger : MonoBehaviour {

    private int nextScene;
    private bool goToNext;
    private bool startCombat = false;
    private bool sameScene = false;
    private Animator anim;
    AsyncOperation async = null;
    int i = 0;
    private Text t;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        t = gameObject.GetComponentInChildren<Text>();
    }

    void changeScene(int goTo)
    {
        nextScene = goTo;
        BroadcastMessage("animateOnce", "Change_Scene");
        goToNext = true;
    }

    void enterCombat(bool enter = false)
    {
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        BroadcastMessage("animateOnce", "Change_Scene");
        goToNext = false;
        startCombat = enter;
    }

    void goToSameScene()
    {
        sameScene = true;
        BroadcastMessage("animateOnce", "Change_Scene");
    }

    void animationEnded()
    {
        if (goToNext) {
            BroadcastMessage("animateOnce", "Loading");
            StartCoroutine(loadNextLevel(nextScene));
        }
        else if(startCombat)
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = false;
            GameObject.FindGameObjectWithTag("CombatCamera").GetComponent<Camera>().enabled = true;
        }
        else if (sameScene)
        {
            sameScene = false;
        }
        else
        {
            GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>().enabled = true;
            GameObject.FindGameObjectWithTag("CombatCamera").GetComponent<Camera>().enabled = false;
        }
    }

    private IEnumerator loadNextLevel(int nextScene)
    {
        yield return new WaitForSeconds(0.5f);
        async = SceneManager.LoadSceneAsync(nextScene);

        while (!async.isDone)
        {
            yield return null;
        }
    }
}
