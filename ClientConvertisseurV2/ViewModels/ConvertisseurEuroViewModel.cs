using ClientConvertisseurV2.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientConvertisseurV2.ViewModels
{
    public class ConvertisseurEuroViewModel : ObservableObject
    {

        private ObservableCollection<Devise> devises;
        public ObservableCollection<Devise> Devises
        {
            get { return this.devises; }
            set
            {
                this.devises = value;
                OnPropertyChanged();

            }
        }

        private double montantDevise;
        public double MontantDevise
        {

            get { return this.montantDevise; }
            set
            {
                this.montantDevise = value;
                OnPropertyChanged();
            }
        }

        private double montantEuro;
        public double MontantEuro
        {
            get { return this.montantEuro; }
            set
            {
                this.montantEuro = value;
                OnPropertyChanged();
            }
        }

        private Devise selectedDevise;
        public Devise SelectedDevise { }

        private async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("http://localhost:5235/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)

                await ShowError("erreur non !", "erreur la team");

            else
                Devises = new ObservableCollection<Devise>(result);
        }

        private async Task ShowError(string v1, string v2)
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = v2,
                Content = v1,
                CloseButtonText = "Ok"
            };

            await noWifiDialog.ShowAsync();
        }

        public IRelayCommand BtnSetConversion { get; }
        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }
        private void ActionSetConversion()
        {
            MontantDevise = MontantEuro * ;
        }
    }
}
