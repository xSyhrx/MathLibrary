using Azimuth;
using Azimuth.GameObjects;
using MathLib;
using MathLib.Geometry;
using Raylib_cs;

namespace TankGame.GameObjects
{
    public class Bullet : GameObject
    {
        public readonly int speed;
        public Rect rect;
        
        public readonly string textureId;
        public Texture2D texture;

        public Bullet(string _textureId, Vec2 _position, Vec2 _scale) : base(_position, 0, _scale)
        {
            textureId = _textureId;
            speed = Config.Get<int>("Controls", "bulletSpeed");
        }

        public override void Update(float _deltaTime)
        {
            rect = new Rect(transform.Position, new Vec2(20, 20));
            transform.transform = Mat3.CreateTranslation(Vec2.up * _deltaTime * speed) * transform.transform;
        }

        public override void Load()
        {
            texture = Assets.Find<Texture2D>($"Textures/{textureId}");
        }

        public override void Draw()
        {
            Vec2 position = transform.Position;
            Vec2 scale = transform.Scale;

            Rectangle src = new(0, 0, texture.width, texture.height);
            Rectangle dst = new(position.x, position.y, scale.x / 2, scale.y / 2);

            Raylib.DrawTexturePro(texture, src, dst, scale / 4, transform.Rotation, Colour.White);
        }
    }
}