using System;
using System.Collections.Generic;
using AutoMapper;
using WebApi.Base.Models;
using WebApi.Base.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.DTO;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IMapper _mapper;

        public IPessoaRepository _pessoaRepository { get; }

        public PessoaController(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            this._mapper = mapper;
        }

        [HttpGet]
        //[EnableQuery]
        public IActionResult Get(bool incluirInativo = false)
        {
            try
            {
                var pessoas = _mapper.Map<IEnumerable<PessoaDTO>>(_pessoaRepository.Get(incluirInativo));

                if (pessoas == null)
                    return NoContent();

                return Ok(pessoas);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{cpf}")]
        public IActionResult Get(string cpf)
        {
            try
            {
                var pessoa = _mapper.Map<PessoaDTO>(_pessoaRepository.Get(cpf));
                if (pessoa == null)
                    return NotFound($"Pessoa não encontrada para o CPF: {cpf}");

                return Ok(pessoa);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Adicionar(PessoaDTO dto)
        {
            try
            {
                var pessoa = _mapper.Map<Pessoa>(dto);
                _pessoaRepository.Adicionar(pessoa);
                return Ok(dto);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{cpf}")]
        public IActionResult Deletar(string cpf)
        {
            try
            {
                var pessoa = _pessoaRepository.Get(cpf);
                if (pessoa == null)
                    return NotFound($"Pessoa não encontrada para o CPF: {cpf}");

                _pessoaRepository.Deletar(pessoa);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Editar(PessoaDTO dto)
        {
            try
            {
                var id = _pessoaRepository.Get(dto.Cpf).Id;
                if (id <= 0)
                    return NotFound($"Pessoa não encontrada para o CPF: {dto.Cpf}");
                
                var pessoa = _mapper.Map<Pessoa>(dto);
                pessoa.Id = id;

                _pessoaRepository.Editar(pessoa);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}