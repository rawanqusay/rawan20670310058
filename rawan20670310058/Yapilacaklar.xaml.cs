using System.Collections.ObjectModel;
using System.Text.Json;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel.DataTransfer; // Paylaşım için gerekli

namespace rawan20670310058;

public partial class Yapilacaklar : ContentPage
{
    public ObservableCollection<string> DailyTasks { get; set; }
    public ICommand AddTaskCommand { get; set; }
    public ICommand EditTaskCommand { get; set; }
    public ICommand DeleteTaskCommand { get; set; }
    public ICommand ShareCommand { get; set; } // Yeni paylaşım komutu

    public Yapilacaklar()
    {
        InitializeComponent();
        DailyTasks = new ObservableCollection<string>();
        LoadTasks();

        AddTaskCommand = new Command(OnAddTask);
        EditTaskCommand = new Command<string>(OnEditTask);
        DeleteTaskCommand = new Command<string>(OnDeleteTask);
        ShareCommand = new Command(OnShare); // Paylaşım komutu atandı

        BindingContext = this;
    }

    private void LoadTasks()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dailytasks.json");
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            DailyTasks = JsonSerializer.Deserialize<ObservableCollection<string>>(json) ?? new ObservableCollection<string>();
            OnPropertyChanged(nameof(DailyTasks)); // Güncellemeleri yansıtmak için
        }
    }

    private async void OnAddTask()
    {
        string newTask = await DisplayPromptAsync("Günlük Görev Ekle", "Yeni görevinizi girin:", "Ekle", "İptal", null, -1, Keyboard.Default, "");

        if (!string.IsNullOrWhiteSpace(newTask))
        {
            DailyTasks.Add(newTask);
            SaveTasks();
        }
    }

    private async void OnEditTask(string task)
    {
        string editedTask = await DisplayPromptAsync("Görevi Düzenle", "Yeni görevinizi girin:", "Kaydet", "İptal", task, -1, Keyboard.Default, "");

        if (!string.IsNullOrWhiteSpace(editedTask))
        {
            int index = DailyTasks.IndexOf(task);
            if (index >= 0)
            {
                DailyTasks[index] = editedTask;
                SaveTasks();
            }
        }
    }

    private async void OnDeleteTask(string task)
    {
        bool answer = await DisplayAlert("Sil", "Bu görevi silmek istediğinizden emin misiniz?", "Evet", "Hayır");

        if (answer)
        {
            DailyTasks.Remove(task);
            SaveTasks();
        }
    }

    private async void OnShare()
    {
        string tasksText = string.Join("\n", DailyTasks); // Tüm görevleri bir metin olarak birleştir
        await Share.RequestAsync(new ShareTextRequest
        {
            Text = tasksText,
            Title = "Görevleri Paylaş" // Paylaşım başlığı
        });
    }

    private void SaveTasks()
    {
        string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dailytasks.json");
        string json = JsonSerializer.Serialize(DailyTasks);
        File.WriteAllText(filePath, json);
    }
}

