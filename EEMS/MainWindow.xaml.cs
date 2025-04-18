using EEMS.UI.Views.Employees;
using EEMS.UI.Views.Shared;
using EEMS.UI.ViewModels;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using EEMS.UI.Views.Condidates;
using System.Windows.Controls;
using System.Windows.Media;


namespace EEMS;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly INavigationService _navigationService;
    public MainWindow(INavigationService navigationService)
    {
        InitializeComponent();
        _navigationService = navigationService;
        _navigationService.SetFrame(MainFrame);
        DataContext = new MainWindowViewModel();

    }

    private void Border_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left) this.DragMove();
    }

    private bool IsMaximized = false;
    private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ClickCount == 2)
        {
            if (IsMaximized)
            {
                this.WindowState = WindowState.Normal;
                IsMaximized = false;
            }
            else
            {
                this.WindowState = WindowState.Maximized;
                IsMaximized = true;
            }
        }
    }

    private void btnExit_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }

    private void btnMinimize_Click(object sender, RoutedEventArgs e)
    {
        this.WindowState = WindowState.Minimized;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        // Condidates button

        _navigationService.NavigateTo<CondidatesPage>();
        if (sender is Button btn)
        {
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6895ff"));
            btn.Foreground = Brushes.White;
        }
        btnEmployees.Background = Brushes.Transparent;
        btnEmployees.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnProjects.Background = Brushes.Transparent;// transparent white
        btnProjects.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnSalary.Background = Brushes.Transparent; // transparent white
        btnSalary.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnDashboard.Background = Brushes.Transparent; // transparent white
        btnDashboard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        // Employees Button#
        _navigationService.NavigateTo<EmployeePage>();
        if (sender is Button btn)
        {
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6895ff"));
            btn.Foreground = Brushes.White;
        }
        btnProjects.Background = Brushes.Transparent;// transparent white
        btnProjects.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnCondidates.Background = Brushes.Transparent; // transparent white
        btnCondidates.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnSalary.Background = Brushes.Transparent; // transparent white
        btnSalary.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnDashboard.Background = Brushes.Transparent; // transparent white
        btnDashboard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
    }

    private void Button_Click_2(object sender, RoutedEventArgs e)
    {

    }

    private void Button_Click_3(object sender, RoutedEventArgs e)
    {
        // Dashboard Button
        if (sender is Button btn)
        {
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6895ff"));
            btn.Foreground = Brushes.White;
        }
        btnEmployees.Background = Brushes.Transparent;// transparent white
        btnEmployees.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnCondidates.Background = Brushes.Transparent; // transparent white
        btnCondidates.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnProjects.Background = Brushes.Transparent; // transparent white
        btnProjects.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnSalary.Background = Brushes.Transparent; // transparent white
        btnSalary.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
    }

    private void Button_Click_4(object sender, RoutedEventArgs e)
    {
        // Salary Button
        if (sender is Button btn)
        {
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6895ff"));
            btn.Foreground = Brushes.White;
        }
        btnEmployees.Background = Brushes.Transparent;// transparent white
        btnEmployees.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnCondidates.Background = Brushes.Transparent; // transparent white
        btnCondidates.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnProjects.Background = Brushes.Transparent; // transparent white
        btnProjects.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnDashboard.Background = Brushes.Transparent; // transparent white
        btnDashboard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
    }

    private void Button_Click_5(object sender, RoutedEventArgs e)
    {
        // Projects Button
        if (sender is Button btn)
        {
            btn.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#6895ff"));
            btn.Foreground = Brushes.White;
        }
        btnEmployees.Background = Brushes.Transparent;// transparent white
        btnEmployees.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnCondidates.Background = Brushes.Transparent; // transparent white
        btnCondidates.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnSalary.Background = Brushes.Transparent; // transparent white
        btnSalary.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
        btnDashboard.Background = Brushes.Transparent; // transparent white
        btnDashboard.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD9E4FF"));
    }
}
