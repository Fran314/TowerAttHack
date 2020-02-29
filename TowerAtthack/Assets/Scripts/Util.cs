using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util
{
    public static string getTagType(string arg0)
    {
        string to_return = "";
        for(int i = 0; i < arg0.Length; i++)
        {
            if (arg0[i] != '-') to_return += arg0[i];
            else break;
        }
        return to_return;
    }
}
