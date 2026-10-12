using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Services;

namespace Practica_1_web.Pages.Clientes
{
    public class IndexModel : PageModel
    {
        private readonly ClienteService _clienteService;

        public List<ClienteDto> Clientes { get; set; } = new();

        public IndexModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task OnGetAsync()
        {
            Clientes = await _clienteService.GetAllClientesAsync();
        }
    }
}
