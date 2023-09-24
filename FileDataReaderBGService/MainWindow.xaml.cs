using FileDataReaderBGService.Repositories;
using FileDataReaderBGService.Services;

using Microsoft.Extensions.Hosting;

using System;
using System.Linq;
using System.Windows;


namespace FileDataReaderBGService
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ELDEventsBGService _ELDEventsService;
        private readonly ELDEventsRepository _eLDEventsRepository;
        private readonly ELDEventsServerRepository _eLDEventsServerRepository;

        private string Service_Status = "Service Status: {0}";

        public MainWindow()
        {
            InitializeComponent();

            _ELDEventsService = (ELDEventsBGService)AppDI.GetRequiredService<IHostedService>();

            _ELDEventsService.OnELDEventsInserted += OnELDEventsInserted;

            _eLDEventsRepository = AppDI.GetRequiredService<ELDEventsRepository>();
            _eLDEventsServerRepository = AppDI.GetRequiredService<ELDEventsServerRepository>();

            ControlTab.SelectionChanged += TabSelectionChanged;

            UpdateServiceStatus();
        }

        private void TabSelectionChanged(object sender, RoutedEventArgs e)
        {
            if (ELDEventsTab.IsSelected)
            {
                GetELDEvents();
            }
            if (ELDEventsServerTab.IsSelected)
            {
                GetELDEventsServer();
            }
        }

        private void GetELDEvents()
        {
            ELDEventsDG.ItemsSource = _eLDEventsRepository.GetAllELDEvents().ToList();
        }

        private void GetELDEventsServer()
        {
            ELDEventsServerDG.ItemsSource = _eLDEventsServerRepository.GetAllELDEvents().ToList();
        }

        private async void StartService(object s, RoutedEventArgs e)
        {
            // To avoid multiple clicks
            if (!_ELDEventsService.IsRunning)
            {
                await AppDI.StartHostedService();
                UpdateServiceStatus();
            }
        }

        private void UpdateServiceStatus()
        {
            ServiceStatus.Text = string.Format(Service_Status, _ELDEventsService.IsRunning);
        }

        public async void OnELDEventsInserted(object? sender, EventArgs e)
        {
            MessageBox.Show("Successfully extracted data from the file and inserted into the DataBase");
        }
    }
}
