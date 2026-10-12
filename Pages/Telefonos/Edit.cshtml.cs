using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Services;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Practica_1_web.Pages.Telefonos
{
    public class EditModel : PageModel
    {
        private readonly TelefonoService _telefonoService;

        [BindProperty]
        public TelefonoDto TelefonoDto { get; set; } = new();

        public SelectList Clientes { get; set; } = new(Enumerable.Empty<SelectListItem>());

        private readonly ClienteService _clienteService;

        public EditModel(TelefonoService telefonoService, ClienteService clienteService)
        {
            _telefonoService = telefonoService;
            _clienteService = clienteService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var telefono = await _telefonoService.GetTelefonoByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            TelefonoDto = telefono;
            await CargarClientesAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await CargarClientesAsync();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (!Clientes.Any(item => item.Value == TelefonoDto.ClienteId.ToString()))
            {
                ModelState.AddModelError("TelefonoDto.ClienteId", "Seleccione un cliente válido.");
                return Page();
            }

            await _telefonoService.UpdateTelefonoAsync(TelefonoDto);
            TempData["SuccessMessage"] = "El teléfono se actualizó correctamente.";
            return RedirectToPage("Index");
        }

        private async Task CargarClientesAsync()
        {
            var clientes = await _clienteService.GetAllClientesAsync();
            Clientes = new SelectList(clientes, nameof(ClienteDto.Id), nameof(ClienteDto.Nombre));
        }
    }
}
