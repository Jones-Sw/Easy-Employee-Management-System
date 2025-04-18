﻿using EEMS.BusinessLogic.Interfaces;
using EEMS.BusinessLogic.Services;
using EEMS.DataAccess;
using EEMS.UI.UserControls;
using EEMS.UI.ViewModels;
using EEMS.UI.Views.Condidates;
using EEMS.UI.Views.Employees;
using EEMS.UI.Views.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace EEMS;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var service = new ServiceCollection();
        ConfigureServices(service);

        // Build the service provider
        ServiceProvider = service.BuildServiceProvider();

        // Show the main window
        var mainWindow = ServiceProvider.GetRequiredService<Func<MainWindow>>()();
        mainWindow.Show();
    }

    private void ConfigureServices(ServiceCollection service)
    {
        // Register DbContext
        service.AddDbContext<EEMSDbContext>(options =>
            options.UseSqlServer(ConfigHelper.GetConnectionString()));

        // Register services
        service.AddTransient<IEmployeeService, EmployeeService>();
        service.AddTransient<ICondidatesService, CondidateService>();
        service.AddTransient<IDepartmentService, DepartmentService>();
        service.AddTransient<IJobNatureService, JobNatureService>();
        service.AddTransient<IEmployeeManagementService, EmployeeManagementService>();
        service.AddTransient<ICondidateManagementService, CondidateManagementService>();
        // Register ViewModels
        service.AddTransient<EmployeeViewModel>();
        service.AddTransient<PersonalInformationViewModel>();
        service.AddTransient<JobInformationViewModel>();
        service.AddTransient<AddAndEditWindowViewModel>();
        service.AddTransient<CondidatesViewModel>();

        // Register pages
        service.AddTransient<EmployeePage>();
        service.AddTransient<CondidatesPage>();

        //Resigter User Control
        service.AddTransient<PersonalInformationUserControl>();


        //Register Views
        service.AddTransient<MainWindow>();
        service.AddTransient<AddAndEditWindow>();

        // Register Navigation Service
        service.AddTransient<INavigationService, NavigationService>();

        // Resiter main window
        service.AddTransient<Func<MainWindow>>(serviceProvider =>
            () => new MainWindow(serviceProvider.GetRequiredService<INavigationService>()));

    }
}

