namespace pushups.Views;

public partial class AllPushupsPage : ContentPage
{
    VerticalStackLayout stackLayout;

    public AllPushupsPage()
    {
        InitializeComponent();
        //stackLayout = myStackLayout;

        BindingContext = new Models.AllPushups();
    }

    protected override void OnAppearing()
    {
        ((Models.AllPushups)BindingContext).LoadPushups();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(PushupPage));
    }

    private async void pushupsCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var pushup = (Models.Pushup)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(PushupPage)}?{nameof(PushupPage.ItemId)}={pushup.Filename}");

            // Unselect the UI
            pushupsCollection.SelectedItem = null;
        }
    }
    /*
    private void AddItem(object sender, EventArgs e)
    {
        // Create a new Label
        Label dynamicLabel = new Label
        {
            Text = "Dynamically Created Label!",
            FontSize = 20
        };

        stackLayout.Children.Add(dynamicLabel);

    }*/


}