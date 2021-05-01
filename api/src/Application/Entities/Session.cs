using System;

namespace Application.Entities
{
    public class Session
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
        public int UserId { get; set; }
        public virtual Domain.Entities.User User { get; set; }
    }
}
