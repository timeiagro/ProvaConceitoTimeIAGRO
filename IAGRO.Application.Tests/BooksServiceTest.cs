using IAGRO.Application.Interfaces;
using IAGRO.Application.Services.Books;
using System.Linq;
using Xunit;

namespace IAGRO.Application.Tests
{
    public class BooksServiceTest
    {
        public BooksServiceTest()
        {
            _booksService = new BooksService();
        }

        private readonly IBooksService _booksService;

        [Fact]
        public void GetAll_IsNotNull()
        {
            Assert.NotNull(_booksService.GetAll());
        }

        [Theory]
        [InlineData("This name is not an author")]
        [InlineData("Jule")]
        [InlineData("888")]
        [InlineData("#jule")]
        [InlineData("jule")]
        [InlineData("Verne")]
        [InlineData("ules Ver")]
        [InlineData(" ")]
        public void GetByAuthor_IsNotNull(string value)
        {
            var data = _booksService.GetByAuthor(value);
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByAuthor_ReturningNullWhenValueIsEmpty()
        {
            var data = _booksService.GetByAuthor(string.Empty);
            Assert.Null(data);
        }

        [Fact]
        public void GetByAuthor_ReturningNullWhenValueIsNull()
        {
            var data = _booksService.GetByAuthor(null);
            Assert.Null(data);
        }

        [Fact]
        public void GetByAuthor_ReturningListWhenValueIsUpper()
        {
            var data = _booksService.GetByAuthor("JULES VERNE");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByAuthor_ReturningListWhenValueIsCapitalized()
        {
            var data = _booksService.GetByAuthor("Jules Verne");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByAuthor_ReturningListWhenValueIsLower()
        {
            var data = _booksService.GetByAuthor("jules verne");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByAuthor_ReturningListWhenValueContains()
        {
            var data = _booksService.GetByAuthor("les ver");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByAuthor_ReturningListWhenValueNotExists()
        {
            var data = _booksService.GetByAuthor("Clarice Lispector");
            Assert.NotNull(data);
        }

        [Theory]
        [InlineData("Journey to the Center of the Earth")]
        [InlineData("earth")]
        [InlineData("888")]
        [InlineData("#earth")]
        [InlineData("ney to")]
        [InlineData("EARTH")]
        [InlineData("@#$%")]
        [InlineData(" ")]
        public void GetByBooksName_IsNotNull(string value)
        {
            var data = _booksService.GetByBooksName(value);
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByBooksName_ReturningNullWhenValueIsEmpty()
        {
            var data = _booksService.GetByBooksName(string.Empty);
            Assert.Null(data);
        }

        [Fact]
        public void GetByBooksName_ReturningNullWhenValueIsNull()
        {
            var data = _booksService.GetByBooksName(null);
            Assert.Null(data);
        }

        [Fact]
        public void GetByBooksName_ReturningListWhenValueIsUpper()
        {
            var data = _booksService.GetByBooksName("JOURNEY TO THE CENTER OF THE EARTH");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByBooksName_ReturningListWhenValueIsCapitalized()
        {
            var data = _booksService.GetByBooksName("Journey to the Center of the Earth");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByBooksName_ReturningListWhenValueIsLower()
        {
            var data = _booksService.GetByBooksName("journey to the center of the earth");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByBooksName_ReturningListWhenValueContains()
        {
            var data = _booksService.GetByBooksName("center of");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetByBooksName_ReturningListWhenValueNotExists()
        {
            var data = _booksService.GetByBooksName("Almanaque da Mônica");
            Assert.NotNull(data);
        }

        [Theory]
        [InlineData("Journey to the Center of the Earth")]
        [InlineData("Jule")]
        [InlineData("888")]
        [InlineData("#earth")]
        [InlineData("ney to")]
        [InlineData("EARTH")]
        [InlineData("Édouard")]
        [InlineData("Row")]
        [InlineData("2000")]
        [InlineData("@#$%")]
        [InlineData(" ")]
        public void FindAnySpecification_IsNotNull(string value)
        {
            var data = _booksService.FindAnySpecification(value);
            Assert.NotNull(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningNullWhenValueIsEmpty()
        {
            var data = _booksService.FindAnySpecification(string.Empty);
            Assert.Null(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningNullWhenValueIsNull()
        {
            var data = _booksService.FindAnySpecification(null);
            Assert.Null(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningListWhenValueIsUpper()
        {
            var data = _booksService.FindAnySpecification("FICTION");
            Assert.NotNull(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningListWhenValueIsCapitalized()
        {
            var data = _booksService.FindAnySpecification("Fiction");
            Assert.NotNull(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningListWhenValueIsLower()
        {
            var data = _booksService.FindAnySpecification("fiction");
            Assert.NotNull(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningListWhenValueContains()
        {
            var data = _booksService.FindAnySpecification("adventure fic");
            Assert.NotNull(data);
        }

        [Fact]
        public void FindAnySpecification_ReturningListWhenValueNotExists()
        {
            var data = _booksService.FindAnySpecification("All Lucky is 7777");
            Assert.NotNull(data);
        }

        [Fact]
        public void GetShippingPrice_ReturningZeroWhenBookIdIsNull()
        {
            var data = _booksService.GetShippingPrice(null);
            Assert.Equal(0, data);
        }

        [Fact]
        public void GetShippingPrice_ReturningZeroWhenBookIdNotExists()
        {
            var data = _booksService.GetShippingPrice(123);
            Assert.Equal(0, data);
        }

        [Fact]
        public void GetShippingPrice_ReturningPercentageOf20Percent()
        {
            var data = _booksService.GetShippingPrice(1);
            // The price of book id=1 are 10.00
            // 20% of 10.00 is equal to 2
            // Confirm these prices in the books.json file ;D
            Assert.Equal(2, data);
        }

        [Theory]
        [InlineData("ascending")]
        [InlineData("1")]
        [InlineData("0")]
        [InlineData("descending")]
        [InlineData("asce")]
        [InlineData("EARTH")]
        [InlineData("bla bla bla")]
        [InlineData("xyz")]
        [InlineData("2000")]
        [InlineData("@#$%")]
        [InlineData(" ")]
        public void OrderByPrice_ReturningNullWhenValueIsInvalid(string value)
        {
            var data = _booksService.OrderByPrice(value);
            Assert.Null(data);
        }

        [Theory]
        [InlineData("asc")]
        [InlineData("desc")]
        public void OrderByPrice_ReturningListWhenValueIsValid(string value)
        {
            var data = _booksService.OrderByPrice(value);
            Assert.NotNull(data);
        }

        [Fact]
        public void OrderByPrice_ReturningNullWhenValueIsNull()
        {
            var data = _booksService.OrderByPrice(null);
            Assert.Null(data);
        }

        [Fact]
        public void OrderByPrice_ReturningNullWhenValueIsEmpty()
        {
            var data = _booksService.OrderByPrice(string.Empty);
            Assert.Null(data);
        }

        [Fact]
        public void OrderByPrice_ReturningAscendingList()
        {
            var data = _booksService.OrderByPrice("asc");
            decimal firstBookValue = data.FirstOrDefault().Price;
            decimal lastBookValue = data.LastOrDefault().Price;
            Assert.True(firstBookValue < lastBookValue);
        }

        [Fact]
        public void OrderByPrice_ReturningDescendingList()
        {
            var data = _booksService.OrderByPrice("desc");
            decimal firstBookValue = data.FirstOrDefault().Price;
            decimal lastBookValue = data.LastOrDefault().Price;
            Assert.True(firstBookValue > lastBookValue);
        }
    }
}
