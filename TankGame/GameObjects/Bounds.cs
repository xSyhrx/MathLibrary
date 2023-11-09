using Azimuth.GameObjects;
using MathLib;
using MathLib.Geometry;
using Raylib_cs;

namespace TankGame.GameObjects
{
    public class Bounds : GameObject
    {
        public Rect rect;

        public Bounds(Vec2 _position, Vec2 _scale) : base(_position, 0, _scale)
        {
        }

        public override void Update(float _deltaTime)
        {
            rect = new Rect(new Vec2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2),
                new Vec2(Raylib.GetScreenWidth() / 2, Raylib.GetScreenHeight() / 2));
        }
        
        public override void Draw()
        {
            Raylib.DrawRectangleLinesEx(rect, 5, Color.DARKGREEN);
        }
    }
}