using MathLib;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Numerics;

namespace MathLibTests
{
	[TestClass]
	public class Vec4Test : MathLibTestBase
	{
		[TestMethod]
		public void Vec4Constructor()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4Constructor Test not implemented");
		}

		[TestMethod]
		public void Vec4Addition()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4Addition Test not implemented");
		}

		[TestMethod]
		public void Vec4Subtraction()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4Subtraction Test not implemented");
		}

		[TestMethod]
		public void Vec4PostScale()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4PostScale Test not implemented");
		}

		[TestMethod]
		public void Vec4PreScale()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4PreScale Test not implemented");
		}

		[TestMethod]
		public void Vec4Dot()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4Dot Test not implemented");
		}

		[TestMethod]
		public void Vec4Magnitude()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vec4Magnitude Test not implemented");
		}

		[TestMethod]
		public void Vec4Normalise()
		{
			Vector4 expected = new Vector4(1, 1, 1, 1);
			Vec4 actual = new Vec4(expected.X, expected.Y, expected.Z, expected.W);
			
			Assert.IsTrue(Compare(actual.x, expected.X)
			              && Compare(actual.y, expected.Y)
			              && Compare(actual.z, expected.Z) 
			              && Compare(actual.w, expected.W));
			
			//Assert.Fail("Vector3Normalise Test not implemented");
		}
	}
}