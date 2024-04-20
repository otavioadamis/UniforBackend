﻿using Microsoft.AspNetCore.Mvc;
using UniforBackend.Domain.Interfaces.IServices;

namespace UniforBackend.API.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly IAuthorizationService _authorizationService;

        public AuthController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet("confirmar-email")]
        public ActionResult ConfirmarEmail(string userId, string codigoVerificacao)
        {
            var status = _authorizationService.ValidarEmail(userId, codigoVerificacao);
            if (status) { return Ok("Email verificado com sucesso!"); }
            else
            {
                return BadRequest("Falha na confirmação de email.");
            }
        }
    }
}
