using Nagarro.BookEvents.EntityDataModel;
using Nagarro.BookEvents.EntityDataModel.EntityModel;
using Nagarro.BookEvents.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nagarro.BookEvents.Data
{
    public class UserDAC : DACBase, IUserDAC
    {
        public UserDAC()
            : base(DACType.UserDAC)
        {

        }

        public UserDTO CreateUser(UserDTO userDTO)
        {
          

            using (var context = new BookReadingEventsDBEntities())
            {
                
                User user = new User();
                EntityConverter.FillEntityFromDTO(userDTO, user);
                string Password = user.Password;

                string Encrypted = EncriptionAndDecription.Encrypt(Password, EncriptionAndDecription.EncryptionKey);
                user.Password = Encrypted;

                bool isExist = context.Users.Any(u => u.Email == user.Email);


                if (!isExist)
                {
                    context.Users.Add(user);
                    context.SaveChanges();
                    return userDTO;
                }

                return null;
            }
        }

        public UserDTO LoginUser(UserDTO userDTO)
        {
            using (var context = new BookReadingEventsDBEntities())
            {
                
                User user = context.Users.SingleOrDefault(u => u.Email == userDTO.Email);
                string Password = user.Password;
                string Decrypted = EncriptionAndDecription.Decrypt(Password, EncriptionAndDecription.EncryptionKey);
                var IsValid = context.Users.SingleOrDefault(u => u.Email == userDTO.Email && Decrypted == userDTO.Password);
                if (IsValid != null)
                {
                    userDTO.FullName = IsValid.FullName;
                    EntityConverter.FillDTOFromEntity(IsValid, userDTO);
                    return userDTO;
                }

                return null;
            }

        }

    }
}
                                                                   
