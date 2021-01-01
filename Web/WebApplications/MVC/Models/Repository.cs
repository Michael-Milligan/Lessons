using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public static class Repository
    {
        private static readonly List<GuestResponse> _Responses = new List<GuestResponse>();

        public static IEnumerable<GuestResponse> Responses => _Responses;

        public static void AddResponse(GuestResponse Response)
        {
            _Responses.Add(Response);
        }
    }
}
