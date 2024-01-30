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
    public class ConvertisseurDeviseViewModel : ConvertisseurViewModelBase
    {
        protected override string ApiEndpoint => "devises";

        protected override void ActionSetConversion()
        {
            if (SelectedDevise is null)
            {
                MessageAsync("Tu n'as pas sélectionné de devise", "Erreur").Wait();
            }
            MontantEuro = MontantDevise / (SelectedDevise?.Taux ?? 0);
        }
    }
}
