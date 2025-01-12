namespace TodoApp;
using TodoApp.Models;
using TodoApp.Services;
using TodoApp.ViewModels;

public partial class EditGroupPage : ContentPage
{
    public EditGroupPage(Group group, TodoApiService apiService)
    {
        InitializeComponent();
        BindingContext = new EditGroupViewModel(group, apiService);
    }
}
