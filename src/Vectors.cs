using Godot;

namespace GGCSAPI {
	public static class Vectors {
		public static Vector3 Clone(this Vector3 vector) {
			return new Vector3(vector.X, vector.Y, vector.Z);
		}

		public static Vector3 SetX(this Vector3 vector, double value) {
			vector.X = (float) value;
			return vector;
		}

		public static Vector3 SetY(this Vector3 vector, double value) {
			vector.Y = (float) value;
			return vector;
		}

		public static Vector3 SetZ(this Vector3 vector, double value) {
			vector.Z = (float) value;
			return vector;
		}

		public static Vector3 OffsetX(this Vector3 vector, double value) {
			return SetX(vector, vector.X + value);
		}

		public static Vector3 OffsetY(this Vector3 vector, double value) {
			return SetY(vector, vector.Y + value);
		}

		public static Vector3 OffsetZ(this Vector3 vector, double value) {
			return SetZ(vector, vector.Z + value);
		}

		public static Vector3 ToDegrees(this Vector3 vector) {
			return new Vector3(Mathf.RadToDeg(vector.X), Mathf.RadToDeg(vector.Y), Mathf.RadToDeg(vector.Z));
		}

		public static Vector3 ToRadians(this Vector3 vector) {
			return new Vector3(Mathf.DegToRad(vector.X), Mathf.DegToRad(vector.Y), Mathf.DegToRad(vector.Z));
		}
	}
}
