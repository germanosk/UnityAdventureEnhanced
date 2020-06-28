
public class TimelineReaction : Reaction
{
    public TimelinePlaybackManager timelinePlaybackManager;    
    
    protected override void ImmediateReaction()
    {
        timelinePlaybackManager.PlayTimeline();
    }
}
