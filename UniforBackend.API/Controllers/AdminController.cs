﻿using Microsoft.AspNetCore.Mvc;
using UniforBackend.API.Authorization;
using UniforBackend.Domain.Interfaces.IServices;
using UniforBackend.Domain.Models.DTOs.AdminTOs;
using UniforBackend.Domain.Models.DTOs.ItemTOs;
using UniforBackend.Domain.Models.DTOs.PageTOs;
using UniforBackend.Domain.Models.enums;

namespace UniforBackend.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [CustomAuthorize(Role.Admin)]
        [HttpPost("avaliar")]
        public async Task<IActionResult> AvaliarItem(AvaliarItemDTO avaliacao)
        {
            await _adminService.AvaliarItem(avaliacao);
            return Ok();
        }

        [CustomAuthorize(Role.Admin)]
        [HttpDelete("delete/{itemId}")]
        public async Task<IActionResult> DeleteItem(string itemId)
        {
            await _adminService.DeleteItem(itemId);
            return Ok();
        }

        [CustomAuthorize(Role.Admin)]
        [HttpGet("{pagina}")]
        public ActionResult<PagedResult<ItemReviewDTO>> GetUnauthorizedFromPagina(int pagina = 1, int pageSize = 10)
        {
            if (pagina < 1) { pagina = 1; }
            var response = _adminService.GetAllUnauthorized(pagina, pageSize);
            return Ok(response);
        }
    }
}
