using PenilaianPegawaiWeb.DataModels;
using PenilaianPegawaiWeb.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web;
using System.Linq;
using MySql.AspNet.Identity;

namespace PenilaianPegawaiWeb.Apis
{
    public class AccountController : ApiController
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _appRoleManager;

        // GET: api/Account
        // GET: api/Account


        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public AccountController()
        {
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        public ApplicationRoleManager AppRoleManager
        {
            get
            {
                return _appRoleManager ?? HttpContext.Current.GetOwinContext().GetUserManager<ApplicationRoleManager>();
            }
            private set
            {
                _appRoleManager = value;
            }
        }

        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Account/5
        [AllowAnonymous]

        [HttpGet]
        public async Task<HttpResponseMessage> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Error");
            }

            var c = HttpUtility.UrlDecode(code);
            var result = await UserManager.ConfirmEmailAsync(userId, c);
            return Request.CreateResponse(result.Succeeded ? "ConfirmEmail" : "Error");
        }


        public async Task<HttpResponseMessage> Register(RegisterViewModel model)
        {
            model.Password = "Penilai@123";
            model.ConfirmPassword = "Penilai@123";
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                    var result = await UserManager.CreateAsync(user, model.Password);
                    string role = "Penilai";
                    if (result.Succeeded)
                    {
                        var isExis = await AppRoleManager.RoleExistsAsync(role);
                        if (!isExis)
                        {
                            var r = await AppRoleManager.CreateAsync(new IdentityRole { Name = role });
                            if (r.Succeeded)
                            {
                                var roleResult = await UserManager.AddToRoleAsync(user.Id, role);
                                if (!roleResult.Succeeded)
                                {
                                    throw new System.Exception(string.Format("Gagal Menambahkan User Role"));
                                }
                                else
                                {
                                    using (var db = new OcphDbContext())
                                    {
                                        var re = db.PejabatPenilai.Insert(new DataModels.pejabatpenilai { IdPegawai = model.IdPegawai, UserId = user.Id });
                                        string c = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                                        string code = HttpUtility.UrlEncode(c);
                                        var callbackUrl = Url.Link("DefaultApi", new { controller = "Account/ConfirmEmail", userId = user.Id, code = code });
                                        await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                                        return Request.CreateResponse(HttpStatusCode.OK, "Data Berhasil ditambah");
                                    }
                                }
                            }
                            else
                            {
                                throw new System.Exception(string.Format("Role {0} Gagal Dibuat, Hubungi Administrator", role));
                            }
                        }
                        else
                        {
                            var roleResult = await UserManager.AddToRoleAsync(user.Id, role);
                            if (!roleResult.Succeeded)
                            {
                                throw new System.Exception(string.Format("Gagal Menambahkan User Role"));
                            }
                            else
                            {
                                using (var db = new OcphDbContext())
                                {
                                    var re = db.PejabatPenilai.Insert(new DataModels.pejabatpenilai { IdPegawai = model.IdPegawai, UserId = user.Id, Id = 0 });
                                    string c = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                                    string code = HttpUtility.UrlEncode(c);
                                    var callbackUrl = Url.Link("DefaultApi", new { controller = "Account/ConfirmEmail", userId = user.Id, code = code });
                                    await UserManager.SendEmailAsync(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");

                                    return Request.CreateResponse(HttpStatusCode.OK, "Data Berhasil ditambah");
                                }
                            }
                        }
                        // await SignInManager.SignInAsync(user, isPersistent:false, rememberBrowser:false);

                        // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                        // Send an email with this link

                        //  return RedirectToAction("Administrator", "Home");
                    }else
                        throw new SystemException("Data Tidak berhasil ditambah");
                }
                else
                {
                    throw new SystemException("Data Tidak Valid");
                }
            }
            catch (Exception ex)
            {

                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message, ex);
            }

            // If we got this far, something failed, redisplay form
        }


        [Authorize]
        [HttpGet]
        public HttpResponseMessage GetPejabatPenilaiProfile()
        {
            var ui = User.Identity.Name;
            pegawai result;
            try
            {
                if (User.IsInRole("Pejabat"))
                {

                    using (var db = new OcphDbContext())
                    {
                        var p = db.PejabatPenilai.Where(O => O.UserId == ui).FirstOrDefault();
                        if (p != null)
                        {
                            result = db.Pegawai.Where(O => O.IdPegawai == p.IdPegawai).FirstOrDefault();
                          return  Request.CreateResponse(HttpStatusCode.OK, result);
                        }
                        else
                            throw new SystemException("Data Tidak Ditemukan");
                    }
                }
                else
                    throw new SystemException("Anda Tidak Memiliki Hak Akses");
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
        }

        // POST: api/Account
     
        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
