using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Practica_1_web.Application.DTOs;
using Practica_1_web.Application.Services;

namespace Practica_1_web.Pages.Telefonos
{
    public class DeleteModel : PageModel
    {
        private readonly TelefonoService _telefonoService;

        [BindProperty]
        public TelefonoDto TelefonoDto { get; set; } = new();

        public DeleteModel(TelefonoService telefonoService)
        {
            _telefonoService = telefonoService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var telefono = await _telefonoService.GetTelefonoByIdAsync(id);
            if (telefono == null)
            {
                return NotFound();
            }

            TelefonoDto = telefono;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            await _telefonoService.DeleteTelefonoAsync(TelefonoDto.Id);
            TempData["SuccessMessage"] = "El teléfono se eliminó correctamente.";
            return RedirectToPage("Index");
        }
    }
}
