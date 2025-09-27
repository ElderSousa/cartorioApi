
using ProjetoBase.DataBase.Dominio;
using System;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using WebApi.Models;
using WebApi.Data;

namespace WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/clientes")]
    public class ClientesController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetClientes([FromUri] string filtro = null)
        {
            try
            {
                using (var sessao = ApiSessionFactory.OpenSession())
                {
                    var query = sessao.Query<Cliente>();

                    if (!string.IsNullOrEmpty(filtro))
                    {
                        query = query.Where(c => c.Nome.Contains(filtro) ||
                                                 c.Cpf.Contains(filtro) ||
                                                 c.Cnpj.Contains(filtro) ||
                                                 c.Email.Contains(filtro));
                    }

                    var clientes = query.ToList();

                    var dtos = clientes.Select(c => new ClienteDto
                    {
                        Id = c.Id,
                        Nome = c.Nome,
                        Cpf = c.Cpf,
                        RazaoSocial = c.RazaoSocial,
                        Cnpj = c.Cnpj,
                        Email = c.Email,
                        Telefone = c.Telefone,
                        Observacoes = c.Observacoes
                    }).ToList();

                    return Ok(dtos);
                }
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpPut]
        [Route("{id:int}/observacoes")]
        public IHttpActionResult UpdateObservacoes(int id, [FromBody] ClienteUpdateDto updateDto)
        {
            if (updateDto == null)
            {
                return BadRequest("O corpo da requisição não pode ser nulo.");
            }

            try
            {
                using (var sessao = ApiSessionFactory.OpenSession())
                using (var transacao = sessao.BeginTransaction())
                {
                    var cliente = sessao.Get<Cliente>(id);

                    if (cliente == null)
                    {
                        return NotFound();
                    }

                    cliente.Observacoes = updateDto.Observacoes;
                    sessao.Update(cliente);
                    transacao.Commit();
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}
