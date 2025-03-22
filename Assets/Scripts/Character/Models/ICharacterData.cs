namespace Character.Models
{
    public interface ICharacterData
    {
        float MoveSpeed { get; }
        float JumpForce { get; }
        string StyleName { get; }
    }
}