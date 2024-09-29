using System.Text.Json.Serialization;

namespace poc.crud.mongodb.Arguments.Book;

public sealed class AddBookRequestDto
{
    [JsonPropertyName("Name")]
    public string BookName { get; set; } = null!;

    public double Price { get; set; }

    public string Category { get; set; } = null!;

    public string Author { get; set; } = null!;
}