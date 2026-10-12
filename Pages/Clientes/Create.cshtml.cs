using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Services;

namespace Practica_1_web.Pages.Clientes
{
    public class CreateModel : PageModel
    {
        private readonly ClienteService _clienteService;

        [BindProperty]
        public ClienteDto ClienteDto { get; set; } = new();

        public CreateModel(ClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _clienteService.CreateClienteAsync(ClienteDto);
            TempData["SuccessMessage"] = "El cliente se creó correctamente.";
            return RedirectToPage("Index");
        }
    }
}
