using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

var authorsManager = new AuthorManager(new EfAuthorDal());
var l = Console.ReadLine();
var m = Console.ReadLine();
authorsManager.Add(new Author
{
    Id = 1,
    FirstName = l,
    LastName = m,
}); ;
authorsManager.Add(new Author
{
    Id=2,
    FirstName = l,
    LastName = m,
});
authorsManager.Add(new Author
{
    Id= 3,
    FirstName = l,
    LastName = m,
});
foreach (var p in authorsManager.GetAll().Data)
{
    Console.WriteLine($"Id: {p.Id}\nFirstname: {p.FirstName}\nLastname{p.LastName}\n");
}

