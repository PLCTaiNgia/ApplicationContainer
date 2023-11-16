using AppContainer.Models;
using CommunityToolkit.Maui.Core.Views;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Json;
using Container = AppContainer.Models.Container;

namespace AppContainer.Views;

public partial class HomePage : ContentPage
{
    List<Container> _containers, _containerShow;
    List<Oprld> _oprlds;
    List<SizeContainer> _sizecontainers;
    public HomePage()
    {
        InitializeComponent();
        LoadData();
        LoadCombo();
    }
    private async void LoadData()
    {
        var client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });

        var Json = await client.GetStringAsync($"{constants.URL}/Container");
        ResponeContainer res = JsonConvert.DeserializeObject<ResponeContainer>(Json);
        _containers = res.GetAllContainer();
        listContainer.ItemsSource = _containers;
    }

    private async void LoadCombo()
    {
        var client = new HttpClient(new HttpClientHandler()
        {
            ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
        });

        var JsonCat = await client.GetStringAsync($"{constants.URL}/Category");
        var JsonSize = await client.GetStringAsync($"{constants.URL}/Container/ListSize");

        OprIdRespone por = JsonConvert.DeserializeObject<OprIdRespone>(JsonCat);
        SizeRespone size = JsonConvert.DeserializeObject<SizeRespone>(JsonSize);

        _oprlds = por.Data;
        _sizecontainers = size.Data;
        ComboOprld.ItemsSource = _oprlds;
        ComboSize.ItemsSource = _sizecontainers;
    }

    //async void OnOpenWebButtonClicked(object sender, EventArgs e)
    //{
    //    await Shell.Current.GoToAsync(nameof(LoginPage));
    //}

    private async void listContainer_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(DetailPage)}",
            new Dictionary<string, object>
            {
                ["ContainerObj"] = (Container)listContainer.SelectedItem
            });
    }

    private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (labelMess.Opacity == 1)
            labelMess.Opacity = 0;

        var container = new ObservableCollection<Container>(ResponeContainer.SearchContainer((((SearchBar)sender).Text), _containers));
        listContainer.ItemsSource = container;
    }

    private void ComboOprld_SelectionChanged(object sender, EventArgs e)
    {
        if (labelMess.Opacity == 1)
            labelMess.Opacity = 0;

        Oprld sel = (Oprld)ComboOprld.SelectedItem;
        var container = ResponeContainer.SearchContainer((sel.OprId).ToString(), _containers);
        listContainer.ItemsSource = container;
        _containerShow = container;
    }

    private void ComboSize_SelectionChanged(object sender, EventArgs e)
    {
        if (_containerShow == null)
        {
            SizeContainer siz = (SizeContainer)ComboSize.SelectedItem;
            var container = ResponeContainer.SearchContainer((siz.Value).ToString(), _containers);
            listContainer.ItemsSource = container;
        }
        else
        {
            SizeContainer siz = (SizeContainer)ComboSize.SelectedItem;
            var container = ResponeContainer.SearchContainer((siz.Value).ToString(), _containerShow);
            if(container.Count == 0 || container == null)
            {
                listContainer.ItemsSource = container;
                labelMess.Opacity = 1;
            }
            else
            {
                labelMess.Opacity = 0;
                listContainer.ItemsSource = container;
            }
        }
    }
}