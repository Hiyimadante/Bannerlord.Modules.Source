using NavalDLC.Map;
using NavalDLC.Storyline;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.Party;

namespace NavalDLC;

public class NavalDLCEvents : CampaignEventReceiver
{
	private readonly MbEvent<PartyBase, NavalStorylinePartyData> _isPartyQuestPartyEvent;

	private readonly MbEvent<bool> _onNavalStorylineActivityChangedEvent;

	private readonly MbEvent _onGunnarSavedEvent;

	private readonly MbEvent _onSisterRansomRequestedEvent;

	private readonly MbEvent _onSisterRansomedEvent;

	private readonly MbEvent<NavalStorylineData.StorylineCancelDetail> _onNavalStorylineCanceledEvent;

	private readonly MbEvent _onNavalStorylineTutorialSkippedEvent;

	private readonly MbEvent<Storm> _onStormCreatedEvent;

	public static NavalDLCEvents Instance => NavalDLCManager.Instance.NavalDLCEvents;

	public static IMbEvent<PartyBase, NavalStorylinePartyData> IsNavalQuestPartyEvent => (IMbEvent<PartyBase, NavalStorylinePartyData>)(object)Instance._isPartyQuestPartyEvent;

	public static IMbEvent<bool> OnNavalStorylineActivityChangedEvent => (IMbEvent<bool>)(object)Instance._onNavalStorylineActivityChangedEvent;

	public static IMbEvent OnSisterRansomedEvent => (IMbEvent)(object)Instance._onSisterRansomedEvent;

	public static IMbEvent OnGunnarSavedEvent => (IMbEvent)(object)Instance._onGunnarSavedEvent;

	public static IMbEvent OnSisterRansomRequestedEvent => (IMbEvent)(object)Instance._onSisterRansomRequestedEvent;

	public static IMbEvent<NavalStorylineData.StorylineCancelDetail> OnNavalStorylineCanceledEvent => (IMbEvent<NavalStorylineData.StorylineCancelDetail>)(object)Instance._onNavalStorylineCanceledEvent;

	public static IMbEvent OnNavalStorylineTutorialSkippedEvent => (IMbEvent)(object)Instance._onNavalStorylineTutorialSkippedEvent;

	public static IMbEvent<Storm> OnStormCreatedEvent => (IMbEvent<Storm>)(object)Instance._onStormCreatedEvent;

	public override void RemoveListeners(object obj)
	{
		_onNavalStorylineActivityChangedEvent.ClearListeners(obj);
		_isPartyQuestPartyEvent.ClearListeners(obj);
		_onGunnarSavedEvent.ClearListeners(obj);
		_onNavalStorylineCanceledEvent.ClearListeners(obj);
		_onStormCreatedEvent.ClearListeners(obj);
		_onSisterRansomedEvent.ClearListeners(obj);
		_onSisterRansomRequestedEvent.ClearListeners(obj);
		_onNavalStorylineTutorialSkippedEvent.ClearListeners(obj);
	}

	public void IsNavalQuestParty(PartyBase party, NavalStorylinePartyData result)
	{
		Instance._isPartyQuestPartyEvent.Invoke(party, result);
	}

	public void OnNavalStorylineActivityChanged(bool activity)
	{
		Instance._onNavalStorylineActivityChangedEvent.Invoke(activity);
	}

	public void OnSisterRansomRequested()
	{
		Instance._onSisterRansomRequestedEvent.Invoke();
	}

	public void OnSisterRansomed()
	{
		Instance._onSisterRansomedEvent.Invoke();
	}

	public void OnGunnarSaved()
	{
		Instance._onGunnarSavedEvent.Invoke();
	}

	public void OnNavalStorylineCanceled(NavalStorylineData.StorylineCancelDetail detail)
	{
		Instance._onNavalStorylineCanceledEvent.Invoke(detail);
	}

	public void OnNavalStorylineTutorialSkipped()
	{
		Instance._onNavalStorylineTutorialSkippedEvent.Invoke();
	}

	public void OnStormCreated(Storm storm)
	{
		Instance._onStormCreatedEvent.Invoke(storm);
	}

	public NavalDLCEvents()
	{
		//IL_0017: Unknown result type (might be due to invalid IL or missing references)
		//IL_0021: Expected O, but got Unknown
		//IL_0022: Unknown result type (might be due to invalid IL or missing references)
		//IL_002c: Expected O, but got Unknown
		//IL_002d: Unknown result type (might be due to invalid IL or missing references)
		//IL_0037: Expected O, but got Unknown
		//IL_0043: Unknown result type (might be due to invalid IL or missing references)
		//IL_004d: Expected O, but got Unknown
		_isPartyQuestPartyEvent = new MbEvent<PartyBase, NavalStorylinePartyData>();
		_onNavalStorylineActivityChangedEvent = new MbEvent<bool>();
		_onGunnarSavedEvent = new MbEvent();
		_onSisterRansomRequestedEvent = new MbEvent();
		_onSisterRansomedEvent = new MbEvent();
		_onNavalStorylineCanceledEvent = new MbEvent<NavalStorylineData.StorylineCancelDetail>();
		_onNavalStorylineTutorialSkippedEvent = new MbEvent();
		_onStormCreatedEvent = new MbEvent<Storm>();
		((CampaignEventReceiver)this)._002Ector();
	}
}
