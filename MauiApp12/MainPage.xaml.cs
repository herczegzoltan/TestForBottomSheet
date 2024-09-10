
using Maui.BottomSheet;
using Maui.BottomSheet.Navigation;
using Maui.BottomSheet.SheetBuilder;

namespace MauiApp12
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
 

        private void Button_Clicked(object sender, EventArgs e)
        {
            var service = this.Handler.MauiContext.Services.GetService<IBottomSheetNavigationService>();

            service.NavigateTo<BottomSheetVM, BottomSheetVMViewModel>();
        }
    }
}
