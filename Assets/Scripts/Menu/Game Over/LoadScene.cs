using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

    GameObject sceneChanger;
    public int nextScene = int.MinValue;

    void Start()
    {
        sceneChanger = GameObject.FindGameObjectWithTag("SceneChanger");
    }

    void execute()
    {
        if (nextScene < 0)
            sceneChanger.BroadcastMessage("changeScene", SceneManager.GetActiveScene().buildIndex);
        else
            sceneChanger.BroadcastMessage("changeScene", nextScene);
    }

}
