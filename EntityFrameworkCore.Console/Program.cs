
//
using EntityFrameworkCore.Data;
using EntityFrameworkCore.Domain;
using Microsoft.EntityFrameworkCore;

var options = new DbContextOptions<FootballLeagueDbContext>();
using var context = new FootballLeagueDbContext(options);

var nl = new League
{
    Name = "nl"
};
await context.AddAsync(nl);
await context.SaveChangesAsync();




////await context.Database.MigrateAsync();
////var applied = context.Database.EnsureCreated();
////.WriteLine(applied);

/////*var teams = await context.Teams.AsNoTracking().ToListAsync();
////foreach(var team in teams)
////{

////    Console.WriteLine(team.Name);

////}


////var teamOne = await context.Teams.AsNoTracking().FirstOrDefaultAsync(team => team.TeamId == 2);
//////Console.WriteLine(teamOne.Name);

////var teamBasedOnId = await context.Teams.FindAsync(3);
////if(teamBasedOnId!=null)
////{
////    Console.WriteLine(teamBasedOnId.Name);
////}

////var teamsFiltered = await context.Teams.Where(x => x.Name == "LSG").ToListAsync();
////foreach(var item in teamsFiltered)
////{
////    Console.WriteLine(item.Name);
////}


////var searchTerm = "CS";
////var partialMatch = await context.Teams.Where(q => EF.Functions.Like(q.Name,$"%{searchTerm}%")).ToListAsync();
////foreach (var item in partialMatch)
////{
////    Console.WriteLine(item.Name);
////}

////var numberOfTeams = await context.Teams.AsNoTracking().CountAsync();

////Console.WriteLine(numberOfTeams);

////var maxTeamid = await context.Teams.MaxAsync(x => x.TeamId);


////var sumTeams = await context.Teams.SumAsync(x => x.TeamId);
////Console.WriteLine(sumTeams);





////var groupedTeams = context.Teams.GroupBy(q => new { q.CreateDate.Date });

////var teamsSelect = await context.Teams.Select(q => new { q.Name, q.CreateDate }).ToListAsync();

////var teamsAsQueryable = context.Teams.AsQueryable();
//////teamsAsQueryable = teamsAsQueryable.Where(x => x.Name.Contains("L"));

////var res = await teamsAsQueryable.ToListAsync();

////foreach (var item in res)
////{
////    Console.WriteLine(item);
////}

////*/

////// EFFICIENT QUERIYING - USE INDEXES WISELY ,PROJECTIONS , LIMIT RESULT SET VIA SKIP AND TAKE AND USE ASYNC METHODS,
//////USE RAW QUERY FROMSQLRAW()
//////asnotracking for read queries
//////batch operations and split queries



//////savechanges() is used to confirm pending changes to db records - it istransactional
////// all entities change either suceed or fail and no partial changes involved

//////simple insert

////var newCoach = new Coach
////{
////    Name = "Kevin",
////    CreateDate = DateTime.Now,

////};
////await context.Coaches.AddAsync(newCoach);
////await context.SaveChangesAsync();
//////loop
/////*
////var nc = new Coach
////{
////    Name = "Theodore Whitemore",
////    CreateDate = DateTime.Now,
////};
////List<Coach> coaches = new List<Coach>()
////{
////    nc,newCoach
////};
////foreach(var coach in coaches)
////{
////    await context.Coaches.AddAsync(coach);
////}
////await context.SaveChangesAsync();

////*/
////context.Update(newCoach);

////context.SaveChanges();


//var match = new Match
//{
//    AwayTeamId = 1,
//    HomeTeamId = 2,
//    HomeTeamScore = 7,
//    AwayTeamScore = 1,
//    Date =DateTime.Now,
//    TicketPrice =1000
//};

////await context.AddAsync(match);
////await context.SaveChangesAsync();



//var team = new Team
//{
//    Name = "srh",
//    Coach = new Coach
//{
//        Name = "Rohit"
//    }
//};

////await context.AddAsync(team);

////await context.SaveChangesAsync();



//var league = new League
//{
//    Name = "PSL",
//    Teams = new List<Team>
//    {
//        new Team
//        {
//            Name = "kkr",
//            Coach  = new Coach
//            {
//                Name = "srk"
//            }
//        },

