namespace pushups.Views;

[QueryProperty(nameof(ItemId), nameof(ItemId))]
public partial class PushupPage : ContentPage
{
    public string ItemId
    {
        set { LoadPushup(value); }
    }

    public PushupPage()
    {
        InitializeComponent();

        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.pushups.txt";

        LoadPushup(Path.Combine(appDataPath, randomFileName));
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Pushup pushup)
            File.WriteAllText(pushup.Filename, TextEditor.Text);

        await Shell.Current.GoToAsync("..");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Pushup pushup)
        {
            // Delete the file.
            if (File.Exists(pushup.Filename))
                File.Delete(pushup.Filename);
        }

        await Shell.Current.GoToAsync("..");
    }

    private void LoadPushup(string fileName)
    {
        Models.Pushup pushupModel = new Models.Pushup();
        pushupModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            pushupModel.Date = File.GetCreationTime(fileName);
            pushupModel.PushupAmount = Int32.Parse(File.ReadAllText(fileName));
        }

        BindingContext = pushupModel;
    }
}