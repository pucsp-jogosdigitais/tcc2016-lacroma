internal class AnimateArgs{
	string animationName;
	float f;
	int i;
    bool b;

	public string AnimationName{
		get { return animationName; }
	}

	public float F{
		get { return f; }
		set { f = value; }
	}

	public int I{
		get { return i; }
		set { i = value; }
	}

    public bool B
    {
        get { return b; }
        set { b = value; }
    }

	public AnimateArgs(string anim){
		animationName = anim;
	}	
}