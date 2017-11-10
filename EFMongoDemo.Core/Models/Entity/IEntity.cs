namespace EFMongoDemo.Core.Models.Entity
{
	public interface IEntity<out TId>
	{
		TId Id { get; }
	}
}