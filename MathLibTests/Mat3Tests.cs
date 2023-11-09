using MathLib;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MathLibTests
{
	[TestClass]
	public class Mat3Tests : MathLibTestBase
	{
		[TestMethod]
		public void Mat3SetRotateX()
		{
			Mat3 expected = new Mat3(1, 0, 0,
			                  0, 0.34202f, -0.939693f,
			                  0, 0.939693f, 0.34202f);
			Mat3 test = new Mat3();
			test.SetXrotation(70 * Azimath.DEG_2_RAD);
			
			Assert.IsTrue( Compare(expected, test));
			
			//Assert.Fail("Mat3SetRotateX Test not implemented");
		}

		[TestMethod]
		public void Mat3SetRotateY()
		{
			Mat3 expected = new Mat3(0.34202f, 0, 0.939693f,
			                         0, 1, 0,
			                         -0.939693f, 0, 0.34202f);
			Mat3 test = new Mat3();
			test.SetYRotation(70 * Azimath.DEG_2_RAD);
			
			Assert.IsTrue( Compare(expected, test));
			
			//Assert.Fail("Mat3SetRotateY Test not implemented");
		}

		[TestMethod]
		public void Mat3SetRotateZ()
		{
			Mat3 expected = new Mat3(0.34202f, -0.939693f, 0,
			                         0.939693f, 0.34202f, 0,
			                         0, 0, 1);
			Mat3 test = new Mat3();
			test.SetZRotation(70 * Azimath.DEG_2_RAD);
			
			Assert.IsTrue( Compare(expected, test));
			
			//Assert.Fail("Mat3SetRotateZ Test not implemented");
		}

		[TestMethod]
		public void Vec3MatrixTransform()
		{
			Vec3 test = new Vec3(3, 4, 3);
			Mat3 multplier = Mat3.CreateZRotation(30 * Azimath.DEG_2_RAD);

			test = multplier * test;

			Vec3 expected = new Vec3(0.598075f, 4.9641f, 3);

			Assert.IsTrue(Compare(test, expected));

			//Assert.Fail("Vec3MatrixTransform Test not implemented");
		}

		[TestMethod]
		public void Vec3MatrixTransform2()
		{
			Vec2 test = new Vec2(6, 9);
			Mat3 multplier = Mat3.CreateZRotation(30 * Azimath.DEG_2_RAD);

			test = multplier.TransFormPoint(test);

			Vec2 expected = new Vec2 (0.69615f, 10.794225f);

			Assert.IsTrue(Compare(test, expected));
			
			//Assert.Fail("Vec3MatrixTransform2 Test not implemented");
		}

		[TestMethod]
		public void Mat3Multiply()
		{

			Mat3 a = new Mat3(0, 1 ,1 ,
			                  1, 0, 0,
			                  0, 1, 1);
			
			Mat3 b = new Mat3(57, 62 ,1 ,
			                  59, 23, 1,
			                  1, 1, 1);
			
			Mat3 expected = new Mat3(62, 58, 58,
			                         23, 60, 60,
			                         1, 2, 2);
			
			Mat3 c = a * b;
			
			Assert.IsTrue(Compare(expected, c));
			
			//Assert.Fail("Mat3Multiply Test not implemented");
		}

		[TestMethod]
		public void Vec3MatrixTranslation()
		{
			Vec2 rand = new Vec2(-1000, 1000);
			
			Mat3 testing = Mat3.CreateTranslation(rand);

			Mat3 expected = new Mat3(1, 0, rand.x,
			                         0, 1, rand.y,
			                         0, 0, 1);
			
			Assert.IsTrue(Compare(expected, testing));
			//Assert.Fail("Vec3MatrixTranslation Test not implemented");
		}

		[TestMethod]
		public void Vec3MatrixTranslation2()
		{
			Mat3 test = Mat3.CreateTranslation(60,70);

			Vec2 result = test.GetTranslation();

			Vec2 expected = new Vec2(60, 70);

			Assert.IsTrue(Compare(expected, result));
			//Assert.Fail("Vec3MatrixTranslation2 Test not implemented");
		}

		[TestMethod]
		public void Vec3MatrixTranslation3()
		{
			Mat3 test = new Mat3();

			test.SetTranslation(60, 70);

			Vec2 result = test.GetTranslation();

			Vec2 expected = new Vec2(60, 70);
			
			Assert.IsTrue(Compare(result, expected));

			//Assert.Fail("Vec3MatrixTranslation3 Test not implemented");
		}

		[TestMethod]
		public void Vec3MatrixTranslation4()
		{
			Mat3 test = new Mat3(1, 0, 50,
			                     0, 1, 60,
			                     0, 0 , 1);
			
			test.Translate(50, 60);

			Vec2 result = test.GetTranslation();

			Vec2 expected = new Vec2(100, 120);
			
			Assert.IsTrue(Compare(result, expected));

			//Assert.Fail("Vec3MatrixTranslation4 Test not implemented");
		}
	}
}