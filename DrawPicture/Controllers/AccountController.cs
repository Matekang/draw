using DrawPicture.Models;
using DrawPicture.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace DrawPicture.Controllers;


public class AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager) : Controller
{
    public IActionResult Login(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginVM model, string? returnUrl = "/HomeDraw/Index")
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            //login
            var result = await signInManager.PasswordSignInAsync(model.Username!, model.Password!, model.RememberMe, false);

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }

            ModelState.AddModelError("", "Invalid login attempt");
        }
        return View(model);
    }

    public IActionResult Register(string? returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterVM model, string? returnUrl = "/HomeDraw/Index")
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            AppUser user = new()
            {
                Name = model.Name,
                UserName = model.Username,
                Class = model.Class
            };

            var result = await userManager.CreateAsync(user, model.Password!);

            if (result.Succeeded)
            {
                string role = model.Username.EndsWith("@teacher") ? "Teacher" : "";
                if(role == "Teacher")
                {
                    await userManager.AddToRoleAsync(user, role);
                }

                await signInManager.SignInAsync(user, false);

                return RedirectToLocal(returnUrl);
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }

    private IActionResult RedirectToLocal(string? returnUrl)
    {
        return !string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)
            ? Redirect(returnUrl)
            : RedirectToAction(nameof(HomeController.Index), nameof(HomeController));
    }

    [HttpGet]
    public async Task<IActionResult> EditProfile()
    {
        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var model = new UpdateProfileViewModel
        {
            Name = user.Name,
            Class = user.Class,
            User = user.UserName,
        };

        return View(model);
    }


    [HttpPost]
    public async Task<IActionResult> EditProfile(UpdateProfileViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }


        user.Name = model.Name;
        user.Class = model.Class;
        user.UserName = model.User;

        if (user.Name != model.Name)
        {
            var setEmailResult = await userManager.SetEmailAsync(user, model.Name);
            if (!setEmailResult.Succeeded)
            {
                foreach (var error in setEmailResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
        }

        var result = await userManager.UpdateAsync(user);
        if (result.Succeeded)
        {
            TempData["Message"] = "Cập nhật thông tin thành công.";
            TempData["AlertType"] = "success";
            return RedirectToAction("EditProfile");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }


    public IActionResult ChangePassword()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        var user = await userManager.GetUserAsync(User);
        if (user == null)
        {
            return NotFound("User not found.");
        }

        var changePasswordResult = await userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
        if (changePasswordResult.Succeeded)
        {
            await signInManager.RefreshSignInAsync(user);
            TempData["Message"] = "Thay đổi mật khẩu thành công.";
            TempData["AlertType"] = "success";
            return RedirectToAction("ChangePassword");
        }

        foreach (var error in changePasswordResult.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }

        return View(model);
    }

    [Authorize(Roles = "Teacher")]
    [HttpGet]
    public async Task<IActionResult> GetAllUsers(int page = 1, int pageSize = 10)
    {
        var userDetail = await userManager.GetUserAsync(User);
        var users = userManager.Users.Where(i => i.Class == userDetail.Class).ToList();

        var usersWithoutRoles = new List<AppUser>();

        foreach (var user in users)
        {
            var roles = await userManager.GetRolesAsync(user);
            if (roles == null || !roles.Any())
            {
                usersWithoutRoles.Add(user);
            }
        }

        // Phân trang
        var totalUsers = usersWithoutRoles.Count;
        var pagedUsers = usersWithoutRoles
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
        ViewBag.CurrentPage = page;

        return View(pagedUsers); 
    }

}

