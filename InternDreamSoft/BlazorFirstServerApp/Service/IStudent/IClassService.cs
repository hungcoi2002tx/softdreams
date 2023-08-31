namespace BlazorFirstServerApp.Service.IStudent
{
    public interface IClassService
    {
        public List<Class> GetListClass();

        public Class GetClass(int id);

        public void Delete(Class _class);

        public void Add(Class _class);
    }
}
