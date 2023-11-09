using Azimuth.GameStates;
using Azimuth.UI;
using MathLib;
using Raylib_cs;

namespace TankGame.GameStates
{
    public class MenuState : IGameState
    {
        public string ID => TankGameGame.MENU_ID;
        private Button playButton;

        public void Load()
        {
            playButton = new Button(new Vec2(530, 550), "PLAY", new Button.RenderSettings(60, Color.BLACK));
            UIManager.Add(playButton);
            playButton.AddListener(ChangeState);
        }

        public void Update(float _deltaTime)
        {
        }

        private void ChangeState()
        {
            GameStateManager.DeactivateState("Menu");
            GameStateManager.ActivateState("Play");
        }

        public void Draw()
        {
            Raylib.DrawRectangle(0, 0, 1200, 1200, Color.DARKGRAY);
            Raylib.DrawText("TANK GAME", 300, 200, 100, Color.BLUE);
        }

        public void Unload()
        {
            UIManager.Remove(playButton);
        }
    }
}