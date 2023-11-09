namespace MathLib.Geometry
{
	public struct Hit
	{
		
		// this is the point of contact between 2 objects
		public Vec2 point;

		// this is the surface normal at the point of contact
		public Vec2 normal;

		// this is the overlap between the two shapes
		public Vec2 delta;
	}
}