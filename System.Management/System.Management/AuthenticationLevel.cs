namespace System.Management;

/// <summary>Describes the authentication level to be used to connect to WMI. This is used for the COM connection to WMI.          </summary>
public enum AuthenticationLevel
{
	/// <summary>Authentication level should remain as it was before.</summary>
	Unchanged = -1,
	/// <summary>The default COM authentication level. WMI uses the default Windows Authentication setting.</summary>
	Default,
	/// <summary>No COM authentication.</summary>
	None,
	/// <summary>Connect-level COM authentication.</summary>
	Connect,
	/// <summary>Call-level COM authentication.</summary>
	Call,
	/// <summary>Packet-level COM authentication.</summary>
	Packet,
	/// <summary>Packet Integrity-level COM authentication.</summary>
	PacketIntegrity,
	/// <summary>Packet Privacy-level COM authentication.</summary>
	PacketPrivacy
}
