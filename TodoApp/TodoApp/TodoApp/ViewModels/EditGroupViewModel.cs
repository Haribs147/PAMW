using System.Windows.Input;
using TodoApp.Models;
using TodoApp.Services;

namespace TodoApp.ViewModels
{
    public class EditGroupViewModel
    {
        private readonly TodoApiService _apiService;

        public Group Group { get; }

        public ICommand SaveCommand { get; }

        public EditGroupViewModel(Group group, TodoApiService apiService)
        {
            Group = group;
            _apiService = apiService;
            SaveCommand = new Command(async () => await SaveGroupAsync());
        }

        private async Task SaveGroupAsync()
        {
            try
            {
                await _apiService.UpdateGroupAsync(Group);
                await App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", $"Failed to update group: {ex.Message}", "OK");
            }
        }
    }
}
