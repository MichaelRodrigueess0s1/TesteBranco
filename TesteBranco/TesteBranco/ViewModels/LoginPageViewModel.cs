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
using TesteBranco.Models.Repository;
using TesteBranco.Models.UoW;


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

        private async void GenerateToken()
        {
            var retorno = await AccessControlService.Autenticar(UserLogin);

            if (retorno.IsSuccess)
            {            
                UserLogin = retorno.Content;
                Usuario usu = await _unitOfWork.RepositoryUsuario.AsyncTableQuery().Where(x => x.Cpf.Equals(UserLogin.Cpf)).FirstOrDefaultAsync();                
                if (usu == null)
                {
                    usu = new Usuario
                    {
                        AceitouTermo = true,
                        Cpf = UserLogin.Cpf,
                        DataTermo = true,
                        Doc = UserLogin.Doc,
                        IdToken = UserLogin.IdToken,
                        Matricula = UserLogin.Matricula,
                        Perfil = UserLogin.Perfil,
                        Status = UserLogin.Status,
                        Servico = UserLogin.Servico,
                        Login = UserLogin.Login,
                        Nome = UserLogin.Nome,
                        Senha = UserLogin.Senha
                    };

                    usu = await _unitOfWork.RepositoryUsuario.Insert(usu);
                }else
                {
                    int resp = await _unitOfWork.RepositoryUsuario.Update(usu);
                }             
                await NavigationService.NavigateAsync(BaseAppPageLinks.ProfissionaisPage);
            }
            else
            {
                await DialogService.DisplayAlertAsync("Negado", retorno.Message, "Ok");
            }
        }
    }
}
