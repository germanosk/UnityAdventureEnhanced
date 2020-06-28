using UnityEditor;

[CustomEditor(typeof(TimelineReaction))]
public class TimelineReactionEditor : ReactionEditor
{
    protected override string GetFoldoutLabel ()
    {
        return "Timeline Reaction";
    }
}