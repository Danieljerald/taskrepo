namespace Task.Models
{
    public interface IDatabase
    {
        public void AddRegister(Register register);
        public IEnumerable<Register> GetRegister();
    }
}