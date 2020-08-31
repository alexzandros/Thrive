using System;
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

    public override void _Ready()
    {
        microbeWelcomeMessage = GetNode<WindowDialog>(MicrobeWelcomeMessagePath);

        microbeWelcomeMessage.PopupCenteredMinsize(new Vector2(200, 300));
    }

    public override void _Process(float delta)
    {
    }
}
