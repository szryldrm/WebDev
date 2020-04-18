using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class BookManager:IBookService
    {
        private IBookDal _bookDal;

        public BookManager(IBookDal bookDal)
        {
            _bookDal = bookDal;
        }

        public List<Book> GetAll()
        {
            return new List<Book>(_bookDal.GetList()).ToList();
        }

        public List<Book> GetByAuthorId(int id)
        {
            return new List<Book>(_bookDal.GetList(p=>p.AuthorId == id)).ToList();
        }

        public Book GetById(int id)
        {
            return _bookDal.Get(p => p.Id == id);
        }

        public void Add(Book book)
        {
            if (_bookDal.Get(b=>b.Name == book.Name && b.AuthorId == book.AuthorId) == null)
            {
                _bookDal.Add(book);
            }
            else
            {
                throw new Exception("Bu Kitap Adı Zaten Mevcut");
            }
        }

        public void Delete(Book book)
        {
            _bookDal.Delete(book);
        }

        public void Update(Book book)
        {
            _bookDal.Update(book);
        }
    }
}
