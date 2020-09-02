using Godot;

/// <summary>
///   GUI control that contains the tutorial. Should be placed over any game state GUI so that things drawn
///   by this are on top. Controlled by Tutorial object
/// </summary>
public class TutorialGUI : Control
{
    [Export]
    public NodePath MicrobeWelcomeMessagePath;

    private WindowDialog microbeWelcomeMessage;

    public ITutorialInput EventReceiver { get; set; }

    public bool MicrobeWelcomeVisible
    {
        get => microbeWelcomeMessage.Visible;
        set
        {
            if (value == microbeWelcomeMessage.Visible)
                return;

            if (value)
            {
                microbeWelcomeMessage.PopupCentered();
            }
            else
            {
                microbeWelcomeMessage.Visible = false;
            }
        }
    }

    public override void _Ready()
    {
        microbeWelcomeMessage = GetNode<WindowDialog>(MicrobeWelcomeMessagePath);
    }

    /// <summary>
    ///   A button that closes all tutorials was pressed by the user
    /// </summary>
    private void OnClickedCloseAll()
    {
        GUICommon.Instance.PlayButtonPressSound();
        EventReceiver?.OnTutorialClosed();
    }

    // public override void _Process(float delta)
    // {
    // }
}
