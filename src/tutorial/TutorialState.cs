using System;
using Newtonsoft.Json;

/// <summary>
///   State of the tutorials for a game of Thrive
/// </summary>
public class TutorialState : ITutorialInput
{
    [JsonProperty]
    private bool enabled = Settings.Instance.TutorialsEnabled;

    [JsonProperty]
    private bool showMicrobeWelcome;

    [JsonProperty]
    private bool microbeWelcomeShown;

    private bool needsToApplyEvenIfDisabled;

    [JsonIgnore]
    public bool Enabled
    {
        get => enabled;
        set
        {
            if (enabled == value)
                return;

            enabled = true;
        }
    }

    /// <summary>
    ///   Handles an event that potentially changes the tutorial state
    /// </summary>
    /// <param name="eventType">Type of the event that happened</param>
    /// <param name="args">Event arguments or EventArgs.Empty</param>
    /// <param name="sender">Who sent it, some events need access to the stage</param>
    public void SendEvent(TutorialEventType eventType, EventArgs args, object sender)
    {
        _ = sender;
        _ = args;

        // TODO: some events might actually be better to always handle
        if (!Enabled)
            return;

        switch (eventType)
        {
            case TutorialEventType.EnteredMicrobeStage:
            {
                if (!microbeWelcomeShown)
                {
                    microbeWelcomeShown = true;
                    showMicrobeWelcome = true;
                }

                break;
            }
        }
    }

    /// <summary>
    ///   Resets all the show flags to false
    /// </summary>
    public void HideAll()
    {
        showMicrobeWelcome = false;
    }

    public void Process(TutorialGUI gui, float delta)
    {
        if (!Enabled)
        {
            if (!needsToApplyEvenIfDisabled)
            {
                HideAll();
                ApplyGUIState(gui);
            }

            return;
        }

        _ = delta;

        ApplyGUIState(gui);
    }

    public void OnTutorialDisabled()
    {
        Enabled = false;
        HideAll();
        needsToApplyEvenIfDisabled = true;
    }

    public void OnTutorialEnabled()
    {
        Enabled = true;
    }

    public void OnCurrentTutorialClosed(string name)
    {
        // TODO: implement name checking
        HideAll();
    }

    public void OnTutorialClosed()
    {
        HideAll();
        needsToApplyEvenIfDisabled = true;
    }

    public void OnNextPressed()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    ///   Applies all the GUI states related to the tutorial, this makes saving and loading the tutorial state easier
    /// </summary>
    /// <param name="gui">The target gui instance</param>
    private void ApplyGUIState(TutorialGUI gui)
    {
        gui.MicrobeWelcomeVisible = showMicrobeWelcome;

        needsToApplyEvenIfDisabled = true;
    }
}
