using System.Collections.Specialized;
using System.Runtime.Serialization;

namespace System.Management;

/// <summary>Represents a collection of named values suitable for use as context information to WMI operations. The names are case-insensitive.          </summary>
public class ManagementNamedValueCollection : NameObjectCollectionBase
{
	/// <summary>Gets the value associated with the specified name from this collection. In C#, this property is the indexer for the <see cref="T:System.Management.ManagementNamedValueCollection" /> class.  </summary>
	/// <param name="name">The name of the value to be returned. </param>
	/// <returns>Returns an <see cref="T:System.Object" /> value that is associated with the specified name from this collection.</returns>
	public object this[string name]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementNamedValueCollection" /> class, which is empty. This is the default constructor.          </summary>
	public ManagementNamedValueCollection()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementNamedValueCollection" /> class that is serializable                 and uses the specified <see cref="T:System.Runtime.Serialization.SerializationInfo" /> and <see cref="T:System.Runtime.Serialization.StreamingContext" />.          </summary>
	/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
	/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" /> ) for this serialization.</param>
	protected ManagementNamedValueCollection(SerializationInfo info, StreamingContext context)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Adds a single-named value to the collection.          </summary>
	/// <param name="name">The name of the new value.</param>
	/// <param name="value">The value to be associated with the name.</param>
	public void Add(string name, object value)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Creates a clone of the collection. Individual values are cloned. If a value does not support cloning, then a <see cref="T:System.NotSupportedException" /> is thrown.           </summary>
	/// <returns>The new copy of the collection.             </returns>
	public ManagementNamedValueCollection Clone()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Removes a single-named value from the collection. If the collection does not contain an element with the specified name, the collection remains unchanged and no exception is thrown.          </summary>
	/// <param name="name">The name of the value to be removed. </param>
	public void Remove(string name)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Removes all entries from the collection.          </summary>
	public void RemoveAll()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
