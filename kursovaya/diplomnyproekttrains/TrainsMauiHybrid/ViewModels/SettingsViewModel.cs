using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace TrainsMauiHybrid;

public class SettingsViewModel : INotifyPropertyChanged {
    string language;
    bool isPrivateChatEnabled = true;
    bool isGroupChatEnabled;
    bool isSoundEnabled = true;
    string vibrationMode;
    string bio;
    static AppTheme currentTheme = Application.Current.RequestedTheme;
    string getwiptheme = currentTheme.ToString();

    public SettingsViewModel() {
        Language = "English";

        if (getwiptheme == "Dark") {
            VibrationMode = "Dark";
        } else {
            VibrationMode = "Light";
        }


        Blacklist.CollectionChanged += OnBlacklistCollectionChanged;
    }
    public string Language {
        get => this.language;
        set {
            this.language = value;
            OnPropertyChanged();
        }
    }
    public bool IsPrivateChatEnabled {
        get => this.isPrivateChatEnabled;
        set {
            this.isPrivateChatEnabled = value;
            OnPropertyChanged();
        }
    }
    public bool IsGroupChatEnabled {
        get => this.isGroupChatEnabled;
        set {
            this.isGroupChatEnabled = value;
            OnPropertyChanged();
        }
    }
    public bool IsSoundEnabled {
        get => this.isSoundEnabled;
        set {
            this.isSoundEnabled = value;
            OnPropertyChanged();
        }
    }
    public string VibrationMode {
        get => this.vibrationMode;
        set {
            this.vibrationMode = value;
            if (value == "Dark") {
                Application.Current.UserAppTheme = AppTheme.Dark;
            }
            if (value == "Light") {
                Application.Current.UserAppTheme = AppTheme.Light;
            }
            OnPropertyChanged();
        }
    }
    public string Bio {
        get => this.bio;
        set {
            this.bio = value;
            OnPropertyChanged();
        }
    }
    public ObservableCollection<string> Blacklist { get; } = new();
    void OnBlacklistCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
        OnPropertyChanged(nameof(Blacklist));
    }
    public List<string> Modes { get; } = new() {
        "Light", "Dark"
    };
    public List<string> Contacts { get; } = new() {
        "Bruce Cambell", "Andrea Deville", "Anita Ryan", "George Bunkelman", "Anita Cardle", "Andrew Carter", "Almas Basinger", "Carolyn Baker", "Anthony Rounds"
    };
    public List<string> Languages { get; } = new() {
        "English", "German", "French", "Spanish", "Italian", "Russian", "Chinese", "Japanese"
    };
    public ICommand EditBioCommand => new Command(EditBio);

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null) {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    async void EditBio() {
        Dictionary<string, object> parameters = new() {
            { "Settings", this }
        };
        await Shell.Current.GoToAsync("EditBioPage", parameters);
    }
}