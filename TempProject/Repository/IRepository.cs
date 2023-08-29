namespace TempProject.Repository
{
    public interface IRepository<T>
    {
        public List<T> getall();
        //public List<T> getall(string s);
        //public List<T> getall(string obj1, string obj2);
        public T getbyid(int id);

        public void create(T course);
        public void update(T course);
        public void delete(T course);
    }
}
