using DontLetMeExpireUno.Services;

namespace DontLetMeExpireUno.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private INavigator _navigator;
    private readonly DummyItemService _itemService = new();

    [ObservableProperty]
    private int _stockCount;

    [ObservableProperty]
    private int _expiringSoonCount;

    [ObservableProperty]
    private int _expiresTodayCount;

    [ObservableProperty]
    private int _expiredCount;

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


    public async Task InitializeAsync()
    {
        StockCount = (await _itemService.GetAsync()).Count();
        ExpiringSoonCount = (await _itemService.GetExpiresSoonAsync()).Count();
        ExpiresTodayCount = (await _itemService.GetExpiresTodayAsync()).Count();
        ExpiredCount = (await _itemService.GetExpiredAsync()).Count();
    }


    [RelayCommand]
    private async Task NavigateToDetails()
    {
        await _navigator.NavigateViewModelAsync<ItemViewModel>(this, data: new Entity("Demo"));
    }

}
