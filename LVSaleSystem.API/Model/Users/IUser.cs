namespace LVSaleSystem.API.Model.Users
{
    public interface IUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public UserDetails UserDetails { get; set; }
    }
}
