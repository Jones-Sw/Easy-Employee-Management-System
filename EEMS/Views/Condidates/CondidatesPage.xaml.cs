using EEMS.BusinessLogic.Services;
using EEMS.UI.ViewModels;
using System.Windows.Controls;
namespace EEMS.UI.Views.Condidates
{
    /// <summary>
    /// Interaction logic for CondidatesPage.xaml
    /// </summary>
    public partial class CondidatesPage : Page
    {
        public CondidatesPage(CondidatesViewModel condidatesViewModel)
        {
            InitializeComponent();
            DataContext = condidatesViewModel;

        }

      
    }
}
