namespace MauiLabelBroken;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        this.BindingContext = this;
    }
    private List<ChargeSite> chargeSites;

    public List<ChargeSite> ChargeSites
    {
        get { return chargeSites; }
        set { chargeSites = value; OnPropertyChanged(); }
    }

    private bool isBusy;

    public bool IsBusy
    {
        get { return isBusy; }
        set { isBusy = value; OnPropertyChanged(); }
    }


    private void RefreshView_Refreshing(object sender, EventArgs e)
    {
        IsBusy = true;
        ChargeSites = null;

        Task.Run(GetChargeSites);
    }

    private void GetChargeSites()
    {
        IsBusy = false;
        Random rd = new Random();
        var list = new List<ChargeSite>();
        for (int i = 1; i < 100; i++)
            list.Add(new ChargeSite() { DetailText = "dotnet bot", TitleText = $"No.{rd.Next(1, 20)} Place", StateText = $"{rd.Next(1, 200)} Available", Distance = "Unknown" });
        ChargeSites = list;
    }

    private void ContentPage_Loaded(object sender, EventArgs e)
    {
        IsBusy = true;
        ChargeSites = null;

        Task.Run(GetChargeSites);
    }

    public class ChargeSite
    {
        public string Rid { get; set; }
        public string TitleText { get; set; }
        public string Distance { get; set; }
        public string DetailText { get; set; }
        public string StateText { get; set; }
    }
}

