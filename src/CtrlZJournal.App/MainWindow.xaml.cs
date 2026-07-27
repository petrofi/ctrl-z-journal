using System.Windows;
using System.Windows.Media;
using CtrlZJournal.Core.Entities;
using CtrlZJournal.Core.Enums;

namespace CtrlZJournal.App;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();

        MoodComboBox.ItemsSource = Enum.GetValues<WorkMood>();
        MoodComboBox.SelectedItem = WorkMood.Normal;
        WorkDatePicker.SelectedDate = DateTime.Today;
    }

    private void SaveEntryButton_Click(
        object sender,
        RoutedEventArgs e)
    {
        if (!int.TryParse(
                DurationTextBox.Text,
                out int durationMinutes))
        {
            ShowError("Duration must be a valid number.");
            return;
        }

        if (WorkDatePicker.SelectedDate is not DateTime selectedDate)
        {
            ShowError("Please select a work date.");
            return;
        }

        WorkMood mood =
            MoodComboBox.SelectedItem is WorkMood selectedMood
                ? selectedMood
                : WorkMood.Normal;

        try
        {
            WorkEntry workEntry = new WorkEntry(
                TitleTextBox.Text,
                WorkDescriptionTextBox.Text,
                DateOnly.FromDateTime(selectedDate),
                durationMinutes,
                mood);

            StatusTextBlock.Foreground = Brushes.SeaGreen;
            StatusTextBlock.Text =
                $"Entry created: {workEntry.Title} " +
                $"({workEntry.DurationMinutes} minutes)";
        }
        catch (ArgumentException exception)
        {
            ShowError(exception.Message);
        }
    }

    private void ShowError(string message)
    {
        StatusTextBlock.Foreground = Brushes.Firebrick;
        StatusTextBlock.Text = message;
    }
}