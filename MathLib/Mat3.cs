using System.Data.SqlTypes;

namespace MathLib
{
	public struct Mat3
	{
	#region Static Matrix Builders

		/// <summary>Create The Transform</summary>
		/// <param name="_position"></param>
		/// <param name="_zRotation"></param>
		/// <param name="_scale"></param>
		/// <param name="_xRotation"></param>
		/// <param name="_yRotation"></param>
		/// <returns></returns>
		public static Mat3 CreateTransform(Vec2 _position, float _zRotation = 0f, Vec2? _scale = null, float _xRotation = 0f, float _yRotation = 0f)
		{
			Vec2 scale = _scale.HasValue ? _scale.Value : Vec2.one;

			Mat3 transMat = CreateTranslation(_position);
			Mat3 scaleMat = CreateScale(scale);

			Mat3 xRotMat = CreateXRotation(_xRotation);
			Mat3 yRotMat = CreateYRotation(_yRotation);
			Mat3 zRotMat = CreateZRotation(_zRotation);
			Mat3 rotMat = xRotMat * yRotMat * zRotMat;

			return transMat * rotMat * scaleMat;
		}

		/// <summary> Create The Translation</summary>
		/// <param name="_position"></param>
		/// <returns></returns>
		public static Mat3 CreateTranslation(Vec2 _position)
		{
			return CreateTranslation(_position.x, _position.y);
		}

		/// <summary>
		/// Creating the Translation 
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <returns></returns>
		public static Mat3 CreateTranslation(float _x, float _y)
		{
			return new Mat3(1, 0, _x,
			                0, 1, _y,
			                0, 0, 1);
		}

		/// <summary> Create The Scale </summary>
		/// <param name="_Scale"></param>
		/// <returns></returns>
		public static Mat3 CreateScale(Vec2 _Scale)
		{
			return CreateScale(_Scale.x, _Scale.y);
		}

		/// <summary>
		/// Creating The Scale
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <returns></returns>
		public static Mat3 CreateScale(float _x, float _y)
		{
			return new Mat3(_x, 0, 0,
			                0, _y, 0,
			                0, 0, 1);
		}

		/// <summary>Create The X Rotation</summary>
		/// <param name="_rot"></param>
		/// <returns></returns>
		public static Mat3 CreateXRotation(float _rot)
		{
			float cos = MathF.Cos(_rot);
			float sin = MathF.Sin(_rot);

			return new Mat3(1, 0, 0,
			                0, cos, -sin,
			                0, sin, cos);
		}

		/// <summary> Create The Y Rotation</summary>
		/// <param name="_rot"></param>
		/// <returns></returns>
		public static Mat3 CreateYRotation(float _rot)
		{
			float cos = MathF.Cos(_rot);
			float sin = MathF.Sin(_rot);

			return new Mat3(cos, 0, sin,
			                0, 1, 0,
			                -sin, 0, cos);
		}

		/// <summary> Create The Z Rotation</summary>
		/// <param name="_rot"></param>
		/// <returns></returns>
		public static Mat3 CreateZRotation(float _rot)
		{
			float cos = MathF.Cos(_rot);
			float sin = MathF.Sin(_rot);

			return new Mat3(cos, -sin, 0,
			                sin, cos, 0,
			                0, 0, 1);
		}

	#endregion

	#region Accessor Properties

		/// <summary>
		/// Getting and setting the translation 
		/// </summary>
		public Vec2 Translation
		{
			get => GetTranslation();
			set => SetTranslation(value.x, value.y);
		}

		/// <summary>
		/// getting and setting the scale 
		/// </summary>
		public Vec2 Scale
		{
			get => GetScale();
			set => SetScale(value.x, value.y);
		}

		/// <summary>
		/// getting and setting the rotation X
		/// </summary>
		public float RotationX
		{
			get => GetRotationX();
			set => SetXrotation(value);
		}

		/// <summary>
		/// Getting and setting the rotation Y
		/// </summary>
		public float RotationY
		{
			get => GetRotationY();
			set => SetYRotation(value);
		}

		/// <summary>
		/// getting and setting the rotation Z
		/// </summary>
		public float RotationZ
		{
			get => GetRotationZ();
			set => SetZRotation(value);
		}

	#endregion

		public float m1, m2, m3, m4, m5, m6, m7, m8, m9;

		public Mat3()
		{
			// 100
			// 010
			// 001

			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 1;
			m6 = 0;
			m7 = 0;
			m8 = 0;
			m9 = 1;
		}

		public Mat3(float _m1, float _m4, float _m7, float _m2, float _m5, float _m8, float _m3, float _m6, float _m9)
		{
			m1 = _m1;
			m2 = _m2;
			m3 = _m3;
			m4 = _m4;
			m5 = _m5;
			m6 = _m6;
			m7 = _m7;
			m8 = _m8;
			m9 = _m9;
		}

		public float this[int _row, int _col]
		{
			get
			{
				if(_row == 0 && _col == 0) return m1;
				if(_row == 1 && _col == 0) return m2;
				if(_row == 2 && _col == 0) return m3;
				if(_row == 0 && _col == 1) return m4;
				if(_row == 1 && _col == 1) return m5;
				if(_row == 2 && _col == 1) return m6;
				if(_row == 0 && _col == 2) return m7;
				if(_row == 1 && _col == 2) return m8;
				if(_row == 2 && _col == 2) return m9;

				throw new IndexOutOfRangeException("Mat3 only has 3 colums and 3 rows");
			}
		}

