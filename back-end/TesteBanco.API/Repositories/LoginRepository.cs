using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TesteBanco.API.Business.IRepositories;
using TesteBanco.API.Domain.Models;

namespace TesteBanco.API.Repositories
{
    public class LoginRepository : BaseRepository, ILoginRepository
    {
        private static List<Cliente> clients;

        public LoginRepository()
        {
            clients = null;
            if (clients is null)
                clients = GenerateClients();
        }

        public LoginVO Login(LoginDTO login)
        {
            var client = clients.FirstOrDefault(x => x.Cpf == login.Cpf && x.Password == login.Password);
            LoginVO loginVO = null;

            if (client != null)
            {
                var token = GenerateToken();

                loginVO = new LoginVO{ Token = token, User = client };
            }

            return loginVO;
        }

        public static string GenerateToken()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 10)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;
        }
    }
}
