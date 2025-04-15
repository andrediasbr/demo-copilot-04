using DemoCopilot04.Controllers;
using DemoCopilot04.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace DemoCopilot04.Tests;

public class BooksControllerTests
{
    private readonly BooksController _controller;

    public BooksControllerTests()
    {
        _controller = new BooksController();
    }

    [Fact]
    public void GetBooks_ReturnsAllBooks()
    {
        // Act
        var result = _controller.GetBooks();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var books = Assert.IsAssignableFrom<IEnumerable<Book>>(okResult.Value);
        Assert.Equal(3, books.Count());
    }

    [Fact]
    public void GetBookById_ExistingId_ReturnsBook()
    {
        // Arrange
        var existingId = 1;

        // Act
        var result = _controller.GetBookById(existingId);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result.Result);
        var book = Assert.IsType<Book>(okResult.Value);
        Assert.Equal(existingId, book.Id);
    }

    [Fact]
    public void GetBookById_NonExistingId_ReturnsNotFound()
    {
        // Arrange
        var nonExistingId = 999;

        // Act
        var result = _controller.GetBookById(nonExistingId);

        // Assert
        Assert.IsType<NotFoundResult>(result.Result);
    }
}
