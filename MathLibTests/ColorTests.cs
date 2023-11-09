using MathLib;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Raylib_cs;

using System.Xml;

namespace MathLibTests
{
	[TestClass]
	public class ColorTests : MathLibTestBase
	{
		[TestMethod]
		public void ColorConstructor()
		{
			Colour a = new Colour(255, 0, 0, 0);

			Color b = new Color(255, 0, 0, 0);


			Assert.IsTrue(Compare((float)a.GetRed(), b.r) && Compare((float)a.GetGreen(), b.g) && Compare((float)a.GetBlue(), b.b) && Compare((float)a.GetAlpha(), b.a));
			//Assert.Fail("ColorConstructor Test not implemented");
		}

		[TestMethod]
		public void ColorGetRed()
		{
			Colour a = new Colour(255, 0, 0, 0);

			Color b = new Color(255, 0, 0, 0);

			Assert.AreEqual(a.GetRed(), b.r);

			//Assert.Fail("ColorGetRed Test not implemented");
		}

		[TestMethod]
		public void ColorGetGreen()
		{
			Colour a = new Colour(0,255,0,0);

			Color b = new Color(0, 255, 0, 0);

			Assert.AreEqual(a.GetGreen(), b.g);

			//Assert.Fail("ColorGetGreen Test not implemented");
		}


		[TestMethod]
		public void ColorGetBlue()
		{
			Colour a = new Colour(0, 0, 255, 0);

			Color b = new Color(0, 0, 255, 0);

			Assert.AreEqual(a.GetBlue(), b.b);
			//Assert.Fail("ColorGetBlue Test not implemented");
		}

		[TestMethod]
		public void ColorGetAlpha()
		{
			Colour a = new Colour(0, 0, 0, 255);

			Color b = new Color(0, 0, 0, 255);

			Assert.AreEqual(a.GetAlpha(), b.a);

			//Assert.Fail("ColorGetAlpha Test not implemented");
		}

		[TestMethod]
		public void ColorSetRed()
		{
			Colour a = new Colour();

			a.SetRed(255);

			Color b = new Color(255, 0, 0, 0);

			Assert.AreEqual(a.GetRed(), b.r);
			//Assert.Fail("ColorSetRed Test not implemented");
		}

		[TestMethod]
		public void ColorSetGreen()
		{
			Colour a = new Colour();

			a.SetGreen(255);

			Color b = new Color(0, 255, 0, 0);

			Assert.AreEqual(a.GetGreen(), b.g);
			
			//Assert.Fail("ColorSetGreen Test not implemented");
		}

		[TestMethod]
		public void ColorSetBlue()
		{
			Colour a = new Colour();

			a.SetBlue(255);

			Color b = new Color(0, 0, 255, 0);

			Assert.AreEqual(a.GetBlue(), b.b);
			//Assert.Fail("ColorSetBlue Test not implemented");
		}

		[TestMethod]
		public void ColorSetAlpha()
		{
			Colour a = new Colour();

			a.SetAlpha(255);

			Color b = new Color(0, 0, 0, 255);

			Assert.AreEqual(a.GetAlpha(), b.a);
			//Assert.Fail("ColorSetBlue Test not implemented");
		}

		[TestMethod]
		public void ColourShift()
		{
			Colour test = new Colour(255, 0, 0, 0);

			Colour expected = new Colour(0, 255, 0, 0);

			test.colour = test.colour >> 8;

			Assert.IsTrue(Compare(test, expected));
		}
	}
}