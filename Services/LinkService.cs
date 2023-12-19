using API_RESTful_Project.Models;
using MailChimp.Net.Models;
using Microsoft.EntityFrameworkCore;

namespace API_RESTful_Project.Services
{
    public class LinkService: ILinkService
    {
        private readonly DbContextApp _dbContext;

        public LinkService(DbContextApp dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
