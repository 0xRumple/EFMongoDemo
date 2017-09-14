namespace EFMongoDemo.Core.Models.Entity
{
	public interface IEntity<TId>
	{
		TId Id { get; set; }
	}
}