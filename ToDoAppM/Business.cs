using System.Collections.Generic;
using System.Linq;



namespace ToDoAppM
{
    public class Business
    {
       
            private UsersContext usersContext;

            public List<Users> GetAll()
            {
                using (usersContext = new UsersContext())
                {
                    return usersContext.Users.ToList();
                }
            }

            public Users Get(int id)
            {
                using (usersContext = new UsersContext())
                {
                    return usersContext.Users.Find(id);

                }
            }


            public void Add(Users users)
            {
                using (usersContext = new UsersContext())
                {
                    usersContext.Users.Add(users);
                    usersContext.SaveChanges();
                }
            }

            public void Update(Users users)
            {
                using (usersContext = new UsersContext())
                {

                    var item = usersContext.Users.Find(users.Id);
                    if (item != null)
                    {
                        usersContext.Entry(item).CurrentValues.SetValues(users);
                        usersContext.SaveChanges();
                    }

                }
            }

            public void Delete(int id)
            {
                using (usersContext = new UsersContext())
                {
                    var users = usersContext.Users.Find(id);
                    if (users != null)
                    {
                        usersContext.Users.Remove(users);
                        usersContext.SaveChanges();
                    }
                }
            }
        
    }
}
