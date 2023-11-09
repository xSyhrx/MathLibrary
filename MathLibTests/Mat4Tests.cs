using MathLib;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using System.Runtime.InteropServices;

namespace MathLibTests
{
	[TestClass]
	public class Mat4Tests : MathLibTestBase
	{
		[TestMethod]
		public void Mat4SetRotateX()
		{
			Mat4 expected = new Mat4(1, 0, 0, 0,
			                         0, 0.34202f, -0.939693f, 0,
			                         0, 0.939693f, 0.34202f, 0,
			                         0, 0, 0, 1);
			Mat4 test = new Mat4();
			test.SetXRotation(70 * Azimath.DEG_2_RAD);
			
			Assert.IsTrue(Compare(expected, test));
			//Assert.Fail("Mat4SetRotateX Test not implemented");
		}

		[TestMethod]
		public void Mat4SetRotateY()
		{
			Mat4 expected = new Mat4(0.34202f, 0, 0.939693f, 0,
			                     0, 1, 0, 0,
			                     -0.939693f, 0, 0.34202f, 0,
			                     0, 0, 0, 1);

			Mat4 test = new Mat4();
			test.SetYRotation(70 * Azimath.DEG_2_RAD);

			Assert.IsTrue(Compare(test, expected));
			//Assert.Fail("Mat4SetRotateY Test not implemented");
		}

		[TestMethod]
		public void Mat4SetRotateZ()
		{
			Mat4 expected = new Mat4(0.34202f, -0.939693f, 0, 0,
			                         0.939693f, 0.34202f, 0, 0,
			                         0, 0 , 1, 0,
			                         0 ,0 ,0 ,1);

			Mat4 test = new Mat4();
			test.SetZRotation(70 * Azimath.DEG_2_RAD);

			Assert.IsTrue(Compare(test, expected));
			//Assert.Fail("Mat4SetRotateZ Test not implemented");
		}

		[TestMethod]
		public void Vec4MatrixTransform()
		{
			Vec4 test = new Vec4(3, 4, 3, 4);
			Mat4 multiplier = Mat4.CreateZRotation(30 * Azimath.DEG_2_RAD);

			test = multiplier * test;

			Vec4 expected = new Vec4(0.598075f, 4.9641f, 3, 4);
			
			Assert.IsTrue(Compare(expected, test));
			//Assert.Fail("Vec4MatrixTransform Test not implemented");
		}

		[TestMethod]
		public void Vec4MatrixTransform2()
		{
			Vec3 test = new Vec3(3, 4, 3);
			Mat4 multiplier = Mat4.CreateZRotation(30 * Azimath.DEG_2_RAD);

			test = multiplier.TransFormPoint(test);

			Vec3 expected = new Vec3(0.598075f, 4.9641f, 3);
			Assert.IsTrue(Compare(test, expected));
			//Assert.Fail("Vec4MatrixTransform2 Test not implemented");
		}

		[TestMethod]
		public void Mat4Multiply()
		{
			Mat4 a = new Mat4(2, 9, 8, 0,
			                  19, 42, 30, 0,
			                  0, 2, 1, 0,
			                  0, 0, 0, 1);

			Mat4 b = new Mat4(10, 23, 3, 0,
			                  11, 52, 2, 0,
			                  0, 3, 1, 0,
			                  0, 0, 0, 1);

			Mat4 expected = new Mat4(457, 1062, 773, 0,
			                         1010, 2287, 1650, 0,
			                         57, 128, 91, 0,
			                         0, 0, 0, 1);

			Mat4 c = a * b;
			
			Assert.IsTrue(Compare(expected, c));
			//Assert.Fail("Mat4Multiply Test not implemented");
		}

		[TestMethod]
		public void Vec4MatrixTranslation()
		{
			Vec3 rand = new Vec3(-1000, 1000, 1000);

			Mat4 test = Mat4.CreateTranslation(rand);

			Mat4 expected  = new Mat4
				(1, 0, 0, rand.x, 
				 0, 1, 0,rand.y, 
				 0, 0, 1,rand.z, 
				 0, 0, 0, 1);

			Assert.IsTrue(Compare(expected, test));
			//Assert.Fail("Vector4MatrixTranslation Test not implemented");
		}

		[TestMethod]
		public void Vec4MatrixTranslation2()
		{
			Mat4 test = Mat4.CreateTranslation(60, 70, 80);

			Vec3 result = test.GetTranslation();

			Vec3 expected = new Vec3(60, 70, 80);
			
			Assert.IsTrue(Compare(expected, result));
			//Assert.Fail("Vector4MatrixTranslation2 Test not implemented");
		}

		[TestMethod]
		public void Vec4MatrixTranslation3()
		{
			Mat4 test = new Mat4();
			
			test.SetTranslation(60, 70, 80);

			Vec3 result = test.GetTranslation();

			Vec3 expected = new Vec3(60, 70, 80);
			
			Assert.IsTrue(Compare(expected, result));
			//Assert.Fail("Vec4MatrixTranslation3 Test not implemented");
		}

		[TestMethod]
		public void Vec4MatrixTranslation4()
		{
			Mat4 test = new Mat4(1, 0, 0, 50,
			                     0, 1, 0, 60,
			                     0, 0, 1, 20,
			                     0, 0, 0, 1);
			
			test.Translate(50, 60, 20);

			Vec3 result = test.GetTranslation();

			Vec3 expected = new Vec3(100, 120, 40);
			
			Assert.IsTrue(Compare(result, expected));
			//Assert.Fail("Vec4MatrixTranslation4 Test not implemented");
		}
	}
}