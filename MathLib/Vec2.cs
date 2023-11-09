using Newtonsoft.Json;

using System.Numerics;
using System.Text.Json.Serialization;

namespace MathLib
{
	[JsonObject(MemberSerialization.OptIn)]
	public struct Vec2
	{
	#region Global constant vectors

		public static Vec2 zero = new();
		public static Vec2 one = new(1, 1);
		public static Vec2 half = new(0.5f, 0.5f);
		public static Vec2 up = new(0, -1);
		public static Vec2 down = new(0, 1);
		public static Vec2 right = new(1, 0);
		public static Vec2 left = new(-1, 0);

	#endregion

		/// <summary>
		/// Normalizing the magnitude
		/// </summary>
		public Vec2 Normalized => this / Magnitude();

		/// <summary>
		/// Rotating the x, y
		/// </summary>
		public float Rotation => MathF.Atan2(y, x);

		[JsonProperty] public float x;
		[JsonProperty] public float y;

		public Vec2(float _x, float _y)
		{
			x = _x;
			y = _y;
		}

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
			}
			else
			{
				x /= mag;
				y /= mag;
			}
		}

		/// <summary>
		/// The Magnitude 
		/// </summary>
		/// <returns></returns>
		public float Magnitude()
		{
			return MathF.Sqrt(SqrMagnitude());
		}

		/// <summary>
		///  The Sqr Magnitude 
		/// </summary>
		/// <returns></returns>
		public float SqrMagnitude()
		{
			return x * x + y * y;
		}

		/// <summary>
		/// The Rotation
		/// </summary>
		/// <param name="_amount"></param>
		public void Rotate(float _amount)
		{
			float xRotated = x * MathF.Cos(_amount) - y * MathF.Sin(_amount);
			float yRotated = x * MathF.Sin(_amount) + y * MathF.Cos(_amount);

			x = xRotated;
			y = yRotated;
		}

		/// <summary>
		/// Rotating Around
		/// </summary>
		/// <param name="_piviotPoint"></param>
		/// <param name="_amount"></param>
		public void RotateAround(Vec2 _piviotPoint, float _amount)
		{
			x -= _piviotPoint.x;
			y -= _piviotPoint.y;

			Rotate(_amount);

			x += _piviotPoint.x;
			y += _piviotPoint.y;
		}

		/// <summary>
		/// Convert To String
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"({x}, {y})";

		/// <summary>
		/// Getting The Hash Code
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode() => HashCode.Combine(x.GetHashCode(), y.GetHashCode());

		public override bool Equals(object? _obj)
		{
			if(_obj == null)
				return false;

			return (Vec2) _obj == this;
		}

	#region Operators

		/// <summary>
		/// Linear interpolation
		/// </summary>
		/// <param name="_a"></param>
		/// <param name="_b"></param>
		/// <param name="_t"></param>
		/// <returns></returns>
		public static Vec2 Lerp(Vec2 _a, Vec2 _b, float _t)
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
		public static float Dot(Vec2 _lhs, Vec2 _rhs)
		{
			return _lhs.x * _rhs.x + _lhs.y * _rhs.y;
		}

		/// <summary>
		/// Creating The Rotation Vector
		/// </summary>
		/// <param name="_radians"></param>
		/// <returns></returns>
		public static Vec2 CreateRotationVector(float _radians)
		{
			return new Vec2(MathF.Cos(_radians), MathF.Sin(_radians));
		}

		/// <summary>
		/// Checking The Distance 
		/// </summary>
		/// <param name="_lhs"></param>
		/// <param name="_rhs"></param>
		/// <returns></returns>
		public static float Distance(Vec2 _lhs, Vec2 _rhs)
		{
			return (_lhs - _rhs).Magnitude();
		}

		public static Vec2 operator +(Vec2 _lhs, Vec2 _rhs)
		{
			return new Vec2(_lhs.x + _rhs.x, _lhs.y + _rhs.y);
		}

		public static Vec2 operator -(Vec2 _lhs, Vec2 _rhs)
		{
			return new Vec2(_lhs.x - _rhs.x, _lhs.y - _rhs.y);
		}

		public static Vec2 operator *(Vec2 _lhs, float _rhs)
		{
			return new Vec2(_lhs.x * _rhs, _lhs.y * _rhs);
		}

		public static Vec2 operator *(float _lhs, Vec2 _rhs)
		{
			return new Vec2(_lhs * _rhs.x, _lhs * _rhs.y);
		}

		public static Vec2 operator /(Vec2 _lhs, float _rhs)
		{
			return new Vec2(_lhs.x / _rhs, _lhs.y / _rhs);
		}

		public static bool operator ==(Vec2 _lhs, Vec2 _rhs)
		{
			return Azimath.Approximately(_lhs.x, _rhs.x) && Azimath.Approximately(_lhs.y, _rhs.y);
		}

		public static bool operator !=(Vec2 _lhs, Vec2 _rhs)
		{
			return !(_lhs == _rhs);
		}

		public static implicit operator Vec2(Vector2 _vector)
		{
			return new Vec2(_vector.X, _vector.Y);
		}

		public static implicit operator Vector2(Vec2 _vec)
		{
			return new Vector2(_vec.x, _vec.y);
		}

	#endregion
	}
}