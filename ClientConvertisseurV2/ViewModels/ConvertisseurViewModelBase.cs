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
    public abstract class ConvertisseurViewModelBase : ObservableObject
    {
        public IRelayCommand BtnSetConversion { get; }

        protected abstract string ApiEndpoint { get; }

        protected ObservableCollection<Devise> devises;
        public ObservableCollection<Devise> Devises
        {
            get { return this.devises; }
            set
            {
                this.devises = value;
                OnPropertyChanged();
            }
        }

        protected double montantDevise;
        public double MontantDevise
        {
            get { return this.montantDevise; }
            set
            {
                this.montantDevise = value;
                OnPropertyChanged();
            }
        }

        protected double montantEuro;
        public double MontantEuro
        {
            get { return this.montantEuro; }
            set
            {
                this.montantEuro = value;
                OnPropertyChanged();
            }
        }

        protected Devise selectedDevise;
        public Devise SelectedDevise
        {
            get { return this.selectedDevise; }
            set
            {
                this.selectedDevise = value;
                OnPropertyChanged();
            }
        }

        protected ConvertisseurViewModelBase()
        {
            BtnSetConversion = new RelayCommand(ActionSetConversion);
            GetDataOnLoadAsync();
        }

        protected async void GetDataOnLoadAsync()
        {
            WSService service = new WSService("http://localhost:5235/api/");
            List<Devise> result = await service.GetDevisesAsync(ApiEndpoint);

            if (result == null)
                await MessageAsync("API non disponible !", "Erreur");
            else
            {
                Devises = new ObservableCollection<Devise>(result);
                SelectedDevise = Devises.Count > 0 ? Devises[0] : null;
            }
        }

        protected async Task MessageAsync(string message, string titre)
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

        protected abstract void ActionSetConversion();
    }
}
