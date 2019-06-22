namespace Football.Api.ViewModels
{
    public class TeamStandingsViewModel
    {
        public int Position { get; set; }
        public TeamViewModel Team { get; set; }
        public int Won { get; set; }
        public int Draw { get; set; }
        public int Lost { get; set; }
        public int Points { get; set; }
    }
}
