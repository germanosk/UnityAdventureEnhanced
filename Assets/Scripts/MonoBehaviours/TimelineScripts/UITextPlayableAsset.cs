using System;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;

public class UITextPlayableAsset : PlayableAsset
{
    public ExposedReference<Text> text;
    public Color color = Color.white;
    public string content = String.Empty;
    public bool isActive = true;
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        var playable = ScriptPlayable<UITextPlayable>.Create(graph);
        var  uiTextPlayable = playable.GetBehaviour();
        uiTextPlayable.text = text.Resolve(graph.GetResolver());
        uiTextPlayable.color = color;
        uiTextPlayable.content = content;
        uiTextPlayable.isActive = isActive;
        
        return playable;   
    }
}
