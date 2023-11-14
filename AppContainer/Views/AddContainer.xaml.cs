using AppContainer.Models;

namespace AppContainer.Views;

public partial class AddContainer : ContentPage
{

    private Container ConNew;

	public AddContainer()
	{
		InitializeComponent();
	}


    private void Button_Clicked_1(object sender, EventArgs e)
    {
        //ConNew.CntrNo = EntryCntrNo.Text;
        //ConNew.CntrSize = EntryCntrSize.Text;
        //ConNew.OprId = EntryOprId.Text;
        //ConNew.Status = EntryStatus.Text;
        //ConNew.CMStatus = EntryCMStatus.Text;
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}