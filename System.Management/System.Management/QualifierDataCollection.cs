using System.Collections;

namespace System.Management;

/// <summary>Represents a collection of <see cref="T:System.Management.QualifierData" /> objects.          </summary>
public class QualifierDataCollection : ICollection, IEnumerable
{
	/// <summary>Represents the enumerator for <see cref="T:System.Management.QualifierData" /> objects in the <see cref="T:System.Management.QualifierDataCollection" />. </summary>
	public class QualifierDataEnumerator : IEnumerator
	{
		/// <summary>Gets or sets the current <see cref="T:System.Management.QualifierData" /> in the <see cref="T:System.Management.QualifierDataCollection" /> enumeration.</summary>
		/// <returns>The current <see cref="T:System.Management.QualifierData" /> element in the collection.</returns>
		public QualifierData Current
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

		internal QualifierDataEnumerator()
		{
		}

		/// <summary>Moves to the next element in the <see cref="T:System.Management.QualifierDataCollection" /> enumeration.</summary>
		/// <returns>
		///     <see langword="true" /> if the enumerator was successfully advanced to the next element; <see langword="false" /> if the enumerator has passed the end of the collection.</returns>
		public bool MoveNext()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}

		/// <summary>Resets the enumerator to the beginning of the <see cref="T:System.Management.QualifierDataCollection" /> enumeration.</summary>
		public void Reset()
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the number of <see cref="T:System.Management.QualifierData" /> objects in the <see cref="T:System.Management.QualifierDataCollection" />.          </summary>
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

	/// <summary>Gets the specified <see cref="T:System.Management.QualifierData" /> from the <see cref="T:System.Management.QualifierDataCollection" />.          </summary>
	/// <param name="qualifierName">The name of the <see cref="T:System.Management.QualifierData" /> to access in the <see cref="T:System.Management.QualifierDataCollection" />. </param>
	/// <returns>Returns a <see cref="T:System.Management.QualifierData" /> containing the data for a specified qualifier in the collection.</returns>
	public virtual QualifierData this[string qualifierName]
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	/// <summary>Gets the object to be used for synchronization.          </summary>
	/// <returns>Returns an <see cref="T:System.Object" /> value to be used for synchronization.</returns>
	public object SyncRoot
	{
		get
		{
			throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
		}
	}

	internal QualifierDataCollection()
	{
	}

	/// <summary>Adds a <see cref="T:System.Management.QualifierData" /> to the <see cref="T:System.Management.QualifierDataCollection" />. This overload specifies the qualifier name and value.          </summary>
	/// <param name="qualifierName">The name of the <see cref="T:System.Management.QualifierData" /> to be added to the <see cref="T:System.Management.QualifierDataCollection" />. </param>
	/// <param name="qualifierValue">The value for the new qualifier. </param>
	public virtual void Add(string qualifierName, object qualifierValue)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Adds a <see cref="T:System.Management.QualifierData" /> to the <see cref="T:System.Management.QualifierDataCollection" />. This overload specifies all property values for a <see cref="T:System.Management.QualifierData" />.          </summary>
	/// <param name="qualifierName">The qualifier name. </param>
	/// <param name="qualifierValue">The qualifier value. </param>
	/// <param name="isAmended">
	///       <see langword="true" /> to specify that this qualifier is amended (<paramref name="flavor" />); otherwise, <see langword="false" />. </param>
	/// <param name="propagatesToInstance">
	///       <see langword="true" /> to propagate this qualifier to instances; otherwise, <see langword="false" />. </param>
	/// <param name="propagatesToSubclass">
	///       <see langword="true" /> to propagate this qualifier to subclasses; otherwise, <see langword="false" />. </param>
	/// <param name="isOverridable">
	///       <see langword="true" /> to specify that this qualifier's value is overridable in instances of subclasses; otherwise, <see langword="false" />. </param>
	public virtual void Add(string qualifierName, object qualifierValue, bool isAmended, bool propagatesToInstance, bool propagatesToSubclass, bool isOverridable)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the <see cref="T:System.Management.QualifierDataCollection" /> into an array.          </summary>
	/// <param name="array">The array to which to copy the <see cref="T:System.Management.QualifierDataCollection" />. </param>
	/// <param name="index">The index from which to start copying. </param>
	public void CopyTo(Array array, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Copies the <see cref="T:System.Management.QualifierDataCollection" /> into a specialized              <see cref="T:System.Management.QualifierData" /> array.          </summary>
	/// <param name="qualifierArray">The specialized array of <see cref="T:System.Management.QualifierData" /> objects to which to copy the <see cref="T:System.Management.QualifierDataCollection" />.</param>
	/// <param name="index">The index from which to start copying. </param>
	public void CopyTo(QualifierData[] qualifierArray, int index)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns an enumerator for the <see cref="T:System.Management.QualifierDataCollection" />. This method is strongly typed.          </summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> that can be used to iterate through the collection.</returns>
	public QualifierDataEnumerator GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Removes a <see cref="T:System.Management.QualifierData" /> from the <see cref="T:System.Management.QualifierDataCollection" /> by name.          </summary>
	/// <param name="qualifierName">The name of the <see cref="T:System.Management.QualifierData" /> to remove. </param>
	public virtual void Remove(string qualifierName)
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}

	/// <summary>Returns an <see cref="T:System.Collections.IEnumerator" /> that iterates through the <see cref="T:System.Management.QualifierDataCollection" />.</summary>
	/// <returns>An <see cref="T:System.Collections.IEnumerator" /> for the <see cref="T:System.Management.QualifierDataCollection" />.</returns>
	IEnumerator IEnumerable.GetEnumerator()
	{
		throw new PlatformNotSupportedException(System.SR.PlatformNotSupported_SystemManagement);
	}
}
