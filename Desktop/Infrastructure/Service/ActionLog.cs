using Desktop.Model;

namespace Desktop.Infrastructure.Service
{
    public class ActionLog 
    { 
        public static void Set(string content)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                db.Logs.Add(new Log(0, content));
                db.SaveChanges();
            }
        }
    }
}