		/// <summary> Transform The Point</summary>
		/// <param name="_point"></param>
		/// <returns></returns>
		public Vec2 TransFormPoint(Vec2 _point)
		{
			return new Vec2(_point.x * m1 + _point.y * m4 + m7,
			                _point.x * m2 + _point.y * m5 + m8);
		}

		/// <summary> Transform The Vector</summary>
		/// <param name="_vec"></param>
		/// <returns></returns>
		public Vec2 TransformVector(Vec2 _vec)
		{
			return new Vec2(_vec.x * m1 + _vec.y * m4,
			                _vec.x * m2 + _vec.y * m5);
		}

	#region Value Getters

		/// <summary> Get the Translation</summary>
		/// <returns></returns>
		public Vec2 GetTranslation()
		{
			return new Vec2(m7, m8);
		}

		/// <summary> Get the Scale</summary>
		/// <returns></returns>
		public Vec2 GetScale()
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3);
			float yALength = MathF.Sqrt(m4 * m4 + m5 * m5 + m6 * m6);

			return new Vec2(xALength, yALength);
		}

		/// <summary> Get The X Rotation</summary>
		/// <returns></returns>
		public float GetRotationX()
		{
			return MathF.Atan2(m2, m1);
		}

		/// <summary> Get the Y Rotation</summary>
		/// <returns></returns>
		public float GetRotationY()
		{
			return MathF.Atan2(-m4, m5);
		}

		/// <summary> Get The Z Rotation</summary>
		/// <returns></returns>
		public float GetRotationZ()
		{
			return MathF.Atan2(m7, m9);
		}

	#endregion

	#region Value Setters

		/// <summary>Setting The Translation</summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		public void SetTranslation(float _x, float _y)
		{
			m7 = _x;
			m8 = _y;
		}

		/// <summary>Translating</summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		public void Translate(float _x, float _y)
		{
			m7 += _x;
			m8 += _y;
		}

		/// <summary> Setting The Scale</summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		public void SetScale(float _x, float _y)
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3);
			float yALength = MathF.Sqrt(m4 * m4 + m5 * m5 + m6 * m6);

			if(xALength > 0 && _x != 0)
			{
				m1 = m1 / xALength * _x;
				m2 = m2 / xALength * _x;
				m3 = m3 / xALength * _x;
			}

			if(yALength > 0 && _y != 0)
			{
				m4 = m4 / yALength * _y;
				m5 = m5 / yALength * _y;
				m6 = m6 / yALength * _y;
			}
		}

		/// <summary> Setting The X Rotation</summary>
		/// <param name="_xRot"></param>
		public void SetXrotation(float _xRot)
		{
			float yALength = MathF.Sqrt(m4 * m4 + m5 * m5 + m6 * m6);
			float zALength = MathF.Sqrt(m7 * m7 + m8 * m8 + m9 * m9);

			float cos = MathF.Cos(_xRot);
			float sin = MathF.Sin(_xRot);

			m5 = cos * yALength;
			m8 = -sin * zALength;
			m6 = sin * yALength;
			m9 = cos * zALength;
		}

		/// <summary> Setting The Y Rotation</summary>
		/// <param name="_yRot"></param>
		public void SetYRotation(float _yRot)
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3);
			float zALength = MathF.Sqrt(m7 * m7 + m8 * m8 + m9 * m9);

			float cos = MathF.Cos(_yRot);
			float sin = MathF.Sin(_yRot);

			m1 = cos * zALength;
			m7 = sin * zALength;
			m3 = -sin * xALength;
			m9 = cos * zALength;
		}

		/// <summary> Setting The Z Rotation</summary>
		/// <param name="_zRot"></param>
		public void SetZRotation(float _zRot)
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3);
			float yALength = MathF.Sqrt(m4 * m4 + m5 * m5 + m6 * m6);

			float cos = MathF.Cos(_zRot);
			float sin = MathF.Sin(_zRot);

			m1 = cos * xALength;
			m4 = -sin * yALength;
			m2 = sin * xALength;
			m5 = cos * yALength;
		}

	#endregion

	#region Operators

		public static Mat3 operator *(Mat3 _a, Mat3 _b)
		{
			return new Mat3(
			                _a.m1 * _b.m1 + _a.m2 * _b.m4 + _a.m3 * _b.m7, // m1
			                _a.m4 * _b.m1 + _a.m5 * _b.m4 + _a.m6 * _b.m7, // m4
			                _a.m7 * _b.m1 + _a.m8 * _b.m4 + _a.m9 * _b.m7, // m7
			                _a.m1 * _b.m2 + _a.m2 * _b.m5 + _a.m3 * _b.m8, // m2
			                _a.m4 * _b.m2 + _a.m5 * _b.m5 + _a.m6 * _b.m8, // m5
			                _a.m7 * _b.m2 + _a.m8 * _b.m5 + _a.m9 * _b.m8, // m8
			                _a.m1 * _b.m3 + _a.m2 * _b.m6 + _a.m3 * _b.m9, // m3
			                _a.m4 * _b.m3 + _a.m5 * _b.m6 + _a.m6 * _b.m9, // m6
			                _a.m7 * _b.m3 + _a.m8 * _b.m6 + _a.m9 * _b.m9 // m9
			               );
		}

		public static Vec3 operator *(Mat3 _lhs, Vec3 _rhs)
		{
			return new Vec3(_lhs.m1 * _rhs.x + _lhs.m4 * _rhs.y + _lhs.m7 * _rhs.z,
			                _lhs.m2 * _rhs.x + _lhs.m5 * _rhs.y + _lhs.m8 * _rhs.z,
			                _lhs.m3 * _rhs.x + _lhs.m6 * _rhs.y + _lhs.m9 * _rhs.z);
		}

	#endregion
	}
}