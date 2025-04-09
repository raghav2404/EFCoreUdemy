using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCore.Domain
{
    public class Match:BaseDomainModel
	{

        [Range(0,1000000)]
		public decimal TicketPrice { get; set; }

		public DateTime Date { get; set; }

        public int HomeTeamId { get; set; }       

        public virtual Team HomeTeam { get; set; }

        public int AwayTeamId { get; set; }

        public  virtual Team AwayTeam { get; set; }
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }









	}

}

