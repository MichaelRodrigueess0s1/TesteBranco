using Prism.Commands;
using Prism.Mvvm;
using System;
using Prism.Navigation;
using System.Collections.Generic;
using System.Linq;
using TesteBranco.Models;

namespace TesteBranco.ViewModels
{
	public class DetalheProfissionalViewModel : BindableBase, INavigatedAware
	{
        private Profissional _profissional ;

        public Profissional Prof
        {
            get { return _profissional; }
            set { SetProperty(ref _profissional, value); }
        }

        public DetalheProfissionalViewModel()
        {

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if(parameters.ContainsKey("Profissional"))
            {
                Prof = parameters.GetValue<Profissional>("Profissional");
            }
        } 
    }
}
