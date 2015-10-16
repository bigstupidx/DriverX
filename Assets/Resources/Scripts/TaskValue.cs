using UnityEngine;
using System.Collections;

public class TaskValue {

    string[] fullText;
    string[] helperText;

	public TaskValue(string[] fullText, string[] helperText)
    {
        this.fullText = fullText;
        this.helperText = helperText;
    }

    public string GetFullText(int num)
    {
        return fullText[num];
    }

    public string GetHelperText(int num)
    {
        return helperText[num];
    }
}
