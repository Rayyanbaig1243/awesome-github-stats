﻿using AwesomeGithubStats.Core.Models;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AwesomeGithubStats.Models
{
    public class UserStatsSvg
    {
        private readonly UserRank _rank;
        private readonly string _file;

        public UserStatsSvg(UserRank rank, string file)
        {
            _rank = rank;
            _file = file;
        }

        public async Task<string> Svg()
        {
            var inMemoryCopy = new MemoryStream();
            var fs = await File.ReadAllTextAsync(_file);

            return new MemoryStream(Encoding.UTF8.GetBytes(fs.Replace("{{Name}}", _rank.UserStats.Name)));
        }
    }
}
