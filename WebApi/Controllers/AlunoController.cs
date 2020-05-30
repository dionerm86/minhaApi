using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using WebApi.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Model;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        DataContext _context { get; }

    public AlunoController(DataContext context)
    {
        _context = context;
    }

        [HttpGet]
        public async Task<IActionResult> Get () //Task informa a necessidade de abrir uma nova thread a cada requisição
        {

            try
            {
                var results = await _context.Aluno.ToListAsync();
                
                return Ok(results);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco de dados");
            }            
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Aluno>> Get (int id) {

            try
            {
                var result = await _context.Aluno.FirstOrDefaultAsync(x => x.AlunoId == id);
                
                return Ok(result);
            }
            catch(System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Erro no banco de dados");
            }            
        }        
    }
}