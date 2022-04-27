using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using ProvaConceitoTimeIAGRO.Interface;
using ProvaConceitoTimeIAGRO.Model;
using ProvaConceitoTimeIAGRO.Servico;
using ProvaConceitoTimeIAGRO.Utils;
using System.Collections.Generic;
using ProvaConceitoTimeIAGRO.ExtensionMethod;

namespace ProvaConceitoTimeIAGRO.Test
{
    public class Tests
    {

        private BookService BookService;        
        private Book Book1 { get; set; }
        private Book Book2 { get; set; }

        [SetUp]
        public void Setup()
        {
            Book1 = new Book()
            {
                Id = 1,
                Name = "Maria",
                Price = 22,
                Specifications = new Specifications()
                {
                    OriginallyPublished = "Moderna",
                    Author = "Pedro",
                    PageCount = 20,
                    Genres = "Infantil",
                    Illustrator = "Neuville"
                }
            };

            Book2 = new Book()
            {
                Id = 2,
                Name = "Eduardo",
                Price = 55,
                Specifications = new Specifications()
                {
                    OriginallyPublished = null,
                    Author = "Bianca",
                    PageCount = 20,
                    Genres = "Aventura",
                    Illustrator = "Pedra"
                }
            };

            List<Book> booksList = new List<Book>();
            booksList.Add(Book1);

            booksList.Add(Book2);

            Mock<IRepositorio> repositorio = new Mock<IRepositorio>();
            repositorio.Setup(x => x.GetBook()).Returns(booksList);

            BookService = new BookService(repositorio.Object) ;
        }

        [Test]
        public void Frete_ComValorInteiro_Sucesso()
        {
            #region Arrange
            #endregion

            #region Act
            var resultado = BookService.Frete(22);
            #endregion

            #region Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, 4.4);
            #endregion
        }

        [Test]
        public void Frete_ComValorDouble_Sucesso()
        {
            #region Arrange
            #endregion

            #region Act
            var resultado = BookService.Frete(22.8);
            #endregion

            #region Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, 4.56);
            #endregion
        }

        [Test]
        public void Frete_ComValorZero_Falha()
        {
            #region Arrange
            #endregion

            #region Act
            var resultado = BookService.Frete(0);
            #endregion

            #region Assert
            Assert.IsNotNull(resultado);
            Assert.AreEqual(resultado, 0);
            #endregion
        }


        [Test]
        public void Util_IsNotDefault_Falha()
        {
            #region Arrange
            Book1 = new Book();
            #endregion

            #region Act
            bool resultado = Util.IsNotDefault(Book1);
            #endregion

            #region Assert
            Assert.IsFalse(resultado);
            #endregion
        }

        [Test]
        public void Util_IsNotDefault_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            #endregion

            #region Act
            Book1.Id = 1;
            bool resultadoId = Util.IsNotDefault(Book1);

            Book1 = new Book();
            Book1.Name = "Pedro";
            bool resultadoName = Util.IsNotDefault(Book1);

            Book1 = new Book();
            Book1.Price = 22;
            bool resultadoPrice = Util.IsNotDefault(Book1);

            Book1 = new Book();
            Book1.Specifications = new Specifications();
            Book1.Specifications.Author = "Abraão";
            bool resultadoSpecificationsAuthor = Util.IsNotDefault(Book1);

            Book1 = new Book();
            Book1.Specifications = new Specifications();
            Book1.Specifications.PageCount = 100;
            bool resultadoSpecificationsPageCount = Util.IsNotDefault(Book1);

            Book1 = new Book();
            Book1.Specifications = new Specifications();
            Book1.Specifications.OriginallyPublished = "Original";
            bool resultadoSpecificationsOriginallyPublished = Util.IsNotDefault(Book1);
            #endregion

            #region Assert
            Assert.IsTrue(resultadoId);
            Assert.IsTrue(resultadoName);
            Assert.IsTrue(resultadoPrice);
            Assert.IsTrue(resultadoSpecificationsAuthor);
            Assert.IsTrue(resultadoSpecificationsPageCount);
            Assert.IsTrue(resultadoSpecificationsOriginallyPublished);
            #endregion
        }

        [Test]
        public void Util_Filtrar_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            #endregion

            #region Act
            Book1 = new Book();
            Book1.Specifications = new Specifications();
            Book1.Specifications.Illustrator = new string[] {"Édouard Riou", "Alphonse-Marie-Adolphe de Neuville"};

            List<Book> bookList = new List<Book>();

            bookList.Add(Book1);