//         new Team
//        {
//            Name = "harcb",
//            Coach  = new Coach
//            {
//                Name = "zinta"
//            }
//        }
//    }
//};

////await context.AddAsync(league);
////await context.SaveChangesAsync();

//var leagues = await context.Leagues.ToListAsync();
//foreach(var league1 in leagues)
//{
//    Console.WriteLine(league.Name);

//    for (int i = 0; i < league1.Teams.Count; i++)
//    {
//        Team team1f = league1.Teams[i];
//        Console.WriteLine(team1f.Name);
//    }
//}

////eager loading
//var leaguesWithTeams = await context.Leagues
//    .Include(x => x.Teams)
//    .ThenInclude(x=>x.Coach)
//    .ToListAsync();

//foreach (var l in leaguesWithTeams)
//{
//    foreach (var teamm in league.Teams)
//    {
//        Console.WriteLine(teamm);
//        Console.WriteLine(teamm.Coach.Name);
//    }
//}


////explicit
//var leagueL = await context.FindAsync<League>(5);

//if(!leagueL.Teams.Any())
//{
//    Console.WriteLine("teams have not been loaded");
//}

//context.Entry(leagueL)
//    .Collection(x => x.Teams)
//    .Load();


//if(leagueL.Teams.Any())
//{
//    foreach(var teamT in leagueL.Teams)
//    {
//        Console.WriteLine($"{teamT.Name}");
//    }

//}

////lazy loading

//var leagueA = await context.FindAsync<League>(1);
//foreach(var teamA in leagueA.Teams)
//{
//    Console.WriteLine(teamA);

//}


////filter

//var match1 = new Match
//{
//    TicketPrice = 59.99m,
//    Date = new DateTime(2023, 11, 5, 20, 0, 0),
//    HomeTeamId = 1,
//    AwayTeamId = 2,
//    HomeTeamScore = 3,
//    AwayTeamScore = 2
//};

//var match2 = new Match
//{
//    TicketPrice = 45.00m,
//    Date = new DateTime(2023, 11, 12, 15, 30, 0),
//    HomeTeamId = 2,
//    AwayTeamId = 1,
//    HomeTeamScore = 1,
//    AwayTeamScore = 1
//};

////await context.AddRangeAsync(match1, match2);
////await context.SaveChangesAsync();

//var teams = await context.Teams
//    .Include("Coach")
//    .Include(x => x.HomeMatches.Where(x => x.HomeTeamScore > 0))
//    .ToListAsync();


//var tteams = await context.Teams.
//    Select(x => new TeamDetails
//    {
//        TeamId = x.Id,
//        TeamName = x.Name,
//        CoachName = x.Coach.Name,
//        TotalHomeGoals = x.HomeMatches.Sum(x=>x.HomeTeamScore),
//        TotalAwayGoals = x.AwayMatches.Sum(x=>x.AwayTeamScore),
//    }).ToListAsync();


//var teamName = Console.ReadLine();
////var tteeamsparam = new SqlParameter("teamName", teamName);

//var teamNameParam = new SqlParameter("teamName", teamName);

//var team1 = context.Teams.FromSqlRaw($"SELECT * FROM TEAMS")
//    .Where(q => q.Id == 1)
//    .OrderBy(q=>q.Id)
//    .Include("League")
//    .ToList();

//foreach(var t in team1)
//{
//    Console.WriteLine(team1);
//}
//var leagueId = 1;
//var leagueAkk = context.Leagues.FromSqlInterpolated($"EXEC dbo.StoredProcedureToGetLeagueNameHere {leagueId}");

//var someNewTeamName = "New Team Name Here";
//var success = context.Database
//    .ExecuteSqlInterpolated($"UPDATE Teams SET Name = {someNewTeamName}");

//var teamToDeleteId = 1;
//var successa = context.Database.ExecuteSqlInterpolated($"EXEC dbo.DeleteTeam {teamToDeleteId}");

////scaler
//var leagueIds = context.Database.SqlQuery<int>($"SELECT Id from Leagues").ToList();





 





//class TeamDetails
//{
//    public int TeamId { get; set; }

//    public string TeamName { get; set; }

//    public string CoachName { get; set; }

//    public int TotalHomeGoals { get; set; }

//    public int TotalAwayGoals { get; set; }


//}
