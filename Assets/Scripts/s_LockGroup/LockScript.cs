using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LockScript : MonoBehaviour {

    public int[] lockCode = new int[4];

    public Text numCode;

	void Start ()
    {
        lockCode[0] = 0;
        lockCode[1] = 0;
        lockCode[2] = 0;
        lockCode[3] = 0;
    }
	
	void Update ()
    {
        numCode.text = lockCode[0].ToString("") + lockCode[1].ToString("") + lockCode[2].ToString("") + lockCode[3].ToString("");
    }

    public void EmptyLock()
    {
        lockCode[0] = 0;
        lockCode[1] = 0;
        lockCode[2] = 0;
        lockCode[3] = 0;
    }

    #region NumberPad
    public void num01()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 1;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 1;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 1;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 1;
        }
    }
    public void num02()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 2;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 2;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 2;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 2;
        }
    }
    public void num03()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 3;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 3;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 3;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 3;
        }
    }
    public void num04()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 4;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 4;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 4;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 4;
        }
    }
    public void num05()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 5;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 5;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 5;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 5;
        }
    }
    public void num06()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 6;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 6;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 6;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 6;
        }
    }
    public void num07()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 7;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 7;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 7;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 7;
        }
    }
    public void num08()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 8;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 8;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 8;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 8;
        }
    }
    public void num09()
    {
        if (lockCode[0] == 0)
        {
            lockCode[0] = 9;
        }
        else if (lockCode[1] == 0)
        {
            lockCode[1] = 9;
        }
        else if (lockCode[2] == 0)
        {
            lockCode[2] = 9;
        }
        else if (lockCode[3] == 0)
        {
            lockCode[3] = 9;
        }
    }
    #endregion
}
