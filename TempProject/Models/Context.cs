using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace TempProject.Models
{
    public class Context : IdentityDbContext
    {
        public DbSet<Accident> Accidents { get; set; }
        public DbSet<RouteName> RouteNames { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<JMP> JMPs { get; set; }
        public DbSet<Driver> DriverNames { get; set; }
        public DbSet<ComminucationMethod> ComminucationMethods { get; set; }
        //public DbSet<Crew> Crews { get; set; }
        public DbSet<LeadershipVisit> LeadershipVisits { get; set; }
        public DbSet<RecordableAccident> RecordableAccidents { get; set; }
        public DbSet<NonRecordableAccident> NonRecordableAccidents { get; set; }
        //public DbSet<Drill> Drills { get; set; }
		public DbSet<StopCardRegister> StopCardRegisters { get; set; }
		public DbSet<Rig> Rigs { get; set; }
		public DbSet<Classification> Classifications { get; set; }
		public DbSet<ClassificationOfAccident> ClassificationOfAccidents { get; set; }
		public DbSet<PreventionCategory> PreventionCategorys { get; set; }
		public DbSet<AccidentCauses> AccidentCauses { get; set; }
		public DbSet<TypeOfInjury> TypeOfInjurys { get; set; }
		public DbSet<ViolationCategory> ViolationCategorys { get; set; }
		public DbSet<ToolPusherPosition> ToolPusherPositions { get; set; }
		public DbSet<ToolPusherPositionName> ToolPusherPositionNames { get; set; }
		public DbSet<QHSEPosition> QHSEPositions { get; set; }
		public DbSet<QHSEPositionName> QHSEPositionNames { get; set; }
		public DbSet<TypeOfObservationCategory> TypeOfObservationCategorys { get; set; }
		public DbSet<ReportedByPosition> ReportedByPositions { get; set; }
		public DbSet<ReportedByName> ReportedByNames { get; set; }
		public DbSet<RigMovePerformance> RigMovePerformances { get; set; }

		public DbSet<ProblemFacedDuringRigMove> ProblemFacedDuringRigMoves { get; set; }
		public DbSet<PTSM> PTSMs { get; set; }
		public DbSet<Attendance> Attendances { get; set; }

		public DbSet<Passenger> Passengers { get; set; }
        public DbSet<JMP_Passenger> JMP_Passengers { get; set; }

        public DbSet<BOP> Bop { get; set; }


        public Context(DbContextOptions c) : base(c)
        {
            
        }

		//protected override void OnModelCreating(ModelBuilder modelBuilder)
		//{
		//	//modelBuilder.Entity<RouteName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Vehicle>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Driver>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ComminucationMethod>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Crew>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<LeadershipVisit>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<RecordableAccident>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<NonRecordableAccident>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Drill>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Rig>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Classification>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ClassificationOfAccident>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<PreventionCategory>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<AccidentCauses>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<TypeOfInjury>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ViolationCategory>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ToolPusherPosition>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ToolPusherPositionName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<QHSEPosition>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<QHSEPositionName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<TypeOfObservationCategory>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ReportedByPosition>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<ReportedByName>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<Passenger>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//	//modelBuilder.Entity<JMP_Passenger>()
		//	//	.HasQueryFilter(d => !d.IsDeleted);
		//}




	}
}
