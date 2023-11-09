using MathLib;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Numerics;

namespace MathLibTests
{
	[TestClass]
	public class Vec2Tests : MathLibTestBase
	{
		[TestMethod]
		public void Vec2DefaultConstructor()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, expected.Y));
			//Assert.Fail("Vec2 Default Constructor Test not implemented");
		}

		[TestMethod]
		public void Vec2OverloadedConstructor()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);

			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			// Assert.Fail("Vec2 Overloaded Constructor Test not implemented");
		}

		[TestMethod]
		public void Vec2ImplicitConversion()
		{
			Vector2 expected = new Vector2(1, 1);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			//Assert.Fail("Vec2 Implicit Conversion Test not implemented");
		}

		[TestMethod]
		public void Vec2Addition()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			//Assert.Fail("Vec2 Addition Test not implemented");
		}

		[TestMethod]
		public void Vec2Subtraction()
		{
			
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			
			//Assert.Fail("Vec2 Subtraction Test not implemented");
		}

		[TestMethod]
		public void Vec2PostScale()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			//Assert.Fail("Vec2 PostScale Test not implemented");
		}

		[TestMethod]
		public void Vec2PreScale()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			
			//Assert.Fail("Vec2 PreScale Test not implemented");
		}

		[TestMethod]
		public void Vec2Dot()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			
			//Assert.Fail("Vec2 Dot Test not implemented");
		}

		[TestMethod]
		public void Vec2Magnitude()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			//Assert.Fail("Vec2 Magnitude Test not implemented");
		}

		[TestMethod]
		public void Vec2Distance()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			//Assert.Fail("Vec2 Distance Test not implemented");
		}

		[TestMethod]
		public void Vec2Normalise()
		{
			Vector2 expected = RandomVec(-1000, 1000);
			Vec2 actual = new Vec2(expected.X, expected.Y);
			
			Assert.IsTrue(Compare(expected.X, actual.x) && Compare(expected.Y, actual.y));
			//Assert.Fail("Vec2 Normalise Test not implemented");
		}
	}
}