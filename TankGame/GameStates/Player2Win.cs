using Azimuth.GameStates;
using Azimuth.UI;
using MathLib;
using Raylib_cs;

namespace TankGame.GameStates;

public class Player2Win : IGameState
{
    public string ID => TankGameGame.WIN_TWO;
    private Button playButton;

    public void Load()
    {
        playButton = new Button(new Vec2(530, 550), "PLAY", new Button.RenderSettings(60, Color.BLACK));
        UIManager.Add(playButton);
        playButton.AddListener(ChangeState);
    }

    private void ChangeState()
    {
        GameStateManager.DeactivateState("P2Win");
        GameStateManager.ActivateState("Play");
    }

    public void Update(float _deltaTime)
    {
    }

    public void Draw()
    {
        Raylib.DrawRectangle(0, 0, 1200, 1200, Color.DARKGRAY);
        Raylib.DrawText("Player Two Wins!", 200, 200, 100, Color.RED);
    }

    public void Unload()
    {
        UIManager.Remove(playButton);
    }
}