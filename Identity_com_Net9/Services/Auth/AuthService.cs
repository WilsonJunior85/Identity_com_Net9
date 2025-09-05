using Identity_com_Net9.Dto;
using Identity_com_Net9.Models;
using Microsoft.AspNetCore.Identity;

namespace Identity_com_Net9.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<ResultModel<string>> Register(RegisterDto registerDto)
        {

            ResultModel<string> result = new ResultModel<string>();

            try
            {
                var user = new ApplicationUser
                {
                    Email = registerDto.Email,
                    NomeCompleto = registerDto.NomeCompleto,
                    UserName = registerDto.Usuario
                };

                var resultado = await _userManager.CreateAsync(user, registerDto.Senha);

                if (!resultado.Succeeded) 
                {
                    result.Data = string.Join(",", resultado.Errors.Select( e => e.Description));
                    result.Status = false;
                    return result;
                }

                var rolesInvalidas = new List<string>();
                foreach (var role in registerDto.Roles) 
                { 
                  if(!await _roleManager.RoleExistsAsync(role))
                    {
                        rolesInvalidas.Add(role);
                    }
                }

                if (rolesInvalidas.Any())
                {
                    result.Data = $"As seguintes roles não existem: {string.Join(", ", rolesInvalidas)}";
                    result.Status = false;
                    return result;
                }

                foreach (var role in registerDto.Roles) 
                { 
                  
                   await _userManager.AddToRoleAsync(user, role);
                
                }


                result.Mensagem = "Usuário cadastrado com sucesso";
                return result;

            }
            catch (Exception ex) 
            { 
                result.Mensagem = ex.Message;
                result.Status = false;
                return result;
            }
        }
    }
}
