using System.Numerics;

namespace MathLib
{
	public struct Vec3
	{
	#region Global Vectors

		public static Vec3 zero = new();
		public static Vec3 One = new(1, 1, 1);
		public static Vec3 half = new(0.5f, 0.5f, 0.5f);
		public static Vec3 up = new(0, -1, 0);
		public static Vec3 down = new(0, 1, 0);
		public static Vec3 right = new(1, 0, 0);
		public static Vec3 left = new(-1, 0, 0);
		public static Vec3 forward = new(0, 0, 1);
		public static Vec3 back = new(0, 0, -1);

	#endregion

		public float x;
		public float y;
		public float z;

		public Vec3(float _x, float _y, float _z)
		{
			x = _x;
			y = _y;
			z = _z;
		}

		/// <summary>
		/// Normalizing 
		/// </summary>
		public Vec3 Normalized => this / Magnitude();

		/// <summary>
		/// Normalizes to 1
		/// </summary>
		public void Normalize()
		{
			float mag = Magnitude();
			if(mag == 0)
			{
				x = 0;
				y = 0;
				z = 0;
			}
			else
			{
				x /= mag;
				y /= mag;
				z /= mag;
			}
		}

		/// <summary>
		/// The Magnitude Of The Vector
		/// </summary>
		/// <returns></returns>
		public float Magnitude()
		{
			return MathF.Sqrt(SqrMagnitude());
		}

		/// <summary>
		/// The Sqr Magnitude 
		/// </summary>
		/// <returns></returns>
		public float SqrMagnitude()
		{
			return x * x + y * y + z * z;
		}

		/// <summary>
		/// Converting To String 
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"({x}, {y}, {z})";

		/// <summary>
		/// Getting The Hash Code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() => HashCode.Combine(x.GetHashCode(), y.GetHashCode());

		public override bool Equals(object? _obj)
		{
			if(_obj == null)
				return false;

			return (Vec3) _obj == this;
		}

	#region Operators

		/// <summary>
		/// Linear interpolation
		/// </summary>
		/// <param name="_a"></param>
		/// <param name="_b"></param>
		/// <param name="_t"></param>
		/// <returns></returns>
		public static Vec3 Lerp(Vec3 _a, Vec3 _b, float _t)
		{
			_t = Azimath.Clamp01(_t);

			return _a * (1 - _t) + _b * _t;
		}

		/// <summary>
		/// Dot Product
		/// </summary>
		/// <param name="_lhs"></param>
		/// <param name="_rhs"></param>
		/// <returns></returns>
		public static float Dot(Vec3 _lhs, Vec3 _rhs)
		{
			return _lhs.x * _rhs.x + _lhs.y * _rhs.y + _lhs.z * _rhs.z;
		}

		/// <summary>
		/// Checking The Distance 
		/// </summary>
		/// <param name="_lhs"></param>
		/// <param name="_rhs"></param>
		/// <returns></returns>
		public static float Distance(Vec3 _lhs, Vec3 _rhs)
		{
			return (_lhs - _rhs).Magnitude();
		}

		public static Vec3 operator +(Vec3 _lhs, Vec3 _rhs)
		{
			return new Vec3(_lhs.x + _rhs.x, _lhs.y + _rhs.y, _lhs.z + _rhs.z);
		}

		public static Vec3 operator -(Vec3 _lhs, Vec3 _rhs)
		{
			return new Vec3(_lhs.x - _rhs.x, _lhs.y - _rhs.y, _lhs.z - _rhs.z);
		}

		public static Vec3 operator *(Vec3 _lhs, float _rhs)
		{
			return new Vec3(_lhs.x * _rhs, _lhs.y * _rhs, _lhs.z * _rhs);
		}

		public static Vec3 operator *(float _lhs, Vec3 _rhs)
		{
			return new Vec3(_lhs * _rhs.x, _lhs * _rhs.y, _lhs * _rhs.z);
		}

		public static Vec3 operator /(Vec3 _lhs, float _rhs)
		{
			return new Vec3(_lhs.x / _rhs, _lhs.y / _rhs, _lhs.z / _rhs);
		}

		public static bool operator ==(Vec3 _lhs, Vec3 _rhs)
		{
			return Azimath.Approximately(_lhs.x, _rhs.x) && Azimath.Approximately(_lhs.y, _rhs.y) && Azimath.Approximately(_lhs.z, _rhs.z);
		}

		public static bool operator !=(Vec3 _lhs, Vec3 _rhs)
		{
			return !(_lhs == _rhs);
		}

		public static implicit operator Vec3(Vector3 _vector)
		{
			return new Vec3(_vector.X, _vector.Y, _vector.Z);
		}

		public static implicit operator Vector3(Vec3 _vec)
		{
			return new Vector3(_vec.x, _vec.y, _vec.z);
		}

	#endregion
	}
}