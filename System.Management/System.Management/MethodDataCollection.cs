using System.Collections;

namespace System.Management;

/// <summary>Represents the set of methods available in the collection.          </summary>
public class MethodDataCollection : ICollection, IEnumerable
{
	/// <summary>Represents the enumerator for <see cref="T:System.Management.MethodData" /> objects in the <see cref="T:System.Management.MethodDataCollection" />. </summary>
	public class MethodDataEnumerator : IEnumerator
	{
		/// <summary>Returns the current <see cref="T:System.Management.MethodData" /> in the <see cref="T:System.Management.MethodDataCollection" /> enumeration.</summary>
		/// <returns>The current <see cref="T:System.Management.MethodData" /> item in the collection.</returns>
		public MethodData Current
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

		internal MethodDataEnumerator()
		{
		}

		/// <summary>Moves to the next element in the <see cref="T:System.Management.MethodDataCollection" /> enumeration.</summary>
		/// <returns>
		///     <see langword="true" /> if the enumerator was successfully advanced to the next method; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		public bool MoveNext()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}

		/// <summary>Resets the enumerator to the beginning of the <see cref="T:System.Management.MethodDataCollection" /> enumeration.</summary>
		public void Reset()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the number of objects in the <see cref="T:System.Management.MethodDataCollection" /> collection.         </summary>
	/// <returns>Returns an <see cref="T:System.Int32" /> value representing the number of objects in the collection.</returns>
	public int Count
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets a value that indicates whether the object is synchronized.          </summary>
	/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the object is synchronized.</returns>
	public bool IsSynchronized
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the specified <see cref="T:System.Management.MethodData" /> from the <see cref="T:System.Management.MethodDataCollection" />.          </summary>
	/// <param name="methodName">The name of the method requested.</param>
	/// <returns>Returns a <see cref="T:System.Management.MethodData" /> containing the method data for a specified method from the collection.</returns>
	public virtual MethodData this[string methodName]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the object to be used for synchronization.          </summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value representing the object to be used for synchronization.</returns>
	public object SyncRoot
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal MethodDataCollection()
	{
	}

	/// <summary>Adds a <see cref="T:System.Management.MethodData" /> to the <see cref="T:System.Management.MethodDataCollection" />. This overload will add a new method with no parameters to the collection.          </summary>
	/// <param name="methodName">The name of the method to add.</param>
	public virtual void Add(string methodName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Adds a <see cref="T:System.Management.MethodData" /> to the <see cref="T:System.Management.MethodDataCollection" />. This overload will add a new method with the specified parameter objects to the collection.          </summary>
	/// <param name="methodName">The name of the method to add.</param>
	/// <param name="inParameters">The <see cref="T:System.Management.ManagementBaseObject" /> holding the input parameters to the method. </param>
	/// <param name="outParameters">The <see cref="T:System.Management.ManagementBaseObject" /> holding the output parameters to the method. </param>
	public virtual void Add(string methodName, ManagementBaseObject inParameters, ManagementBaseObject outParameters)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the <see cref="T:System.Management.MethodDataCollection" /> into an array.          </summary>
	/// <param name="array">The array to which to copy the collection. </param>
	/// <param name="index">The index from which to start. </param>
	public void CopyTo(Array array, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the <see cref="T:System.Management.MethodDataCollection" /> to a specialized <see cref="T:System.Management.MethodData" /> array.          </summary>
	/// <param name="methodArray">The destination array to which to copy the <see cref="T:System.Management.MethodData" /> objects.</param>
	/// <param name="index">The index in the destination array from which to start the copy.</param>
	public void CopyTo(MethodData[] methodArray, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns an enumerator for the <see cref="T:System.Management.MethodDataCollection" />.          </summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> to enumerate through the collection.</returns>
	public MethodDataEnumerator GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Removes a <see cref="T:System.Management.MethodData" /> from the <see cref="T:System.Management.MethodDataCollection" />.          </summary>
	/// <param name="methodName">The name of the method to remove from the collection.</param>
	public virtual void Remove(string methodName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> that iterates through the <see cref="T:System.Management.MethodDataCollection" />.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Management.MethodDataCollection" />.</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
