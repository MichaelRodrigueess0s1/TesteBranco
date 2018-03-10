using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBranco.Models;
using Prism.Navigation;
using System.Windows.Input;

namespace TesteBranco.ViewModels
{
	public class ListaProfissionaisViewModel : ViewModelBase
    {
        private INavigationService _navigationService;
        public List<Profissional> _list;

        public ICommand LogarCommand { get; private set; }

        public DelegateCommand AdicionaProfissionalCommand { get; }


        public List<Profissional> Lista
        {
            get { return _list; }
            set { SetProperty(ref _list, value); }
        }


        public ListaProfissionaisViewModel(INavigationService navigationService) : base(navigationService)
        {
            _navigationService = navigationService;
            PopulaListaAsync();             
            ItemProfissionalCommand = new DelegateCommand<Profissional>(ItemProfissional);
            AdicionaProfissionalCommand = new DelegateCommand(NavegarAdicionarProfissionalCommand);
        }


        private async System.Threading.Tasks.Task PopulaListaAsync()
        {
            Lista = await _unitOfWork.RepositoryProfissional.Get();
        }
        

        /*Commands */
        public DelegateCommand<Profissional> ItemProfissionalCommand { get; set; }        
        private void ItemProfissional(Profissional profissional)
        {
            NavigationParameters param = new NavigationParameters();

            param.Add("Profissional", profissional);
            _navigationService.NavigateAsync("DetalheProfissional", param);
        }

        private  void NavegarAdicionarProfissionalCommand()
        {
            _navigationService.NavigateAsync("DetalheProfissional");
        }
        /*Commands */

    }
}
