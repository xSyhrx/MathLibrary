using Raylib_cs;

namespace MathLib
{
	public struct Colour
	{
		public static Colour White = 0xffffffff;
		public static Colour Red = 0x00ffffff;
		public static Colour Green = 0xff00ffff;
		public static Colour Blue = 0xffff00ff;
		public static Colour Alpha = 0xffffff00;

	#region colours

		// Green Blue Alpha = byte = 0x00
		public UInt32 colour = 0xffffffff;

		public Colour(byte _red, byte _green, byte _blue, byte _alpha)
		{
			SetRed(_red);
			SetGreen(_green);
			SetBlue(_blue);
			SetAlpha(_alpha);
		}

		public Colour(UInt32 _color)
		{
			colour = _color;
		}

		/// <summary>
		/// Getting The Red
		/// </summary>
		/// <returns></returns>
		public byte GetRed()
		{
			return (byte) ((colour >> 24) & 0xff);
		}

		/// <summary>
		/// Setting The Red 
		/// </summary>
		/// <param name="_red"></param>
		public void SetRed(byte _red)
		{
			colour = (colour & 0x00ffffff) | ((uint) _red << 24);
		}

		/// <summary>
		/// Getting The Green
		/// </summary>
		/// <returns></returns>
		public byte GetGreen()
		{
			return (byte) ((colour >> 16) & 0xff);
		}

		/// <summary>
		/// Setting The Green
		/// </summary>
		/// <param name="_green"></param>
		public void SetGreen(byte _green)
		{
			colour = (colour & 0xff00ffff) | ((uint) _green << 16);
		}

		/// <summary>
		/// Getting The Blue 
		/// </summary>
		/// <returns></returns>
		public byte GetBlue()
		{
			return (byte) ((colour >> 8) & 0xff);
		}

		/// <summary>
		/// Setting The Blue 
		/// </summary>
		/// <param name="_blue"></param>
		public void SetBlue(byte _blue)
		{
			colour = (colour & 0xffff00ff) | ((uint) _blue << 8);
		}

		/// <summary>
		/// Getting The Alpha 
		/// </summary>
		/// <returns></returns>
		public byte GetAlpha()
		{
			return (byte) ((colour >> 0) & 0xff);
		}

		/// <summary>
		/// Setting The Alpha 
		/// </summary>
		/// <param name="_alpha"></param>
		public void SetAlpha(byte _alpha)
		{
			colour = (colour & 0xffffff00) | ((uint) _alpha << 0);
		}

	#endregion


	#region Accesor Properties

		public byte R
		{
			get => GetRed();
			set => SetRed(value);
		}

		public byte G
		{
			get => GetGreen();
			set => SetGreen(value);
		}

		public byte B
		{
			get => GetBlue();
			set => SetBlue(value);
		}

		public byte A
		{
			get => GetAlpha();
			set => SetAlpha(value);
		}

	#endregion

	#region Operator Overloads

		public static implicit operator Colour(UInt32 _colour) => new Colour(_colour);

		public static implicit operator Color(Colour _color) => new Color(_color.GetRed(), _color.GetGreen(), _color.GetBlue(), _color.GetAlpha());

	#endregion
	}
}