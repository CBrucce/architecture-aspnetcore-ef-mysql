using ArchitectureAspNetCoreEFMySQL.Core.Domain.Entities;
using ArchitectureAspNetCoreEFMySQL.Core.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ArchitectureAspNetCoreEFMySQL.Web.Controllers
{
    public class CarrosController : Controller
    {
        ICarros _carro;

        public CarrosController(ICarros carro)
        {
            _carro = carro;
        }

        /// <summary>
        /// GET: Carros
        /// </summary>
        public async Task<IActionResult> Index()
        {
            return View(await _carro.GetAllAsync());
        }

        /// <summary>
        /// GET: Carros/Detalhes/5
        /// </summary>
        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _carro.GetByIdAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        /// <summary>
        /// GET: Carros/Criar
        /// </summary>
        public IActionResult Criar()
        {
            return View();
        }

        /// <summary>
        /// POST: Carros/Criar
        /// Para proteger contra ataques de overposting, ative as propriedades específicas às quais você deseja se vincular. 
        /// Detalhes em http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Criar([Bind("Id,Marca,Modelo,Cor,AnoModelo,AnoFabricacao")] Carro carro)
        {
            if (ModelState.IsValid)
            {
                await _carro.Add(carro);
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        /// <summary>
        /// GET: Carros/Editar/5
        /// </summary>
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _carro.GetByIdAsync(id);
            if (carro == null)
            {
                return NotFound();
            }
            return View(carro);
        }

        /// <summary>
        /// POST: Carros/Editar/5
        /// Para proteger contra ataques de overposting, ative as propriedades específicas às quais você deseja se vincular. 
        /// Detalhes em http://go.microsoft.com/fwlink/?LinkId=317598.
        /// </summary>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, [Bind("Id,Marca,Modelo,Cor,AnoModelo,AnoFabricacao")] Carro carro)
        {
            if (id != carro.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _carro.Edit(carro);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_carro.Exists(carro.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carro);
        }

        /// <summary>
        /// GET: Carros/Excluir/5
        /// </summary>
        public async Task<IActionResult> Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carro = await _carro.GetByIdAsync(id);
            if (carro == null)
            {
                return NotFound();
            }

            return View(carro);
        }

        /// <summary>
        /// POST: Carros/Excluir/5
        /// </summary>
        [HttpPost, ActionName("Excluir")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirConfirmed(int id)
        {
            await _carro.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
