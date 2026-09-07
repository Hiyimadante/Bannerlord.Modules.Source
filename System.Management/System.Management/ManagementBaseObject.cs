using System.ComponentModel;
using System.Runtime.Serialization;

namespace System.Management;

/// <summary>Contains the basic elements of a management object. It serves as a base class to more specific management object classes.</summary>
[ToolboxItem(false)]
public class ManagementBaseObject : Component, ICloneable, ISerializable
{
	/// <summary>Gets the path to the management object's class.</summary>
	/// <returns>Returns a <see cref="T:System.Management.ManagementPath" /> that contains the class path to the management object's class.</returns>
	public virtual ManagementPath ClassPath
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets access to property values through [] notation. This property is the indexer for the <see cref="T:System.Management.ManagementBaseObject" /> class. You can use the default indexed properties defined by a type, but you cannot explicitly define your own. However, specifying the expando attribute on a class automatically provides a default indexed property whose type is Object and whose index type is String.</summary>
	/// <param name="propertyName">The name of the property of interest. </param>
	/// <returns>Returns an <see cref="T:System.Object" /> value that contains the management object for a specific class property.</returns>
	public object this[string propertyName]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
		set
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets a collection of <see cref="T:System.Management.PropertyData" /> objects describing the properties of the management object.</summary>
	/// <returns>Returns a <see cref="T:System.Management.PropertyDataCollection" /> that holds the properties for the management object.</returns>
	public virtual PropertyDataCollection Properties
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the collection of <see cref="T:System.Management.QualifierData" /> objects defined on the management object. Each element in the collection holds information such as the qualifier name, value, and flavor.</summary>
	/// <returns>Returns a <see cref="T:System.Management.QualifierDataCollection" /> that holds the qualifiers for the management object.</returns>
	public virtual QualifierDataCollection Qualifiers
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets  the collection of WMI system properties of the management object (for example, the class name, server, and namespace). WMI system property names begin with "__".</summary>
	/// <returns>Returns a <see cref="T:System.Management.PropertyDataCollection" /> that contains the system properties for a management object.</returns>
	public virtual PropertyDataCollection SystemProperties
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementBaseObject" /> class that is serializable.</summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
	/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" /> ) for this serialization.</param>
	protected ManagementBaseObject(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a copy of the object.</summary>
	/// <returns>The new cloned object.</returns>
	public virtual object Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Compares this object to another, based on specified options.</summary>
	/// <param name="otherObject">The object to which to compare this object. </param>
	/// <param name="settings">Options on how to compare the objects. </param>
	/// <returns>
	///     <see langword="true" /> if the objects compared are equal according to the given options; otherwise, <see langword="false" />.</returns>
	public bool CompareTo(ManagementBaseObject otherObject, ComparisonSettings settings)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Releases the unmanaged resources used by the ManagementBaseObject.</summary>
	public new void Dispose()
	{
	}

	/// <summary>Compares two management objects.</summary>
	/// <param name="obj">An object to compare with this instance.</param>
	/// <returns>
	///     <see langword="true" /> if this is an instance of <see cref="T:System.Management.ManagementBaseObject" /> and represents the same object as this instance; otherwise, <see langword="false" />.             </returns>
	public override bool Equals(object obj)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Serves as a hash function for a particular type, suitable for use in hashing algorithms and data structures like a hash table.</summary>
	/// <returns>A hash code for the current object.</returns>
	public override int GetHashCode()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data necessary to deserialize the field represented by this instance.</summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
	/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" /> ) for this serialization.</param>
	protected virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the value of the specified property qualifier.</summary>
	/// <param name="propertyName">The name of the property to which the qualifier belongs. </param>
	/// <param name="qualifierName">The name of the property qualifier of interest. </param>
	/// <returns>The value of the specified qualifier.</returns>
	public object GetPropertyQualifierValue(string propertyName, string qualifierName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets an equivalent accessor to a property's value.</summary>
	/// <param name="propertyName">The name of the property of interest. </param>
	/// <returns>The value of the specified property.</returns>
	public object GetPropertyValue(string propertyName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Gets the value of the specified qualifier.          </summary>
	/// <param name="qualifierName">The name of the qualifier of interest. </param>
	/// <returns>The value of the specified qualifier.</returns>
	public object GetQualifierValue(string qualifierName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns a textual representation of the object in the specified format.          </summary>
	/// <param name="format">The requested textual format. </param>
	/// <returns>The textual representation of the object in the specified format.</returns>
	public string GetText(TextFormat format)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Provides the internal WMI object represented by a <see cref="T:System.Management.ManagementObject" />.  </summary>
	/// <param name="managementObject">The <see cref="T:System.Management.ManagementBaseObject" /> that references the requested WMI object.</param>
	/// <returns>An <see cref="T:System.IntPtr" /> representing the internal WMI object.  </returns>
	public static explicit operator IntPtr(ManagementBaseObject managementObject)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Sets the value of the specified property qualifier.</summary>
	/// <param name="propertyName">The name of the property to which the qualifier belongs.</param>
	/// <param name="qualifierName">The name of the property qualifier of interest.</param>
	/// <param name="qualifierValue">The new value for the qualifier.</param>
	public void SetPropertyQualifierValue(string propertyName, string qualifierName, object qualifierValue)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Sets the value of the named property.</summary>
	/// <param name="propertyName">The name of the property to be changed.</param>
	/// <param name="propertyValue">The new value for this property.</param>
	public void SetPropertyValue(string propertyName, object propertyValue)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Sets the value of the named qualifier.</summary>
	/// <param name="qualifierName">The name of the qualifier to set. This parameter cannot be null.</param>
	/// <param name="qualifierValue">The value to set.</param>
	public void SetQualifierValue(string qualifierName, object qualifierValue)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Implements the <see cref="T:System.Runtime.Serialization.ISerializable" /> interface and returns the data needed to serialize the <see cref="T:System.Management.ManagementBaseObject" />.</summary>
	/// <param name="info">A <see cref="T:System.Runtime.Serialization.SerializationInfo" /> containing the information required to serialize the <see cref="T:System.Management.ManagementBaseObject" />.</param>
	/// <param name="context">A <see cref="T:System.Runtime.Serialization.StreamingContext" /> containing the source and destination of the serialized stream associated with the <see cref="T:System.Management.ManagementBaseObject" />.</param>
	/// <exception cref="T:System.ArgumentNullException">
	///         <paramref name="info" /> is <see langword="null" />.</exception>
	void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
