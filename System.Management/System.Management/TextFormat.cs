namespace System.Management;

/// <summary>Describes the possible text formats that can be used with <see cref="M:System.Management.ManagementBaseObject.GetText(System.Management.TextFormat)" />.          </summary>
public enum TextFormat
{
	/// <summary>
	///     Managed Object Format
	///   </summary>
	Mof,
	/// <summary>XML DTD that corresponds to CIM DTD version 2.0.             </summary>
	CimDtd20,
	/// <summary>XML WMI DTD that corresponds to CIM DTD version 2.0. Using this value enables a few WMI-specific extensions, like embedded objects.             </summary>
	WmiDtd20
}
