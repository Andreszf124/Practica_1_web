using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Services;

namespace Practica_1_web.Pages.Clientes
{
    public class DeleteModel : PageModel
    {
        private readonly ClienteService _clienteService;

        [BindProperty]
        public ClienteDto ClienteDto { get; set; } = new();

        public DeleteModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var cliente = await _clienteService.GetClienteByIdAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            ClienteDto = cliente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _clienteService.DeleteClienteAsync(ClienteDto.Id);
            TempData["SuccessMessage"] = "El cliente se eliminó correctamente.";
            return RedirectToPage("Index");
        }
    }
}
