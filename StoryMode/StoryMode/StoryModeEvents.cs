using TaleWorlds.CampaignSystem;

namespace StoryMode;

public class StoryModeEvents : CampaignEventReceiver
{
	private readonly MbEvent<MainStoryLineSide> _onMainStoryLineSideChosenEvent;

	private readonly MbEvent _onStoryModeTutorialEndedEvent;

	private readonly MbEvent _onStealthTutorialActivatedEvent;

	private readonly MbEvent _onBannerPieceCollectedEvent;

	private readonly MbEvent _onConspiracyActivatedEvent;

	private readonly MbEvent _onTravelToVillageTutorialQuestStartedEvent;

	public static StoryModeEvents Instance => StoryModeManager.Current?.StoryModeEvents;

	public static IMbEvent<MainStoryLineSide> OnMainStoryLineSideChosenEvent => (IMbEvent<MainStoryLineSide>)(object)Instance._onMainStoryLineSideChosenEvent;

	public static IMbEvent OnStoryModeTutorialEndedEvent => (IMbEvent)(object)Instance._onStoryModeTutorialEndedEvent;

	public static IMbEvent OnStealthTutorialActivatedEvent => (IMbEvent)(object)Instance._onStealthTutorialActivatedEvent;

	public static IMbEvent OnBannerPieceCollectedEvent => (IMbEvent)(object)Instance._onBannerPieceCollectedEvent;

	public static IMbEvent OnConspiracyActivatedEvent => (IMbEvent)(object)Instance._onConspiracyActivatedEvent;

	public static IMbEvent OnTravelToVillageTutorialQuestStartedEvent => (IMbEvent)(object)Instance._onTravelToVillageTutorialQuestStartedEvent;

	public override void RemoveListeners(object obj)
	{
		_onMainStoryLineSideChosenEvent.ClearListeners(obj);
		_onStoryModeTutorialEndedEvent.ClearListeners(obj);
		_onStealthTutorialActivatedEvent.ClearListeners(obj);
		_onBannerPieceCollectedEvent.ClearListeners(obj);
		_onConspiracyActivatedEvent.ClearListeners(obj);
		_onTravelToVillageTutorialQuestStartedEvent.ClearListeners(obj);
	}

	public void OnMainStoryLineSideChosen(MainStoryLineSide side)
	{
		Instance._onMainStoryLineSideChosenEvent.Invoke(side);
	}

	public void OnStoryModeTutorialEnded()
	{
		Instance._onStoryModeTutorialEndedEvent.Invoke();
	}

	public void OnStealthTutorialActivated()
	{
		Instance._onStealthTutorialActivatedEvent.Invoke();
	}

	public void OnBannerPieceCollected()
	{
		Instance._onBannerPieceCollectedEvent.Invoke();
	}

	public void OnConspiracyActivated()
	{
		Instance._onConspiracyActivatedEvent.Invoke();
	}

	public void OnTravelToVillageTutorialQuestStarted()
	{
		Instance._onTravelToVillageTutorialQuestStartedEvent.Invoke();
	}

	public StoryModeEvents()
	{
		//IL_000c: Unknown result type (might be due to invalid IL or missing references)
		//IL_0016: Expected O, but got Unknown
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0038: Unknown result type (might be due to invalid IL or missing references)
		//IL_0042: Expected O, but got Unknown
		_onMainStoryLineSideChosenEvent = new MbEvent<MainStoryLineSide>();
		_onStoryModeTutorialEndedEvent = new MbEvent();
		_onStealthTutorialActivatedEvent = new MbEvent();
		_onBannerPieceCollectedEvent = new MbEvent();
		_onConspiracyActivatedEvent = new MbEvent();
		_onTravelToVillageTutorialQuestStartedEvent = new MbEvent();
		((CampaignEventReceiver)this)._002Ector();
	}
}