            List<Book> resultadoSpecificationsIllustratorArray = Util.Filtrar(bookList, null, "Alphonse");
            #endregion

            #region Assert
            Assert.IsTrue(resultadoSpecificationsIllustratorArray.Count == 1);
            Assert.IsNotNull(resultadoSpecificationsIllustratorArray[0].Specifications.Illustrator);
            #endregion
        }

        [Test]
        public void Util_Filtrar_Falha()
        {
            #region Arrange
            Book1 = new Book();
            #endregion

            #region Act
            Book1 = new Book();
            Book1.Specifications = new Specifications();
            
            List<Book> bookList = new List<Book>();
            bookList.Add(Book1);

            List<Book> resultadoSpecificationsIllustratorArray = Util.Filtrar(bookList, null, "Alphonse");
            #endregion

            #region Assert
            Assert.IsTrue(resultadoSpecificationsIllustratorArray.Count == 0);
            #endregion
        }

        [Test]
        public void BookService_GetAllOrderDesc_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "desc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count > 1);
            Assert.AreEqual(books[0].Id, 2);
            #endregion
        }

        [Test]
        public void BookService_GetAllOrderAsc_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count > 1);
            Assert.AreEqual(books[0].Id, 1);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetId_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Id = 2;
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 1);
            Assert.AreEqual(books[0].Id, 2);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetName_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Name = "Eduardo";
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 1);
            Assert.AreEqual(books[0].Id, 2);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetPrice_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Price = 55;
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 1);
            Assert.AreEqual(books[0].Id, 2);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetSpecificationsOriginallyPublished_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                OriginallyPublished = null
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 2);
            Assert.AreEqual(books[0].Specifications.OriginallyPublished, "Moderna");
            #endregion
        }
        
        [Test]
        public void BookService_GetAllGetSpecificationsAuthor_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                Author = "Bianca"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 1);
            Assert.AreEqual(books[0].Specifications.Author, "Bianca");
            #endregion
        }
        
        [Test]
        public void BookService_GetAllGetSpecificationsPageCount_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                PageCount = 20
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 2);
            Assert.AreEqual(books[0].Specifications.PageCount, 20);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetSpecificationsGenres_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                Genres = "Aventura"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 1);
            Assert.AreEqual(books[0].Specifications.Genres, "Aventura");
            #endregion
        }
        
        [Test]
        public void BookService_GetAllGetSpecificationsIllustrator_Sucesso()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                Illustrator = "Pedra"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 1);
            Assert.AreEqual(books[0].Specifications.Illustrator, "Pedra");
            #endregion
        }

        [Test]
        public void BookService_GetAllGetId_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Id = 20;
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetName_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Name = "Yasmin";
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetPrice_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Price = 551;
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetSpecificationsOriginallyPublished_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                OriginallyPublished = "Miraculous"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }
        
        [Test]
        public void BookService_GetAllGetSpecificationsAuthor_Falhao()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                Author = "Miraculous"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }
        
        [Test]
        public void BookService_GetAllGetSpecificationsPageCount_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                PageCount = 2000
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }

        [Test]
        public void BookService_GetAllGetSpecificationsGenres_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                Genres = "Animes"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }
        
        [Test]
        public void BookService_GetAllGetSpecificationsIllustrator_Falha()
        {
            #region Arrange
            Book1 = new Book();
            Book1.Specifications = new Specifications()
            {
                Illustrator = "Samuel Murgel Branco"
            };
            #endregion

            #region Act
            List<Book> books = BookService.GetAll(Book1, "asc");
            #endregion

            #region Assert            
            Assert.IsTrue(books.Count == 0);
            #endregion
        }

        [Test]
        public void Extensions_IsNullValue_Sucesso()
        {
            #region Arrange 
            #endregion

            #region Act            
            #endregion

            #region Assert            
            Assert.IsTrue(Book1.Name.IsNullValue("Maria"));
            Assert.IsTrue(Book1.Specifications.Author.IsNullValue("Pedro"));
            Assert.IsTrue(Book1.Specifications.OriginallyPublished.IsNullValue("Moderna"));
            #endregion
        }

        [Test]
        public void Extensions_IsNullValue_Falha()
        {
            #region Arrange 
            #endregion

            #region Act            
            #endregion

            #region Assert            
            Assert.IsFalse(Book1.Name.IsNullValue("Eduarda"));
            Assert.IsFalse(Book1.Specifications.Author.IsNullValue("Henrique"));
            Assert.IsFalse(Book1.Specifications.OriginallyPublished.IsNullValue("Nova"));
            #endregion
        }
    }
}