using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UITextPlayable : PlayableBehaviour
{
    public Text text = null;
    public Color color = Color.white;
    public string content = String.Empty;
    public bool isActive = true;

    public override void ProcessFrame(Playable playable, FrameData info, object playerData)
    {
        if (text != null)
        {
            text.gameObject.SetActive(isActive);
            text.color = color;
            text.text = content;
        }
    }
}
