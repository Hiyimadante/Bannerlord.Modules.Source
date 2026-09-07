using System.Runtime.CompilerServices;
using NavalDLC.Missions.Objects;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;
using TaleWorlds.ObjectSystem;

namespace NavalDLC;

public class ShipAssignment
{
	[CompilerGenerated]
	private TeamSideEnum _003CTeamSide_003Ek__BackingField;

	[CompilerGenerated]
	private FormationClass _003CFormationIndex_003Ek__BackingField;

	public TeamSideEnum TeamSide
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CTeamSide_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CTeamSide_003Ek__BackingField = value;
		}
	}

	public FormationClass FormationIndex
	{
		[CompilerGenerated]
		get
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			return _003CFormationIndex_003Ek__BackingField;
		}
		[CompilerGenerated]
		private set
		{
			//IL_0001: Unknown result type (might be due to invalid IL or missing references)
			//IL_0002: Unknown result type (might be due to invalid IL or missing references)
			_003CFormationIndex_003Ek__BackingField = value;
		}
	}

	public MissionShipObject MissionShipObject { get; private set; }

	public IShipOrigin ShipOrigin { get; private set; }

	public MissionShip MissionShip { get; private set; }

	public Formation Formation => MissionShip?.Formation;

	public bool IsSet
	{
		get
		{
			if (ShipOrigin != null)
			{
				return MissionShipObject != null;
			}
			return false;
		}
	}

	public bool HasMissionShip
	{
		get
		{
			if (IsSet)
			{
				return MissionShip != null;
			}
			return false;
		}
	}

	internal void Set(IShipOrigin shipOrigin)
	{
		ShipOrigin = shipOrigin;
		IShipOrigin shipOrigin2 = ShipOrigin;
		if (!string.IsNullOrEmpty((shipOrigin2 != null) ? shipOrigin2.OriginShipId : null))
		{
			MissionShipObject = MBObjectManager.Instance.GetObject<MissionShipObject>(ShipOrigin.OriginShipId);
		}
		MissionShip = null;
	}

	internal void RemoveShip()
	{
		MissionShip = null;
	}

	internal void Clear()
	{
		ShipOrigin = null;
		MissionShipObject = null;
		MissionShip = null;
	}

	internal void SetMissionShip(MissionShip missionShip)
	{
		MissionShip = missionShip;
		ShipOrigin = missionShip.ShipOrigin;
		MissionShipObject = missionShip.MissionShipObject;
	}

	internal static ShipAssignment Create(TeamSideEnum teamSide, FormationClass formationIndex, IShipOrigin shipOrigin = null)
	{
		//IL_0000: Unknown result type (might be due to invalid IL or missing references)
		//IL_0001: Unknown result type (might be due to invalid IL or missing references)
		return new ShipAssignment(teamSide, formationIndex, shipOrigin);
	}

	private ShipAssignment(TeamSideEnum teamSide, FormationClass formationIndex, IShipOrigin shipOrigin = null)
	{
		//IL_000e: Unknown result type (might be due to invalid IL or missing references)
		//IL_0015: Unknown result type (might be due to invalid IL or missing references)
		base._002Ector();
		ShipOrigin = shipOrigin;
		TeamSide = teamSide;
		FormationIndex = formationIndex;
		if (shipOrigin != null)
		{
			Set(shipOrigin);
			return;
		}
		ShipOrigin = null;
		MissionShipObject = null;
		MissionShip = null;
	}
}
