using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Maui.BottomSheet;
using Maui.BottomSheet.Navigation;
using System.Collections.ObjectModel;

namespace MauiApp12;

public partial class BottomSheetVMViewModel : ObservableObject, IQueryAttributable
{
	private IBottomSheetNavigationService _navigationService;

	public ObservableCollection<Todo> Items { get; }

	public BottomSheetVMViewModel(IBottomSheetNavigationService bottomSheetNavigationService)
	{
		_navigationService = bottomSheetNavigationService;
        Items  = new ObservableCollection<Todo>();

    }	

	[ObservableProperty]
	private bool hasHandle = true;
	
	[ObservableProperty]
	private bool isSimpleHeaderSheetOpen;

	[ObservableProperty]
	private bool showSimpleHeaderSheetHeader = true;

	[ObservableProperty]
	private bool showSimpleTitleSheetHeader = true;

	partial void OnShowSimpleTitleSheetHeaderChanged(bool value)
	{
		if (value == false)
		{
			SimpleTitle = string.Empty;
		}
	}

	[RelayCommand]
	private void Opened() 
	{
		//HasHandle = true;
		//HasHandle = false;
    }

    [ObservableProperty]
	private BottomSheetHeaderAppearanceMode simpleHeaderAppearanceMode = BottomSheetHeaderAppearanceMode.LeftAndRightButton;

	[ObservableProperty]
	private BottomSheetState selectedState;

	[ObservableProperty]
	private string simpleTitle = "Simple";

	[ObservableProperty]
	private string simpleTopRightButtonText = "Large";

	[ObservableProperty]
	private string simpleTopLeftButtonText = "Medium";

	[RelayCommand]
	private void SimpleTopRight()
	{
		SelectedState = BottomSheetState.Large;
	}

	[RelayCommand]
	private void SimpleTopLeft()
	{
		SelectedState = BottomSheetState.Medium;
	}

	[RelayCommand]
	private void SimpleHeaderAppearanceNone()
	{
		SimpleHeaderAppearanceMode = BottomSheetHeaderAppearanceMode.None;
	}

	[RelayCommand]
	private void SimpleHeaderAppearanceLeft()
	{
		SimpleHeaderAppearanceMode = BottomSheetHeaderAppearanceMode.LeftButton;
	}

	[RelayCommand]
	private void SimpleHeaderAppearanceRight()
	{
		SimpleHeaderAppearanceMode = BottomSheetHeaderAppearanceMode.RightButton;
	}

	[RelayCommand]
	private void SimpleHeaderAppearanceBoth()
	{
		SimpleHeaderAppearanceMode = BottomSheetHeaderAppearanceMode.LeftAndRightButton;
	}

	[RelayCommand]
	private void Add()
	{
		Items.Add(new Todo() { MyProperty = "asd" });
    }

	[RelayCommand]
	private void NavigateToBottomSheetGoBack()
	{

        _navigationService.NavigateTo<BottomSheetVM, BottomSheetVMViewModel>();

    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        if (query.TryGetValue(nameof(IBottomSheet.SelectedSheetState), out var state))
		{
			SelectedState = (BottomSheetState)state;
		}
    }
}