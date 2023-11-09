namespace MathLib
{
	public struct Mat4
	{
	#region Static Matrix Builders

		/// <summary>
		/// Crerating The Transform
		/// </summary>
		/// <param name="_position"></param>
		/// <param name="_zRotation"></param>
		/// <param name="_scale"></param>
		/// <param name="_xRotation"></param>
		/// <param name="_yRotation"></param>
		/// <returns></returns>
		public static Mat4 CreateTransform(Vec3 _position, float _zRotation = 0f, Vec3? _scale = null, float _xRotation = 0f, float _yRotation = 0f)
		{
			Vec3 scale = _scale.HasValue ? _scale.Value : Vec3.One;

			Mat4 transMat = CreateTranslation(_position);
			Mat4 scaleMat = CreateScale(scale);

			Mat4 xRotMat = CreateXRotation(_xRotation);
			Mat4 yRotMat = CreateYRotation(_yRotation);
			Mat4 zRotMat = CreateZRotation(_zRotation);

			Mat4 rotMat = xRotMat * yRotMat * zRotMat;

			return transMat * rotMat * scaleMat;
		}

		/// <summary>
		/// Creating the Translation x, y, z
		/// </summary>
		/// <param name="_position"></param>
		/// <returns></returns>
		public static Mat4 CreateTranslation(Vec3 _position)
		{
			return CreateTranslation(_position.x, _position.y, _position.z);
		}

		/// <summary>
		/// creating the Translation Matrix
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <param name="_z"></param>
		/// <returns></returns>
		public static Mat4 CreateTranslation(float _x, float _y, float _z)
		{
			return new Mat4(1, 0, 0, _x,
			                0, 1, 0, _y,
			                0, 0, 1, _z,
			                0, 0, 0, 1);
		}

		/// <summary>
		/// Creating The Scale x, y, z
		/// </summary>
		/// <param name="_scale"></param>
		/// <returns></returns>
		public static Mat4 CreateScale(Vec3 _scale)
		{
			return CreateScale(_scale.x, _scale.y, _scale.z);
		}

		/// <summary>
		/// Creating The Scale Matrix 
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <param name="_z"></param>
		/// <returns></returns>
		public static Mat4 CreateScale(float _x, float _y, float _z)
		{
			return new Mat4(_x, 0, 0, 0,
			                0, _y, 0, 0,
			                0, 0, _z, 0,
			                0, 0, 0, 1);
		}

		/// <summary>
		/// Createing The X Rotation
		/// </summary>
		/// <param name="_rot"></param>
		/// <returns></returns>
		public static Mat4 CreateXRotation(float _rot)
		{
			float cos = MathF.Cos(_rot);
			float sin = MathF.Sin(_rot);

			return new Mat4(1, 0, 0, 0,
			                0, cos, -sin, 0,
			                0, sin, cos, 0,
			                0, 0, 0, 1);
		}

		/// <summary>
		/// Creating The Y Rotation
		/// </summary>
		/// <param name="_rot"></param>
		/// <returns></returns>
		public static Mat4 CreateYRotation(float _rot)
		{
			float cos = MathF.Cos(_rot);
			float sin = MathF.Sin(_rot);

			return new Mat4(cos, 0, sin, 0,
			                0, 1, 0, 0,
			                -sin, 0, cos, 0,
			                0, 0, 0, 1);
		}

		/// <summary>
		/// Createing The Z rotation
		/// </summary>
		/// <param name="_rot"></param>
		/// <returns></returns>
		public static Mat4 CreateZRotation(float _rot)
		{
			float cos = MathF.Cos(_rot);
			float sin = MathF.Sin(_rot);

			return new Mat4(cos, -sin, 0, 0,
			                sin, cos, 0, 0,
			                0, 0, 1, 0,
			                0, 0, 0, 1);
		}

	#endregion

	#region Accessor Properties

		/// <summary>
		/// Getting and setting the Translation
		/// </summary>
		public Vec3 Translation
		{
			get => GetTranslation();
			set => SetTranslation(value.x, value.y, value.z);
		}

		/// <summary>
		/// getting and setting the scale 
		/// </summary>
		public Vec3 Scale
		{
			get => GetScale();
			set => SetScale(value.x, value.y, value.z);
		}

		/// <summary>
		/// getting and setting the rotation X
		/// </summary>
		public float RotationX
		{
			get => GetRotationX();
			set => SetXRotation(value);
		}

		/// <summary>
		/// getting and setting the rotation Y
		/// </summary>
		public float RotationY
		{
			get => GetRotationY();
			set => SetYRotation(value);
		}

		/// <summary>
		/// getting and setting the rotation z
		/// </summary>
		public float RotationZ
		{
			get => GetRotationZ();
			set => SetZRotation(value);
		}

	#endregion

	#region Values

		public float m1, m2, m3, m4, m5, m6, m7, m8, m9, m10, m11, m12, m13, m14, m15, m16;

		public Mat4()
		{
			// 1000
			// 0100
			// 0010
			// 0001

			m1 = 1;
			m2 = 0;
			m3 = 0;
			m4 = 0;
			m5 = 0;
			m6 = 1;
			m7 = 0;
			m8 = 0;
			m9 = 0;
			m10 = 0;
			m11 = 1;
			m12 = 0;
			m13 = 0;
			m14 = 0;
			m15 = 0;
			m16 = 1;
		}

		public Mat4(float _m1, float _m5, float _m9, float _m13,
		            float _m2, float _m6, float _m10, float _m14,
		            float _m3, float _m7, float _m11, float _m15,
		            float _m4, float _m8, float _m12, float _m16)
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
			m10 = _m10;
			m11 = _m11;
			m12 = _m12;
			m13 = _m13;
			m14 = _m14;
			m15 = _m15;
			m16 = _m16;
		}

		public float this[int _row, int _col]
		{
			get
			{
				if(_row == 0 && _col == 0) return m1;
				if(_row == 1 && _col == 0) return m2;
				if(_row == 2 && _col == 0) return m3;
				if(_row == 3 && _col == 0) return m4;
				if(_row == 0 && _col == 1) return m5;
				if(_row == 1 && _col == 1) return m6;
				if(_row == 2 && _col == 1) return m7;
				if(_row == 3 && _col == 1) return m8;
				if(_row == 0 && _col == 2) return m9;
				if(_row == 1 && _col == 2) return m10;
				if(_row == 2 && _col == 2) return m11;
				if(_row == 3 && _col == 2) return m12;
				if(_row == 0 && _col == 3) return m13;
				if(_row == 1 && _col == 3) return m14;
				if(_row == 2 && _col == 3) return m15;
				if(_row == 3 && _col == 3) return m16;

				throw new IndexOutOfRangeException("Mat4 only has 4 columns and 4 rows");
			}
		}

		/// <summary>
		/// Transform The Point
		/// </summary>
		/// <param name="_point"></param>
		/// <returns></returns>
		public Vec3 TransFormPoint(Vec3 _point)
		{
			return new Vec3(_point.x * m1 + _point.y * m5 + _point.z * m9 + m13,
			                _point.x * m2 + _point.y * m6 + _point.z * m10 + m14,
			                _point.x * m3 + _point.y * m7 + _point.z * m11 + m15);
		}

		/// <summary>
		/// Transform The Vector 
		/// </summary>
		/// <param name="_vec"></param>
		/// <returns></returns>
		public Vec3 TransformVector(Vec3 _vec)
		{
			return new Vec3(_vec.x * m1 + _vec.y * m5 + _vec.z * m9,
			                _vec.x * m2 + _vec.y * m6 + _vec.z * m10,
			                _vec.x * m3 + _vec.y * m7 + _vec.z * m11);
		}

	#endregion

	#region Value Getters

		/// <summary>
		/// Getting The Translation
		/// </summary>
		/// <returns></returns>
		public Vec3 GetTranslation()
		{
			return new Vec3(m13, m14, m15);
		}

		/// <summary>
		/// Getting The Scale
		/// </summary>
		/// <returns></returns>
		public Vec3 GetScale()
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3 + m4 * m4);
			float yALength = MathF.Sqrt(m5 * m5 + m6 * m6 + m7 * m7 + m8 * m8);
			float zALength = MathF.Sqrt(m9 * m9 + m10 * m10 + m11 * m11 + m12 * m12);

			return new Vec3(xALength, yALength, zALength);
		}

		/// <summary>
		/// Getting The X Rotation
		/// </summary>
		/// <returns></returns>
		public float GetRotationX()
		{
			return MathF.Atan2(m2, m1);
		}

		/// <summary>
		/// Getting The Y Rotation
		/// </summary>
		/// <returns></returns>
		public float GetRotationY()
		{
			return MathF.Atan2(-m5, m6);
		}

		/// <summary>
		/// Getting The Z Rotation
		/// </summary>
		/// <returns></returns>
		public float GetRotationZ()
		{
			return MathF.Atan2(m9, m11);
		}

	#endregion

	#region Value Setters

		/// <summary>
		/// Setting The Translation
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <param name="_z"></param>
		public void SetTranslation(float _x, float _y, float _z)
		{
			m13 = _x;
			m14 = _y;
			m15 = _z;
		}

		/// <summary>
		///  Translating
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <param name="_z"></param>
		public void Translate(float _x, float _y, float _z)
		{
			m13 += _x;
			m14 += _y;
			m15 += _z;
		}

		/// <summary>
		/// Setting The Scale
		/// </summary>
		/// <param name="_x"></param>
		/// <param name="_y"></param>
		/// <param name="_z"></param>
		public void SetScale(float _x, float _y, float _z)
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3 + m4 * m4);
			float yALength = MathF.Sqrt(m5 * m5 + m6 * m6 + m7 * m7 + m8 * m8);
			float zALength = MathF.Sqrt(m9 * m9 + m10 * m10 + m11 * m11 + m12 * m12);

			if(xALength > 0 && _x != 0)
			{
				m1 = m1 / xALength * _x;
				m2 = m2 / xALength * _x;
				m3 = m3 / xALength * _x;
				m4 = m4 / xALength * _x;
			}

			if(yALength > 0 && _y != 0)
			{
				m5 = m5 / yALength * _y;
				m6 = m6 / yALength * _y;
				m7 = m7 / yALength * _y;
				m8 = m8 / yALength * _y;
			}

			if(zALength > 0 && _z != 0)
			{
				m9 = m9 / zALength * _z;
				m10 = m10 / zALength * _z;
				m11 = m11 / zALength * _z;
				m12 = m12 / zALength * _z;
			}
		}

		/// <summary>
		/// Setting The X Rotation
		/// </summary>
		/// <param name="_xRot"></param>
		public void SetXRotation(float _xRot)
		{
			float yALength = MathF.Sqrt(m5 * m5 + m6 * m6 + m7 * m7);
			float zALength = MathF.Sqrt(m9 * m9 + m10 * m10 + m11 * m11);

			float cos = MathF.Cos(_xRot);
			float sin = MathF.Sin(_xRot);

			m6 = cos * yALength;
			m10 = -sin * zALength;
			m7 = sin * yALength;
			m11 = cos * zALength;
		}

		/// <summary>
		/// Setting The Y Rotation
		/// </summary>
		/// <param name="_yRot"></param>
		public void SetYRotation(float _yRot)
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3);
			float zALength = MathF.Sqrt(m9 * m9 + m10 * m10 + m11 * m11);

			float cos = MathF.Cos(_yRot);
			float sin = MathF.Sin(_yRot);

			m1 = cos * zALength;
			m9 = sin * zALength;
			m3 = -sin * xALength;
			m11 = cos * zALength;
		}

		/// <summary>
		/// Setting The Z Rotation
		/// </summary>
		/// <param name="_zRot"></param>
		public void SetZRotation(float _zRot)
		{
			float xALength = MathF.Sqrt(m1 * m1 + m2 * m2 + m3 * m3);
			float yALength = MathF.Sqrt(m5 * m5 + m6 * m6 + m7 * m7);

			float cos = MathF.Cos(_zRot);
			float sin = MathF.Sin(_zRot);

			m1 = cos * xALength;
			m5 = -sin * yALength;
			m2 = sin * xALength;
			m6 = cos * yALength;
		}

	#endregion

	#region Operators

		public static Mat4 operator *(Mat4 _a, Mat4 _b)
		{
			return new Mat4(
			                _a.m1 * _b.m1 + _a.m2 * _b.m5 + _a.m3 * _b.m9 + _a.m4 * _b.m13, // m1 
			                _a.m5 * _b.m1 + _a.m6 * _b.m5 + _a.m7 * _b.m9 + _a.m8 * _b.m13, // m5
			                _a.m9 * _b.m1 + _a.m10 * _b.m5 + _a.m11 * _b.m9 + _a.m12 * _b.m13, //m9
			                _a.m13 * _b.m1 + _a.m14 * _b.m5 + _a.m15 * _b.m9 + _a.m16 * _b.m13, //m13
			                _a.m1 * _b.m2 + _a.m2 * _b.m6 + _a.m3 * _b.m10 + _a.m4 * _b.m14, //m2
			                _a.m5 * _b.m2 + _a.m6 * _b.m6 + _a.m7 * _b.m10 + _a.m8 * _b.m14, //m6 
			                _a.m9 * _b.m2 + _a.m10 * _b.m6 + _a.m11 * _b.m10 + _a.m12 * _b.m14, //m10
			                _a.m13 * _b.m2 + _a.m14 * _b.m6 + _a.m15 * _b.m10 + _a.m16 * _b.m14, //m14
			                _a.m1 * _b.m3 + _a.m2 * _b.m7 + _a.m3 * _b.m11 + _a.m4 * _b.m15, //m3
			                _a.m5 * _b.m3 + _a.m6 * _b.m7 + _a.m7 * _b.m11 + _a.m8 * _b.m15, //m7
			                _a.m9 * _b.m3 + _a.m10 * _b.m7 + _a.m11 * _b.m11 + _a.m12 * _b.m15, //m11
			                _a.m13 * _b.m3 + _a.m14 * _b.m7 + _a.m15 * _b.m11 + _a.m16 * _b.m15, //m15
			                _a.m1 * _b.m4 + _a.m2 * _b.m8 + _a.m3 * _b.m12 + _a.m4 * _b.m16, //m3
			                _a.m5 * _b.m4 + _a.m6 * _b.m8 + _a.m7 * _b.m12 + _a.m8 * _b.m16, //m8
			                _a.m9 * _b.m4 + _a.m10 * _b.m8 + _a.m11 * _b.m12 + _a.m12 * _b.m16, //m12
			                _a.m13 * _b.m4 + _a.m14 * _b.m8 + _a.m15 * _b.m12 + _a.m16 * _b.m16 //m16
			               );
		}

		public static Vec4 operator *(Mat4 _lhs, Vec4 _rhs)
		{
			return new Vec4(_lhs.m1 * _rhs.x + _lhs.m5 * _rhs.y + _lhs.m9 * _rhs.z + _lhs.m13 * _rhs.w,
			                _lhs.m2 * _rhs.x + _lhs.m6 * _rhs.y + _lhs.m10 * _rhs.z + _lhs.m14 * _rhs.w,
			                _lhs.m3 * _rhs.x + _lhs.m7 * _rhs.y + _lhs.m11 * _rhs.z + _lhs.m15 * _rhs.w,
			                _lhs.m4 * _rhs.x + _lhs.m7 * _rhs.y + _lhs.m12 * _rhs.z + _lhs.m16 * _rhs.w);
		}

	#endregion
	}
}