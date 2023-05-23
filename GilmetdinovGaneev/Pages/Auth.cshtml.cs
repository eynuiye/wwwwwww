using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using System;
using GilmetdinovGaneev.Models;
using Microsoft.AspNetCore.Authentication;

namespace GilmetdinovGaneev.Pages
{
    public class AuthModel : PageModel
    {
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string? returnUrl)
        {
            // �������� �� ����� email � ������
            var form = HttpContext.Request.Form;
            // ���� email �/��� ������ �� �����������, �������� ��������� ��� ������ 400
            if (!form.ContainsKey("login") || !form.ContainsKey("password"))
                return BadRequest("Email �/��� ������ �� �����������");

            string login = form["login"];
            string password = form["password"];

            var db = new MydbContext(); 
            // ������� ������������ 
            Worker? worker = db.Workers.FirstOrDefault(w => w.Login == login && w.Password == password);
            // ���� ������������ �� ������, ���������� ��������� ��� 401
            if (worker is null) return Unauthorized();

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, worker.Login) };
            // ������� ������ ClaimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "Cookies");
            // ��������� ������������������ ����
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));
            return Redirect(returnUrl ?? "/");
        }
    }
}
