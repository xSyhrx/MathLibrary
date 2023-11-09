using System.ComponentModel.DataAnnotations;
namespace MathLib
{
	/// <summary> A collection of useful constants and mathematical functions.</summary>
	public class Azimath
	{
		/// <summary>Degrees-to-radians conversation. multiply a degree angle by this to get the radians equivalent.</summary>
		public const float DEG_2_RAD = MathF.PI * 2f / 360f;
		/// <summary>Degrees-to-radians conversation. multiply a radian angle by this to get the degrees equivalent.</summary>
		public const float RAD_2_DEG = 1f / DEG_2_RAD;
		
		/// <summary> Returns the smaller of the two passed values</summary>
		public static float Min(float _a, float _b) => _a < _b ? _a : _b;

		/// <summary> Returns the larger of the two passed values</summary>
		public static float Max(float _a, float _b) => _a > _b ? _a : _b;

		/// <summary>Rouds a value to the nearest whole number, if it is exacly at 0.5, it will round up</summary>
		/// <param name="_value"> The value we want to actually round</param>
		
		public static float Round(float _value)
		{
			return MathF.Round(_value, MidpointRounding.AwayFromZero);
		}
		
		/// <summary>Ensures a value stays within the specified range.</summary>
		/// <example> 5 within 0 - 10 return 5.  19 within 0 - 10 retuns 10 </example>
		/// <param name="_value"> the number we are clamping</param>
		/// <param name="_min"> the minimum possible value for <paramref name = "_value"/>.</param>
		/// <param name="_max"> the maximum possible value for <paramref name = "_value"/>.</param>
		public static float Clamp(float _value, float _min, float _max)
		{
			if(_value < _min)
				_value = _min;

			if(_value > _max)
				_value = _max;

			return _value;
		}
		
		/// <summary>
		/// Emsures the passed valu remains within the range 0 - 1.</summary>
		/// <param name="_value"> The number we are calmping</param>
		public static float Clamp01(float _value)
		{
			return Clamp(_value, 0f, 1f);
		}
		public static float Lerp(float _a, float _b, float _t)
		{
			_t = Clamp01(_t);

			return _a * (1 - _t) + _b * _t;
		}

		public static int Lerp(int _a, int _b, float _t)
		{
			_t = Clamp01(_t);

			return (int) (_a * (1 - _t) + _b * _t);
		}
		
		/// <summary>checks if two floats are almost or exaclty the same value</summary>
		public static bool Approximately(float _a, float _b)
		{
			return MathF.Abs(_b - _a) < MathF.Max(0.000001f * MathF.Max(MathF.Abs(_a), MathF.Abs(_b)), float.Epsilon * 8f);
		}
		
		/// <summary>takes a value from one range and changes it to fit another</summary>
		/// <example>0.5 starts in 0 - 1 | Remaps to 0 in the range -1 - 1.</example>
		/// <param name="_value"> The number we are remapping</param>
		/// <param name="_oldMin"> the minimum value of the old range</param>
		/// <param name="_oldMax"> the maximum value of the old range</param>
		/// <param name="_newMin"> the minimum value of the new range</param>
		/// <param name="_newMax"> the maximum value of the new range</param>
		public static float Remap(float _value, float _oldMin, float _oldMax, float _newMin, float _newMax)
		{
			return (_value - _oldMin) / (_oldMax - _oldMin) * (_newMax - _newMin) + _newMin;
		}
		
	}
}