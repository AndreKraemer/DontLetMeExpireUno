namespace DontLetMeExpireUno.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;


    public MainViewModel(
        IStringLocalizer localizer,
        IOptions<AppConfig> appInfo,
        INavigator navigator)
    {
        _navigator = navigator;
        Title = "Main";
        Title += $" - {localizer["ApplicationName"]}";
        Title += $" - {appInfo?.Value?.Environment}";
    }
    public string? Title { get; }

    [RelayCommand]
    private async Task NavigateToDetails()
    {
        await _navigator.NavigateViewModelAsync<ItemViewModel>(this, data: new Entity("Demo"));
    }

}
