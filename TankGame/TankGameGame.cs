using Azimuth;
using Azimuth.GameStates;
using TankGame.GameStates;

namespace TankGame
{
    public class TankGameGame : Game
    {
        public const string PLAY_ID = "Play";
        public const string MENU_ID = "Menu";
        public const string WIN_ONE = "P1Win";
        public const string WIN_TWO = "P2Win";

        private PlayState playState;
        private MenuState menuState;
        private Player1Win player1Win;
        private Player2Win player2Win;

        public override void Load()
        {
            player1Win = new Player1Win();
            GameStateManager.AddState(player1Win);

            player2Win = new Player2Win();
            GameStateManager.AddState(player2Win);


            menuState = new MenuState();
            GameStateManager.AddState(menuState);

            playState = new PlayState("Dirt");
            GameStateManager.AddState(playState);

            GameStateManager.ActivateState(MENU_ID);
        }

        public override void Update(float _deltaTime)
        {
        }

        public override void Unload()
        {
        }
    }
}