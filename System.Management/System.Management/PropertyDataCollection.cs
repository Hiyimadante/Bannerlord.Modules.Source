using System.Collections;

namespace System.Management;

/// <summary>Represents the set of properties of a WMI object.</summary>
public class PropertyDataCollection : ICollection, IEnumerable
{
	/// <summary>Represents the enumerator for <see cref="T:System.Management.PropertyData" /> objects in the <see cref="T:System.Management.PropertyDataCollection" />. </summary>
	public class PropertyDataEnumerator : IEnumerator
	{
		/// <summary>Gets the current <see cref="T:System.Management.PropertyData" /> in the <see cref="T:System.Management.PropertyDataCollection" /> enumeration.</summary>
		/// <returns>The current <see cref="T:System.Management.PropertyData" /> element in the collection.</returns>
		public PropertyData Current
		{
			get
			{
				throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
			}
		}

		/// <summary>Gets the current object in the collection.</summary>
		/// <returns>Returns the current element in the collection.</returns>
		/// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created.</exception>
		object IEnumerator.Current
		{
			get
			{
				throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
			}
		}

		internal PropertyDataEnumerator()
		{
		}

		/// <summary>Moves to the next element in the <see cref="T:System.Management.PropertyDataCollection" /> enumeration.</summary>
		/// <returns>
		///     <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		public bool MoveNext()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}

		/// <summary>Resets the enumerator to the beginning of the <see cref="T:System.Management.PropertyDataCollection" /> enumeration.</summary>
		public void Reset()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the number of objects in the <see cref="T:System.Management.PropertyDataCollection" />.          </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value representing the number of objects in the collection.</returns>
	public int Count
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets a value indicating whether the object is synchronized.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the object is synchronized.</returns>
	public bool IsSynchronized
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the specified property from the <see cref="T:System.Management.PropertyDataCollection" />, using [] syntax. This property is the indexer for the <see cref="T:System.Management.PropertyDataCollection" /> class.</summary>
	/// <param name="propertyName">The name of the property to retrieve.</param>
	/// <returns>Returns a <see cref="T:System.Management.PropertyData" /> containing the data for a specified property in the collection.</returns>
	public virtual PropertyData this[string propertyName]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the object to be used for synchronization.          </summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value containing the object to be used for synchronization.</returns>
	public object SyncRoot
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal PropertyDataCollection()
	{
	}

	/// <summary>Adds a new <see cref="T:System.Management.PropertyData" /> with no assigned value.          </summary>
	/// <param name="propertyName">The name of the property.</param>
	/// <param name="propertyType">The Common Information Model (CIM) type of the property.</param>
	/// <param name="isArray">
	///       <see langword="true" /> to specify that the property is an array type; otherwise, <see langword="false" />.</param>
	public void Add(string propertyName, CimType propertyType, bool isArray)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Adds a new <see cref="T:System.Management.PropertyData" /> with the specified value. The value cannot be null and must be convertible to a Common Information Model (CIM) type.          </summary>
	/// <param name="propertyName">The name of the new property.</param>
	/// <param name="propertyValue">The value of the property (cannot be null).</param>
	public virtual void Add(string propertyName, object propertyValue)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Adds a new <see cref="T:System.Management.PropertyData" /> with the specified value and Common Information Model (CIM) type.          </summary>
	/// <param name="propertyName">The name of the property.</param>
	/// <param name="propertyValue">The value of the property (which can be null).</param>
	/// <param name="propertyType">The CIM type of the property.</param>
	public void Add(string propertyName, object propertyValue, CimType propertyType)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the <see cref="T:System.Management.PropertyDataCollection" /> into an array.          </summary>
	/// <param name="array">The array to which to copy the <see cref="T:System.Management.PropertyDataCollection" />. </param>
	/// <param name="index">The index from which to start copying. </param>
	public void CopyTo(Array array, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the <see cref="T:System.Management.PropertyDataCollection" /> to a specialized <see cref="T:System.Management.PropertyData" /> object array.          </summary>
	/// <param name="propertyArray">The destination array to contain the copied <see cref="T:System.Management.PropertyDataCollection" />.</param>
	/// <param name="index">The index in the destination array from which to start copying. </param>
	public void CopyTo(PropertyData[] propertyArray, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns the enumerator for this <see cref="T:System.Management.PropertyDataCollection" />.          </summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
	public PropertyDataEnumerator GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Removes a <see cref="T:System.Management.PropertyData" /> from the <see cref="T:System.Management.PropertyDataCollection" />.          </summary>
	/// <param name="propertyName">The name of the property to be removed.</param>
	public virtual void Remove(string propertyName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> that iterates through the <see cref="T:System.Management.PropertyDataCollection" />.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Management.PropertyDataCollection" />.</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
