using UnityEngine;

public static class Utility {
	/// <summary>
	/// Do complex multiplication
	/// </summary>
	public static Vector2 ComplexMult(this Vector2 aVec, Vector2 aOther) {
		return new Vector2(aVec.x * aOther.x - aVec.y * aOther.y, aVec.x * aOther.y + aVec.y * aOther.x);
	}

	/// <summary>
	/// Convert angle to Complex number
	/// </summary>
	/// <param name="aDegree">Angle in degree</param>
	/// <returns></returns>
	public static Vector2 Rotation(float aDegree) {
		float a = aDegree * Mathf.Deg2Rad;
		return new Vector2(Mathf.Cos(a), Mathf.Sin(a));
	}

	/// <summary>
	/// Rotate aVec by aDegree counter clockwise
	/// </summary>
	public static Vector2 RotateCCW(this Vector2 aVec, float aDegree) {
		return ComplexMult(aVec, Rotation(aDegree));
	}

	/// <summary>
	/// Rotate aVec by aDegree clockwise
	/// </summary>
	public static Vector2 RotateCW(this Vector2 aVec, float aDegree) {
		return ComplexMult(aVec, Rotation(-aDegree));
	}
}
