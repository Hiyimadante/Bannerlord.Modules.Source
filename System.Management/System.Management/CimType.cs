namespace System.Management;

/// <summary>Describes the possible CIM types for properties, qualifiers, or method parameters.          </summary>
public enum CimType
{
	/// <summary>A null value.</summary>
	None = 0,
	/// <summary>A signed 16-bit integer. This value maps to the <see cref="T:System.Int16" /> type.</summary>
	SInt16 = 2,
	/// <summary>A signed 32-bit integer. This value maps to the <see cref="T:System.Int32" /> type.</summary>
	SInt32 = 3,
	/// <summary>A floating-point 32-bit number. This value maps to the <see cref="T:System.Single" /> type.</summary>
	Real32 = 4,
	/// <summary>A floating point 64-bit number. This value maps to the <see cref="T:System.Double" /> type.</summary>
	Real64 = 5,
	/// <summary>A string. This value maps to the <see cref="T:System.String" /> type.</summary>
	String = 8,
	/// <summary>A Boolean. This value maps to the <see cref="T:System.Boolean" /> type.</summary>
	Boolean = 11,
	/// <summary>An embedded object. Note that embedded objects differ from references in that the embedded object does not have a path and its lifetime is identical to the lifetime of the containing object. This value maps to the <see cref="T:System.Object" /> type.</summary>
	Object = 13,
	/// <summary>A signed 8-bit integer. This value maps to the <see cref="T:System.SByte" /> type.</summary>
	SInt8 = 16,
	/// <summary>An unsigned 8-bit integer. This value maps to the <see cref="T:System.Byte" /> type.</summary>
	UInt8 = 17,
	/// <summary>An unsigned 16-bit integer. This value maps to the <see cref="T:System.UInt16" /> type.</summary>
	UInt16 = 18,
	/// <summary>An unsigned 32-bit integer. This value maps to the <see cref="T:System.UInt32" /> type.</summary>
	UInt32 = 19,
	/// <summary>A signed 64-bit integer. This value maps to the <see cref="T:System.Int64" /> type.</summary>
	SInt64 = 20,
	/// <summary>An unsigned 64-bit integer. This value maps to the <see cref="T:System.UInt64" /> type.</summary>
	UInt64 = 21,
	/// <summary>A date or time value, represented in a string in DMTF date/time format: yyyymmddHHMMSS.mmmmmmsUUU, where yyyymmdd is the date in year/month/day; HHMMSS is the time in hours/minutes/seconds; mmmmmm is the number of microseconds in 6 digits; and sUUU is a sign (+ or -) and a 3-digit UTC offset. This value maps to the <see cref="T:System.DateTime" /> type.</summary>
	DateTime = 101,
	/// <summary>A reference to another object. This is represented by a string containing the path to the referenced object. This value maps to the <see cref="T:System.Int16" /> type.</summary>
	Reference = 102,
	/// <summary>A 16-bit character. This value maps to the <see cref="T:System.Char" /> type.</summary>
	Char16 = 103
}
