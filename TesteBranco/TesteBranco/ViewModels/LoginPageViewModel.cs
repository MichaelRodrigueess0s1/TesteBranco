using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using TesteBranco.Infrastructure.Constants;
using TesteBranco.Models;
using TesteBranco.Services.Interface;
using TesteBranco.Services.Services;
using SQLiteDataBase.Repository;
using SQLiteDataBase.Models;

namespace TesteBranco.ViewModels
{
    public class LoginPageViewModel : ViewModelBase
    {
        public DelegateCommand GerarTokenCommand { get; }
        

        private IAccessControlService AccessControlService;
        private IPageDialogService DialogService;
        private Repository<Usuario> Repository;
        

        private UsuarioDTO userLogin;

        public UsuarioDTO UserLogin
        {
            get { return userLogin; }
            set { SetProperty(ref userLogin, value); }
        }

        public LoginPageViewModel(INavigationService navigationService, IPageDialogService dialogService) : base(navigationService)
        {
            UserLogin = new UsuarioDTO();
            //Repository = new Repository<Usuario>();

            GerarTokenCommand = new DelegateCommand(GenerateToken);
            AccessControlService = new AccessControlService();
            DialogService = dialogService;
        }

        //private bool CanExecuteGenerateToken()
        //{
        //    return !(string.IsNullOrEmpty(UserLogin.Login) || string.IsNullOrEmpty(UserLogin.Senha));
        //}

        private async void GenerateToken()
        {

            //await DialogService.DisplayAlertAsync("Sucesso", "Acesso Autorizado", "Ok");


            var retorno = await AccessControlService.Autenticar(UserLogin);

            if (retorno.IsSuccess)
            {
              //  await DialogService.DisplayAlertAsync("Sucesso", "Acesso Autorizado", "Ok");
                UserLogin = retorno.Content;
                await NavigationService.NavigateAsync(BaseAppPageLinks.InicialPage);
            }
            else
            {
                await DialogService.DisplayAlertAsync("Negado", retorno.Message, "Ok");
            }
        }
    }
}
