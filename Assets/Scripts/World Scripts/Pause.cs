using UnityEngine;
using System.Collections;
using System;

public class Pause : MonoBehaviour {

    private bool isPaused;

    #region events
    public delegate void PauseHandler(object sender, PauseEventArgs args);
    public event PauseHandler OnPause;
    #endregion

    public bool IsPaused
    {
        get { return isPaused; }
    }

    void Start()
    {
        isPaused = false;
    }

    // Update is called once per frame
    void Update () {
        if (Input.GetButtonDown("Pause") && !(Time.timeScale == 0 && !isPaused))
        {
            isPaused = !isPaused;
            if (OnPause != null)
                OnPause(this, new PauseEventArgs(isPaused));
            Time.timeScale = 1 - Time.timeScale;
        }
	}
}

public class PauseEventArgs : EventArgs
{
    bool isPaused;

    public bool IsPaused
    {
        get { return isPaused; }
    }

    public PauseEventArgs(bool p)
    {
        isPaused = p;
    }
}