
using Newtonsoft.Json;

/// <summary>
///   State of the tutorials for a game of Thrive
/// </summary>
public class TutorialState
{
    [JsonProperty]
    private bool enabled = Settings.Instance.TutorialsEnabled;

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
}
