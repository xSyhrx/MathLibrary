using System.Numerics;

namespace MathLib
{
	public struct Vec4
	{
	#region Global Vectors

		public static Vec4 zero = new();
		public static Vec4 One = new(1, 1, 1, 1);
		public static Vec4 half = new(0.5f, 0.5f, 0.5f, 0.5f);
		public static Vec4 up = new(0, -1, 0, 0);
		public static Vec4 down = new(0, 1, 0, 0);
		public static Vec4 right = new(1, 0, 0, 0);
		public static Vec4 left = new(-1, 0, 0, 0);
		public static Vec4 forward = new(0, 0, 1, 0);
		public static Vec4 back = new(0, 0, -1, 0);

	#endregion

		public float x;
		public float y;
		public float z;
		public float w;

		public Vec4(float _x, float _y, float _z, float _w)
		{
			x = _x;
			y = _y;
			z = _z;
			w = _w;
		}

		/// <summary>
		/// Normalizes to 1
		/// </summary>
		public Vec4 Normalized => this / Magnitude();

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
				w = 0;
			}
			else
			{
				x /= mag;
				y /= mag;
				z /= mag;
				w /= mag;
			}
		}

		/// <summary>
		/// The Magnitude of the vector 
		/// </summary>
		/// <returns></returns>
		public float Magnitude()
		{
			return MathF.Sqrt(SqrMagnitude());
		}

		/// <summary>
		/// the sqr magnitude of the vector 
		/// </summary>
		/// <returns></returns>
		public float SqrMagnitude()
		{
			return x * x + y * y + z * z + w * w;
		}

		/// <summary>
		/// Converting to String 
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"({x}, {y}, {z}, {w})";

		/// <summary>
		/// Getting the Hash Code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() => HashCode.Combine(x.GetHashCode(), y.GetHashCode(), z.GetHashCode(), w.GetHashCode());

		public override bool Equals(object? _obj)
		{
			if(_obj == null)
				return false;

			return (Vec4) _obj == this;
		}

	#region Operators

		/// <summary>
		/// The Dot Product
		/// </summary>
		/// <param name="_lhs"></param>
		/// <param name="_rhs"></param>
		/// <returns></returns>
		public static float Dot(Vec4 _lhs, Vec4 _rhs)
		{
			return _lhs.x * _rhs.x + _lhs.y * _rhs.y + _lhs.z * _rhs.z + _lhs.w * _rhs.w;
		}

		/// <summary>
		/// Checking The Distance 
		/// </summary>
		/// <param name="_lhs"></param>
		/// <param name="_rhs"></param>
		/// <returns></returns>
		public static float Distance(Vec4 _lhs, Vec4 _rhs)
		{
			return (_lhs - _rhs).Magnitude();
		}

		public static Vec4 operator +(Vec4 _lhs, Vec4 _rhs)
		{
			return new Vec4(_lhs.x + _rhs.x, _lhs.y + _rhs.y, _lhs.z + _rhs.z, _lhs.w + _rhs.w);
		}

		public static Vec4 operator -(Vec4 _lhs, Vec4 _rhs)
		{
			return new Vec4(_lhs.x - _rhs.x, _lhs.y - _rhs.y, _lhs.z - _rhs.z, _lhs.w - _rhs.w);
		}

		public static Vec4 operator *(Vec4 _lhs, float _rhs)
		{
			return new Vec4(_lhs.x * _rhs, _lhs.y * _rhs, _lhs.z * _rhs, _lhs.w * _rhs);
		}

		public static Vec4 operator *(float _lhs, Vec4 _rhs)
		{
			return new Vec4(_lhs * _rhs.x, _lhs * _rhs.y, _lhs * _rhs.z, _lhs * _rhs.w);
		}

		public static Vec4 operator /(Vec4 _lhs, float _rhs)
		{
			return new Vec4(_lhs.x / _rhs, _lhs.y / _rhs, _lhs.z / _rhs, _lhs.w / _rhs);
		}

		public static bool operator ==(Vec4 _lhs, Vec4 _rhs)
		{
			return Azimath.Approximately(_lhs.x, _rhs.x) && Azimath.Approximately(_lhs.y, _rhs.y) && Azimath.Approximately(_lhs.z, _rhs.z)
			       && Azimath.Approximately(_lhs.w, _rhs.w);
		}

		public static bool operator !=(Vec4 _lhs, Vec4 _rhs)
		{
			return !(_lhs == _rhs);
		}

		public static implicit operator Vec4(Vector4 _vector)
		{
			return new Vec4(_vector.X, _vector.Y, _vector.Z, _vector.W);
		}

		public static implicit operator Vector4(Vec4 _vec)
		{
			return new Vector4(_vec.x, _vec.y, _vec.z, _vec.w);
		}

	#endregion
	}
}