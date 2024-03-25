using Fichier.Model;
using Fichier.ViewModel;

namespace Fichier;

public partial class ListePage : ContentPage
{
	public ListePage()
	{
		InitializeComponent();
        LstCitations.ItemsSource = (Application.Current as App)?.Citations;
    } 
}