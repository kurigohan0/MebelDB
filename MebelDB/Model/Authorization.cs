using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MebelDB.Model
{
        class Authorization
        {
            public enum Role
            {
                Manager,
                Client,
                Director,
                Master,
                None
            }


            public static Role Auth(string login, string pass)
            {
    #if DEBUG
                return Role.Manager;
    #else

                MebelEntities mebelEntities = new MebelEntities();
                foreach (var item in mebelEntities.Users)
                {
                    if(item.Login == login && item.Password == pass)
                    {
                        CurrentUser.User = item;
                        switch (item.Role)
                        {
                            case "Менеджер":
                                return Role.Manager;
                            case "Директор":
                                return Role.Director;
                            case "Мастер":
                                return Role.Master;
                            case "Заказчик":
                                return Role.Client;
                            case "Заместитель директора":
                                return Role.Director;

                        }
                    }
                }
                return Role.None;
    #endif
            }
        }
}
