using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Services;

namespace Practica_1_web.Pages.Telefonos
{
    public class IndexModel : PageModel
    {
        private readonly TelefonoService _telefonoService;

        public List<TelefonoDto> Telefonos { get; set; } = new();

        public IndexModel(TelefonoService telefonoService)
        {
            _telefonoService = telefonoService;
        }

        public async Task OnGetAsync()
        {
            Telefonos = await _telefonoService.GetAllTelefonosAsync();
        }
    }
}
