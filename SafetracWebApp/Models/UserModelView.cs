using SafetracWebApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafetracWebApp.Models
{
    public class UserModelView
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedDate { get; set; }

        public List<GetAllUsers_Result> GetAllUsers()
        {
            List<GetAllUsers_Result> lstUser = new List<GetAllUsers_Result>();
            try
            {
                using (SafetracEntities db = new SafetracEntities())
                {
                    lstUser = db.GetAllUsers()
                        .Select(x=> new GetAllUsers_Result
                        {first_name= x.first_name,
                       last_name= x.last_name,
                       date_created= x.date_created,
                      email_address= EncryptionHelper.Decrypt(x.email_address),
                       id= x.id }).ToList();
                    return lstUser;
                }
            }
            catch (Exception e)
            {
                return lstUser;
            }

        }

        public List<ListUsers_Result> LoadAllUsers(string Search, int StartPage, int Lenght, string Sort, string order)
        {
            List<ListUsers_Result> lstUser = new List<ListUsers_Result>();
            try
            {
                using (SafetracEntities db = new SafetracEntities())
                {
                    lstUser = db.ListUsers(Search, StartPage == 0 ? 1 : StartPage, Lenght, Sort, order).Select(x => new ListUsers_Result
                    {
                        first_name = x.first_name,
                        last_name = x.last_name,
                        date_created = x.date_created,
                        email_address = EncryptionHelper.Decrypt(x.email_address),
                        id = x.id
                    }).ToList();
                    return lstUser;
                }
            }
            catch (Exception e)
            {
                return lstUser;
            }

        }
        public int AddUser(User user)
        {
            try
            {
                using (SafetracEntities db = new SafetracEntities())
                {
                    user.email_address = EncryptionHelper.Encrypt(user.email_address);
                    user.date_created = DateTime.UtcNow;
                    user.date_modified = DateTime.UtcNow;
                    db.Users.Add(user);
                    return (int)db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}