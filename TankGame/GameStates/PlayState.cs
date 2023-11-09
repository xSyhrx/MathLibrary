using Azimuth;
using Azimuth.GameObjects;
using Azimuth.GameStates;
using MathLib;
using Raylib_cs;
using TankGame.GameObjects;

namespace TankGame.GameStates
{
    public class PlayState : IGameState
    {
        private GameObject world;
        private Tank player;
        private Tank2 player2;
        private Turret turret;
        private Turret2 turret2;
        private readonly Texture2D backGround;
        private readonly string textureId;
        private Collision collision;
        private Bounds bounds;

        public string ID => TankGameGame.PLAY_ID;

        public PlayState(string _textureId)
        {
            textureId = _textureId;
            backGround = Assets.Find<Texture2D>($"Textures/{textureId}");
        }

        public void Load()
        {
            world = new GameObject(new Vec2(0, 0), 0, new Vec2(120, 120));
            GameObjectManager.Spawn(world);

            Vec2 scaledHalfScreen = new Vec2()
            {
                x = Application.Instance.Window.Width / 2 / world.transform.Scale.x,
                y = Application.Instance.Window.Height / 2 / world.transform.Scale.y,
            };

            bounds = new Bounds(new Vec2(Raylib.GetScreenWidth(), Raylib.GetScreenHeight()), Vec2.one);
            GameObjectManager.Spawn(bounds);

            player = new Tank("Tank111", scaledHalfScreen, new Vec2(1, 1));
            player.transform.SetParent(world.transform);
            GameObjectManager.Spawn(player);
            Console.WriteLine(player.transform.Position);

            turret = new Turret("Tank111", Vec2.zero, new Vec2(1, 1));
            GameObjectManager.Spawn(turret);
            turret.transform.SetParent(player.transform);

            player2 = new Tank2("Tank111", scaledHalfScreen / 2, new Vec2(1, 1));
            GameObjectManager.Spawn(player2);
            player2.transform.SetParent(world.transform);

            turret2 = new Turret2("Tank111", Vec2.zero, new Vec2(1, 1));
            GameObjectManager.Spawn(turret2);
            turret2.transform.SetParent(player2.transform);

            collision = new Collision(player, player2, turret2, turret, new List<Bullet>(), bounds, new List<Bull>());
        }

        private Bullet Shoot() // spawns the bullet and returns it
        {
            Bullet bullet = new("bullet", Vec2.zero, new Vec2(1, 1));
            bullet.transform.SetParent(world.transform);
            bullet.transform.Position = player.transform.LocalPosition + (turret.transform.Forward * 0.5f);
            bullet.transform.Rotation = turret.transform.Rotation;

            GameObjectManager.Spawn(bullet);
            Console.WriteLine(bullet.transform.LocalPosition);

            return bullet;
        }

        private Bull Shoot2() // spawns the bullet and returns it
        {
            Bull bull = new("bullet", Vec2.zero, new Vec2(1, 1));
            bull.transform.SetParent(world.transform);
            bull.transform.Position = player2.transform.LocalPosition + (turret2.transform.Forward * 0.5f);
            bull.transform.Rotation = turret2.transform.Rotation;

            GameObjectManager.Spawn(bull);
            Console.WriteLine(bull.transform.LocalPosition);

            return bull;
        }

        public void Update(float _deltaTime) // calls both shoot functions and adds bullets to a list
        {
            if (Raylib.IsKeyPressed(KeyboardKey.KEY_END))
            {
                collision.bulls.Add(Shoot2());
                Console.WriteLine(collision.bullets.Count);
            }


            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                collision.bullets.Add(Shoot());
                Console.WriteLine(collision.bulls.Count);
            }

            collision.Update(_deltaTime);
        }

        public void Draw()
        {
            Rectangle src = new Rectangle(0, 0, backGround.width, backGround.height);
            Rectangle dst = new Rectangle(0, 0, Application.Instance.Window.Width, Application.Instance.Window.Height);

            Raylib.DrawTexturePro(backGround, src, dst, Vec2.zero, 0, Colour.White);
        }

        public void Unload()
        {
        }
    }
}