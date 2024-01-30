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
        public IRelayCommand BtnSetConversion { get; }
        public ConvertisseurEuroViewModel()
        {
            GetDataOnLoadAsync();
            BtnSetConversion = new RelayCommand(ActionSetConversion);
        }

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
        public Devise SelectedDevise {
            get { return this.selectedDevise;  }
            set { 
                this.selectedDevise = value; 
                OnPropertyChanged();
            }
        }

        public async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("http://localhost:5235/api/");
            List<Devise> result = await service.GetDevisesAsync("devises");
            if (result == null)

                await MessageAsync("API non disponible !", "Erreur");

            else
            {
                Devises = new ObservableCollection<Devise>(result);
                SelectedDevise = Devises[0];
            }
        }


        private async Task MessageAsync(string message, string titre)
        {
            ContentDialog contentDialog = new ContentDialog
            {
                Title = titre,
                Content = message,
                CloseButtonText = "Ok"
            };
            contentDialog.XamlRoot = App.MainRoot.XamlRoot;
            await contentDialog.ShowAsync();
        }


        public async void ActionSetConversion()
        {
            if(SelectedDevise is null)
            {
                await MessageAsync("Tu n'as pas séléctionné de devise", "Erreur");
            }
            MontantDevise = MontantEuro * SelectedDevise.Taux ;
        }
    }
}
