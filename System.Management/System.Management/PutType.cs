namespace System.Management;

/// <summary>Describes the possible effects of saving an object to WMI when using <see cref="M:System.Management.ManagementObject.Put" />.          </summary>
public enum PutType
{
	/// <summary>No change.</summary>
	None,
	/// <summary>Updates an existing object only; does not create a new object.</summary>
	UpdateOnly,
	/// <summary>Creates an object only; does not update an existing object.</summary>
	CreateOnly,
	/// <summary>Saves the object, whether updating an existing object or creating a new object.</summary>
	UpdateOrCreate
}
