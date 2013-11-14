namespace OctoFX.Core.Model
{
    public class Account
    {
        public virtual int Id { get; set; }
        public virtual string Email { get; set; }
        public virtual string Name { get; set; }
        public virtual string PasswordHashed { get; set; }
        public virtual bool IsActive { get; set; }
    }
}
