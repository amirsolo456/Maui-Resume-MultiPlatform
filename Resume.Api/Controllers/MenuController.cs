using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Resume.Application.Dtos;
using Resume.Application.Dtos.ApiBase;
using Resume.Application.Interfaces;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Resume.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        protected IMainMenuService _context;
        public MenuController(IMainMenuService mainMenu) => _context = mainMenu;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var menus = await _context.GetAllAsync();
            var response = new ApiResponse<IEnumerable<MainMenus>>(
                data: menus,
                success: true,
                message: "لیست منوها با موفقیت دریافت شد",
                totalCount: menus.Count()
            );
            return Ok(response);
        }

        // GET api/<MenuController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var menus = await _context.GetByIdAsync(id);
            var response = new ApiResponse<MainMenus>(
                    data: menus,
                    success: true,
                    message: "لیست منوها با موفقیت دریافت شد",
                    totalCount: null
            );
            return Ok(response);
        }

        // POST api/<MenuController>
        [HttpPost]
        public async Task<IActionResult> Create(MainMenus menu)
        {
            var created = await _context.CreateAsync(menu);
            return Ok(new ApiResponse<MainMenus>(created, true, "منو با موفقیت ایجاد شد"));
        }

        // PUT api/<MenuController>/5
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ApiRequest<MainMenus> request)
        {
            try
            {
                // توکن را بررسی کن
                if (string.IsNullOrEmpty(request.Token))
                    return Unauthorized(new ApiResponse<MainMenus?>(null, false, "توکن معتبر نیست"));

                var created = await _context.CreateAsync(request.Data);

                return Ok(new ApiResponse<MainMenus>(
                    created,
                    true,
                    "منو با موفقیت ایجاد شد"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<MainMenus?>(
                    null,
                    false,
                    $"خطا در ایجاد منو: {ex.Message}"
                ));
            }
        }

        // DELETE api/<MenuController>/5
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ApiRequest<IEnumerable<MainMenus>> request)
        {
            try
            {
                // توکن را بررسی کن
                if (string.IsNullOrEmpty(request.Token))
                    return Unauthorized(new ApiResponse<MainMenus?>(null, false, "توکن معتبر نیست"));

                 await _context.DeleteAsync(request.Data.ToList());

                return Ok(new ApiResponse<MainMenus>(
                    null,
                    true,
                    "منو با موفقیت ایجاد شد"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<MainMenus?>(
                    null,
                    false,
                    $"خطا در ایجاد منو: {ex.Message}"
                ));
            }
        }

        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ApiRequest<MainMenus> request)
        {
            try
            {
                // توکن را بررسی کن
                if (string.IsNullOrEmpty(request.Token))
                    return Unauthorized(new ApiResponse<MainMenus?>(null, false, "توکن معتبر نیست"));

                await _context.DeleteAsync(request.Data);

                return Ok(new ApiResponse<MainMenus>(
                    null,
                    true,
                    "منو با موفقیت ایجاد شد"
                ));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ApiResponse<MainMenus?>(
                    null,
                    false,
                    $"خطا در ایجاد منو: {ex.Message}"
                ));
            }
        }
    }
}
