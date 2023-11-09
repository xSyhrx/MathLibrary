using Azimuth;
using Azimuth.GameObjects;
using MathLib;
using MathLib.Geometry;
using Raylib_cs;
using Rectangle = Raylib_cs.Rectangle;

namespace TankGame.GameObjects
{
    public class Tank2 : GameObject
    {
        private readonly int moveSpeed;
        private readonly int rotSpeed;

        private readonly string textureId;
        private Texture2D texture;

        public Rect rect;

        public Tank2(string _textureId, Vec2 _position, Vec2 _scale) : base(_position, 0, _scale)
        {
            moveSpeed = Config.Get<int>("Controls", "moveSpeed");
            rotSpeed = Config.Get<int>("Controls", "rotSpeed");
            textureId = _textureId;
        }

        public override void Update(float _deltaTime)
        {
            rect = new Rect(transform.Position, new Vec2(55, 64));

            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                transform.transform = Mat3.CreateTranslation(Vec2.up * _deltaTime * moveSpeed) * transform.transform;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                transform.transform = Mat3.CreateTranslation(Vec2.down * _deltaTime * moveSpeed) * transform.transform;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                transform.Rotation += _deltaTime * rotSpeed;
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                transform.Rotation -= _deltaTime * rotSpeed;
            }
        }

        public override void Load()
        {
            texture = Assets.Find<Texture2D>($"Textures/{textureId}");
        }

        public override void Draw()
        {
            Vec2 position = transform.Position;
            Vec2 scale = transform.Scale;

            Rectangle src = new(0, 0, texture.width / 2, texture.height);
            Rectangle dst = new(position.x, position.y, scale.x, scale.y);

            Raylib.DrawTexturePro(texture, src, dst, scale / 2, transform.Rotation, Colour.White);
        }
    }
}