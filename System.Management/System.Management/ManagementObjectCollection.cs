using System.Collections;

namespace System.Management;

/// <summary>Represents different collections of management objects retrieved through WMI. The objects in this collection are of <see cref="T:System.Management.ManagementBaseObject" />-derived types, including <see cref="T:System.Management.ManagementObject" /> and <see cref="T:System.Management.ManagementClass" />. The collection can be the result of a WMI query executed through a <see cref="T:System.Management.ManagementObjectSearcher" />, or an enumeration of management objects of a specified type retrieved through a <see cref="T:System.Management.ManagementClass" /> representing that type. In addition, this can be a collection of management objects related in a specified way to a specific management object - in this case the collection would be retrieved through a method such as <see cref="M:System.Management.ManagementObject.GetRelated" />. The collection can be walked using the <see cref="T:System.Management.ManagementObjectCollection.ManagementObjectEnumerator" /> and objects in it can be inspected or manipulated for various management tasks.</summary>
public class ManagementObjectCollection : ICollection, IEnumerable, IDisposable
{
	/// <summary>Represents the enumerator on the collection. </summary>
	public class ManagementObjectEnumerator : IEnumerator, IDisposable
	{
		/// <summary>Gets the current <see cref="T:System.Management.ManagementBaseObject" /> that this enumerator points to.</summary>
		/// <returns>The current object in the enumeration.</returns>
		public ManagementBaseObject Current
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

		internal ManagementObjectEnumerator()
		{
		}

		/// <summary>Releases resources associated with this object. After this method has been called, an attempt to use this object will result in an <see cref="T:System.ObjectDisposedException" /> exception being thrown.</summary>
		public void Dispose()
		{
		}

		/// <summary>Indicates whether the enumerator has moved to the next object in the enumeration.</summary>
		/// <returns>
		///     <see langword="true" />, if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		public bool MoveNext()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}

		/// <summary>Resets the enumerator to the beginning of the collection.</summary>
		public void Reset()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets a value indicating the number of objects in the collection.          </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value indicating the number of objects in the collection.</returns>
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

	/// <summary>Gets the object to be used for synchronization.</summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value that represents the object to be used for synchronization.</returns>
	public object SyncRoot
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal ManagementObjectCollection()
	{
	}

	/// <summary>Copies the collection to an array.          </summary>
	/// <param name="array">An array to copy to. </param>
	/// <param name="index">The index to start from. </param>
	public void CopyTo(Array array, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the items in the collection to a <see cref="T:System.Management.ManagementBaseObject" /> array.          </summary>
	/// <param name="objectCollection">The target array.</param>
	/// <param name="index">The index to start from. </param>
	public void CopyTo(ManagementBaseObject[] objectCollection, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Releases resources associated with this object. After this method has been called, an attempt to use this object will result in an <see cref="T:System.ObjectDisposedException" /> being thrown.                       </summary>
	public void Dispose()
	{
	}

	/// <summary>Returns the enumerator for the collection.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
	public ManagementObjectEnumerator GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> that iterates through the <see cref="T:System.Management.ManagementObjectCollection" />.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Management.ManagementObjectCollection" />.</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
