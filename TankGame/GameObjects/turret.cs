using Azimuth;
using Azimuth.GameObjects;
using MathLib;
using Raylib_cs;
using TankGame.GameStates;

namespace TankGame.GameObjects
{
    public class Turret : GameObject
    {
        private readonly string textureID;
        private Texture2D texture;
        private readonly int speed;

        public Turret(string _textureId, Vec2 _position, Vec2 _scale) : base(_position, 0, _scale)
        {
            speed = Config.Get<int>("Controls", "turretSpeed");
            textureID = _textureId;
        }

        public override void Update(float _deltaTime)
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_Q))
            {
                transform.transform.SetZRotation(transform.transform.RotationX -
                                                 _deltaTime * speed * Azimath.DEG_2_RAD);
            }

            if (Raylib.IsKeyDown(KeyboardKey.KEY_E))
            {
                transform.transform.SetZRotation(transform.transform.RotationX +
                                                 _deltaTime * speed * Azimath.DEG_2_RAD);
            }

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
            }
        }

        public override void Load()
        {
            texture = Assets.Find<Texture2D>($"Textures/{textureID}");
        }

        public override void Draw()
        {
            Vec2 position = transform.Position;
            Vec2 scale = transform.Scale;

            Rectangle src = new(texture.width / 2, 0, texture.width / 2, texture.height);
            Rectangle dst = new(position.x, position.y, scale.x, scale.y);

            Raylib.DrawTexturePro(texture, src, dst, scale / 2, transform.Rotation, Colour.White);
        }
    }
}