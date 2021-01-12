using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PDV.DataBase.Negocio;
using PDV.DataBase.Objetos;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PDV.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string usuario { get; set; }

        [BindProperty]
        public string senha { get; set; }

        /*private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }*/

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            UsuarioN unegocio = new UsuarioN();
            bool validaSenha = unegocio.ValidarSenha(new Usuario() { ds_login = this.usuario, ds_senha = this.senha });

            if (validaSenha)
            {
                var claims = new List<Claim>
                {
                   new Claim(ClaimTypes.Name, usuario)
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var props = new AuthenticationProperties();

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                return RedirectToPage("/Cadastros/Cliente/Listagem");
            }
            else
                return Page();
        }

        public async Task<IActionResult> OnGetLogount()
        {
            await HttpContext.SignOutAsync();
            return RedirectToPage();
        }
    }
}
