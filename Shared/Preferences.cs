using System;
using System.Threading.Tasks;

namespace ExampleApp.Shared
{
    public record Preferences
    {
        public bool DarkMode { get; init; }
    }

    public class ProfileService
    {
        public Preferences Preferences { get; set; } = new();

        public event Action<Preferences> OnChange;

        public async Task ToggleDarkMode()
        {
            Preferences = Preferences with {DarkMode = !Preferences.DarkMode};
            OnChange?.Invoke(Preferences);
        }

        public void Set(Preferences preferences)
        {
            Preferences = preferences;
            OnChange?.Invoke(Preferences);
        }
    }
}