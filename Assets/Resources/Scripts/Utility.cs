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

	/// <summary>
	/// Rotate to direction (for top down)
	/// </summary>
	/// <param name="dir">direction of rotation</param>
	public static Quaternion TopDownRotationFromDirection(Vector2 dir) {
		return Quaternion.LookRotation(Vector3.forward, dir);
	}

	/// <summary>
	/// Return the smallest vector
	/// </summary>
	public static Vector3 MinVec3(Vector3 a, Vector3 b) {
		return a.sqrMagnitude <= b.sqrMagnitude ? a : b;
	}

	public static bool Similiar(this Vector3 a, Vector3 b) {
		if(Mathf.Approximately(a.x, b.x) && Mathf.Approximately(a.y, b.y) && Mathf.Approximately(a.z, b.z)) {
			return true;
		}
		return false;
	}
}
