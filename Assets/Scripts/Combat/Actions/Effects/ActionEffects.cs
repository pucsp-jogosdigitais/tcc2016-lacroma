using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class ActionEffects : MonoBehaviour {

    public virtual void earlyExecute(GameObject sender, List<GameObject> targets) { }

    public virtual  void standardExecute(GameObject sender, List<GameObject> targets) { }

    public virtual void lateExecute(GameObject sender, List<GameObject> targets) { }

}
