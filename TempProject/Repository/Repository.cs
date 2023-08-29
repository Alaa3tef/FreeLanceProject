using TempProject.Models;

namespace TempProject.Repository
{
    public class Repository<T> : IRepository<T> where T : class, ISoftDeleteRepository
    {
        Context c;
        public Repository(Context c)
        {
            this.c = c;
        }

        public List<T> getall()
        {
            return c.Set<T>().Where(T=>T.IsDeleted==false).ToList();

        }

        //public List<T> getall(string s)
        //{
        //    return c.Set<T>().Include(s).ToList();
        //}

        public T getbyid(int id)
        {

            // return c.Find<T>(T => T.IsDeleted==false && T.Id==id);

            return c.Set<T>().FirstOrDefault(T => T.IsDeleted == false && T.Id == id);
        }

        public void create(T t)
        {

            c.Set<T>().Add(t);
            c.SaveChanges();
        }
        public void update(T tt)
        {
            c.Update<T>(tt);
            c.SaveChanges();
        }
        public void delete(T tt)
        {
            c.Remove<T>(tt);
            c.SaveChanges();
        }

    }
}
