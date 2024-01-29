using ClientConvertisseurV1.Models;
using ClientConvertisseurV1.Services;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace ClientConvertisseurV1.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ConvertisseurEuroPage : Page, INotifyPropertyChanged
    {


        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private ObservableCollection<Devise> devises;
        public ObservableCollection<Devise> Devises
        {
            get { return this.devises; }
            set
            {
                this.devises = value;
                OnPropertyChanged(nameof(Devises));

            }
        }

        private double montantDevise;
        public double MontantDevise { 
            
            get { return this.montantDevise; } 
            set {
                this.montantDevise = value;
                OnPropertyChanged(nameof(MontantDevise));
            } 
        }

        private double montantEuro;
        public double MontantEuro
        {
            get { return this.montantEuro; }
            set
            {
                this.montantEuro = value;
                OnPropertyChanged(nameof(montantEuro));
            }
        }

        public ConvertisseurEuroPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
            GetDataOnLoadAsync();
        }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("http://localhost:5235/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)

                throw new ArgumentException("API indisponible !");

            else
                Devises = new ObservableCollection<Devise>(result);
        }

        private void MessageAsync(string v1, string v2)
        {
            throw new NotImplementedException();
        }

        private void ConvertirBt_Click(object sender, RoutedEventArgs e)
        {
            Devise d = (Devise)DeviseCb.SelectedItem;
            if (d == null)
            {
                throw new ArgumentException("Tas pas mis la devise");
            }
            MontantDevise = d.Taux * MontantEuro;
        }

    }
}
