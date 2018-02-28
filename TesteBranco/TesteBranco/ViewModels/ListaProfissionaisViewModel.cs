using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBranco.Models;
using Prism.Navigation;
namespace TesteBranco.ViewModels
{
	public class ListaProfissionaisViewModel : BindableBase
	{
        private INavigationService _navigationService;
        private List<Profissional> _list;

        public List<Profissional> Lista
        {
            get { return _list; }
            set { SetProperty(ref _list, value); }
        }


        public ListaProfissionaisViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            Lista = Util.GeraDados.GeradorProfissional();
            ItemProfissionalCommand = new DelegateCommand<Profissional>(ItemProfissional);
        }

        /*navegação */
        public DelegateCommand<Profissional> ItemProfissionalCommand { get; set; }

        private void ItemProfissional(Profissional profissional)
        {
            NavigationParameters param = new NavigationParameters();

            param.Add("Profissional", profissional);
            _navigationService.NavigateAsync("DetalheProfissional", param);
        }

    }
}
