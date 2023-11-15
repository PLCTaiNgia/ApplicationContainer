using AppContainer.Models;
using Container = AppContainer.Models.Container;

namespace AppContainer.Views;


[QueryProperty(nameof(ContainerId), "ContainerObj")]
public partial class DetailPage : ContentPage
{
    public Container ContainerId
    {
        set
        {
            imgContainer.Source = value.Thumbnail[0];
            imgContainer1.Source = value.Thumbnail[0];
            imgContainer2.Source = value.Thumbnail[1];
            imgContainer3.Source = value.Thumbnail[2];

            lableCntrNo.Text = lableCntrNo.Text + ": " + value.CntrNo;
            lableCntrSize.Text = lableCntrSize.Text + ": " + value.CntrSize;
            lableOprId.Text = lableOprId.Text + ": " + value.OprId;
            lableStatus.Text = lableStatus.Text + ": " + value.Status;
            lableCMStatus.Text = lableCMStatus.Text + ": " + value.CMStatus;
        }
        
        
    }

    public DetailPage()
	{
		InitializeComponent();
    }

    async void Button_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private void OnTapGestureRecognizerTapped(object sender, TappedEventArgs e)
    {
        imgContainer.Source = imgContainer1.Source;
    }

    private void OnTapGestureRecognizerTapped1(object sender, TappedEventArgs e)
    {
        imgContainer.Source = imgContainer2.Source;
    }

    private void OnTapGestureRecognizerTapped2(object sender, TappedEventArgs e)
    {
        imgContainer.Source = imgContainer3.Source;
    }
}