using MathLib;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Numerics;

namespace MathLibTests
{
	[TestClass]
	public class Vec3Tests : MathLibTestBase
	{
		[TestMethod]
		public void Vector3Constructor()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			
			//Assert.Fail("Vector3Constructor Test not implemented");
		}

		[TestMethod]
		public void Vector3Addition()
		{

			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3Addition Test not implemented");
		}
		
		[TestMethod]
		public void Vector3Subtraction()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3Subtraction Test not implemented");
		}

		[TestMethod]
		public void Vector3PostScale()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3PostScale Test not implemented");
		}
		
		[TestMethod]
		public void Vector3PreScale()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector4PostScale Test not implemented");
		}
		
		[TestMethod]
		public void Vector3Dot()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3Dot Test not implemented");
		}

		[TestMethod]
		public void Vector3Cross()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3Cross Test not implemented");
		}
		
		[TestMethod]
		public void Vector3Magnitude()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3Magnitude Test not implemented");
		}
		
		[TestMethod]
		public void Vector3Normalise()
		{
			Vector3 expected = new Vector3(1, 1, 1);
			Vec3 actual = new Vec3(expected.X, expected.Y, expected.Z);
			
			Assert.IsTrue(Compare(actual.x, expected.X) && Compare(actual.y, expected.Y)
			                                            && Compare(actual.z, expected.Z));
			//Assert.Fail("Vector3Normalise Test not implemented");
		}
	}
}