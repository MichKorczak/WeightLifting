using System;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Services.Services.Interfaces;
using WeightLifting.Controllers;

namespace WeightLifting.Extensions
{
    public static class UserExtention
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }

        public static string EmailConfirmationLink(this IUrlHelper helper, string userId, string code, string scheme ) => helper.Action(
                action: nameof(AccountController.ConfirmEmail),
                controller: $"Account",
                values: new { userId, code },
                protocol: scheme);


    }
}
