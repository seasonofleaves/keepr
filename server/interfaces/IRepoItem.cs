namespace keepr.interfaces;

public interface IRepoItem<T>
{
  T Id { get; set; }
  DateTime CreatedAt { get; set; }
  DateTime UpdatedAt { get; set; }
}