using Microsoft.AspNetCore.Mvc;
using SATScheduling.UI.MVC.Models;
using System.Diagnostics;

//Email - Step 2
using Microsoft.Extensions.Configuration;

using MimeKit;
using MailKit.Net.Smtp;

namespace SATScheduling.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //Email - Step 3
        private readonly IConfiguration _config;

        //Email - Step 4
        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;

            _config = config;
        }


        public IActionResult Contact()
        {
            return View();
        }

        //Email - Step 9 
        //Code the POST Contact Action 

        //When the user submits the form, the form data will be sent to the POST action for Contact 
        //To ensure we can accept all of the info from the Model, we must include a param of type ContactViewModel 
        [HttpPost]
        public IActionResult Contact(ContactViewModel cvm)
        {
            //When processing form data in a post action, ALWAYS check validation FIRST
            if (!ModelState.IsValid)//if ModelState IS NOT valid is how to read this 
            {
                //Send them back to the form with error messages to let them know what to fix.
                //Those error messages are populated in the <span> tags in the View - and this happens auto-matically
                //because our view is bound to our model 
                return View(cvm);
            }

            //If we make it here, validation has been passed and we can process sending the email 
            //First, we'll need another NuGet package in order to send the email 
            #region Installing MimeKit for email
            /*
             * 1) Open the package manager console 
             *  - Tools -> NuGet Package Manager -> Package Manager Console
             * 2) Type install-package NETCore.MailKit
             *  - Press enter
             * 3) Add using MimeKit;
             * 4) Add using MailKit.Net.Smtp;
             */

            #endregion

            //**** Create the MimeMessage object (AKA the Email) ****//
            //create a variable for the body of the message 
            string message = $"Hello! You have received a new email from your website's contact form! <br />" +
                $"Sender: {cvm.Name}<br />Email: {cvm.Email}<br />Subject: {cvm.Subject}<br />Message: {cvm.Message}<br /><br />" +
                $"<strong> DO NOT REPLY TO THIS EMAIL. Send replies to {cvm.Email}</strong>";

            //Create an instance of MimeMessage that will store all of the email object's info 
            var msg = new MimeMessage();

            //Assign credentials to send the email 
            msg.From.Add(new MailboxAddress("Sender", _config.GetValue<string>("Credentials:Email:User")));

            msg.To.Add(new MailboxAddress("Personal", _config.GetValue<string>("Credentials:Email:Recipient")));

            //COMMENT BELOW OUT AFTER TESTING 
            //msg.Cc.Add(new MailboxAddress("Cc", "bush.jake11@gmail.com")); 

            msg.Subject = cvm.Subject;

            msg.Body = new TextPart("HTML") { Text = message };

            //Optional: set the message priority 
            msg.Priority = MessagePriority.Urgent;


            //Attempt to send the email 
            using (var client = new SmtpClient())
            {
                
                
                //Connect to the mail server 
                client.Connect(_config.GetValue<string>("Credentials:Email:Client"), 8889);

                //Authenticate our email user
                client.Authenticate(
                    //Username 
                    _config.GetValue<string>("Credentials:Email:User"),

                    //Password
                    _config.GetValue<string>("Credentials:Email:Password")
                    );

                try
                {
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    //If for any reason the client.Send(msg) fails, this code will execute and allow us to exit gracefully
                    //without causing a Runtime Exception 
                    ViewBag.ErrorMessage = $"There was an error processing your request. Please try again later.<br />" +
                        $"Error Message: {ex.StackTrace}";
                }

            }

            //If all goes well, return a View that displays a confirmation of the message being sent 
            return View("EmailConfirmation", cvm);

            //Email - Step 10 
            //Add the EmailConfirmation view
            // - Right click here in the Action -> Add View 
            // - Select Razor View - Empty 
            // - Name: EmailConfirmation 
            // - Add the @model decleration to the View 
            // - Code the view's HTML 



        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}