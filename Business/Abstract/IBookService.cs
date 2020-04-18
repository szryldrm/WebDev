using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IBookService
    {
        List<Book> GetAll();
        List<Book> GetByAuthorId(int id);
        Book GetById(int id);
        void Add(Book book);
        void Delete(Book book);
        void Update(Book book);

    }
}
