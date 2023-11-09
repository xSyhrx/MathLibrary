using Azimuth.GameObjects;
using Azimuth.GameStates;
using MathLib;
using MathLib.Geometry;

namespace TankGame.GameObjects
{
    public class Collision
    {
        private readonly Tank tank;
        private readonly Tank2 tank2;
        private readonly Turret2 turret2;
        private readonly Turret turret;
        public readonly List<Bullet> bullets;
        public readonly List<Bull> bulls;
        private readonly Bounds bounds;

        public Collision(Tank _tank, Tank2 _tank2, Turret2 _turret2, Turret _turret, List<Bullet> _bullets,
            Bounds _bounds, List<Bull> _bulls)
        {
            tank = _tank;
            tank2 = _tank2;
            turret2 = _turret2;
            bullets = _bullets;
            bounds = _bounds;
            bulls = _bulls;
            turret = _turret;
        }

        public void Update(float _deltaTime)
        {
            Hit? tankHit1 = tank.rect.Intersects(tank2.rect.center);
            if (tankHit1 != null)
            {
                tank2.transform.transform.Translation += tankHit1.Value.delta;
                Console.WriteLine(tankHit1.Value.delta);
            }

            Hit? tankHit2 = tank2.rect.Intersects(tank.rect);
            if (tankHit2 != null)
            {
                tank.transform.transform.Translation += tankHit2.Value.delta;
                Console.WriteLine(tankHit2.Value.delta);
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                Hit? bulletTankHit = bullets[i].rect.Intersects(tank2.rect);
                if (bulletTankHit != null)
                {
                    GameObjectManager.Destroy(bullets[i]);
                    bullets.Remove(bullets[i]);
                    GameObjectManager.Destroy(tank2);
                    GameObjectManager.Destroy(tank);
                    GameObjectManager.Destroy(turret2);
                    GameObjectManager.Destroy(turret);

                    GameStateManager.DeactivateState("Play");
                    GameStateManager.ActivateState("P1Win");
                    Console.WriteLine("Hit");
                }
            }

            for (int i = 0; i < bulls.Count; i++)
            {
                Hit? bullsTankHit = bulls[i].rect.Intersects(tank.rect);
                if (bullsTankHit != null)
                {
                    GameObjectManager.Destroy(bulls[i]);
                    GameObjectManager.Destroy(tank2);
                    GameObjectManager.Destroy(tank);
                    GameObjectManager.Destroy(turret2);
                    GameObjectManager.Destroy(turret);

                    GameStateManager.DeactivateState("Play");
                    GameStateManager.ActivateState("P2Win");
                    bulls.Remove(bulls[i]);
                    Console.WriteLine("Hit");
                }
            }

            for (int i = 0; i < bullets.Count; i++)
            {
                if (bullets[i].rect.Max == Vec2.zero && bullets[i].rect.Min == Vec2.zero)
                    continue;

                Hit? bulletBoundHit = bullets[i].rect.Intersects(bounds.rect);
                if (bulletBoundHit == null)
                {
                    GameObjectManager.Destroy(bullets[i]);
                    bullets.Remove(bullets[i]);
                    Console.WriteLine("Hit");
                }
            }

            for (int i = 0; i < bulls.Count; i++)
            {
                if (bulls[i].rect.Max == Vec2.zero && bulls[i].rect.Min == Vec2.zero)
                    continue;

                Hit? bullBoundHit = bulls[i].rect.Intersects(bounds.rect);
                if (bullBoundHit == null)
                {
                    GameObjectManager.Destroy(bulls[i]);
                    bulls.Remove(bulls[i]);
                    Console.WriteLine("Hit");
                }
            }
        }
    }
}