using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SpartanClash.Models.ClashDB
{
    public partial class clashdbContext : DbContext
    {
        public virtual DbSet<TClashdevset> TClashdevset { get; set; }
        public virtual DbSet<TClashmetadata> TClashmetadata { get; set; }
        public virtual DbSet<TCompanies> TCompanies { get; set; }
        public virtual DbSet<TCompany2matches> TCompany2matches { get; set; }
        public virtual DbSet<TMapmetadata> TMapmetadata { get; set; }
        public virtual DbSet<TMatchparticipants> TMatchparticipants { get; set; }

        public clashdbContext(DbContextOptions<clashdbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TClashdevset>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.ToTable("t_clashdevset");

                entity.HasIndex(e => e.MatchId)
                    .HasName("MatchId")
                    .IsUnique();

                entity.Property(e => e.MatchId)
                    .HasColumnName("matchId")
                    .HasMaxLength(64);

                entity.Property(e => e.GameBaseVariantId)
                    .HasColumnName("GameBaseVariantID")
                    .HasColumnType("text");

                entity.Property(e => e.GameMode).HasColumnType("int(32)");

                entity.Property(e => e.GameVariantOwner)
                    .HasColumnName("GameVariant_Owner")
                    .HasColumnType("text");

                entity.Property(e => e.GameVariantOwnerType)
                    .HasColumnName("GameVariant_OwnerType")
                    .HasColumnType("int(11)");

                entity.Property(e => e.GameVariantResourceId)
                    .HasColumnName("GameVariant_ResourceID")
                    .HasColumnType("text");

                entity.Property(e => e.GameVariantResourceType)
                    .HasColumnName("GameVariant_ResourceType")
                    .HasColumnType("int(11)");

                entity.Property(e => e.HopperId).HasColumnType("text");

                entity.Property(e => e.IsTeamGame).HasColumnType("binary(50)");

                entity.Property(e => e.MapId).HasColumnType("text");

                entity.Property(e => e.MapVariantOwner)
                    .HasColumnName("MapVariant_Owner")
                    .HasColumnType("text");

                entity.Property(e => e.MapVariantOwnerType)
                    .HasColumnName("MapVariant_OwnerType")
                    .HasColumnType("int(32)");

                entity.Property(e => e.MapVariantResourceId)
                    .HasColumnName("MapVariant_ResourceId")
                    .HasColumnType("text");

                entity.Property(e => e.MapVariantResourceType)
                    .HasColumnName("MapVariant_ResourceType")
                    .HasColumnType("int(32)");

                entity.Property(e => e.MatchCompleteDate).HasColumnType("datetime");

                entity.Property(e => e.MatchDuration).HasColumnType("text");

                entity.Property(e => e.SeasonId)
                    .HasColumnName("SeasonID")
                    .HasColumnType("text");

                entity.Property(e => e.Status)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Team1Company)
                    .HasColumnName("Team1_Company")
                    .HasColumnType("text");

                entity.Property(e => e.Team1Dnfcount)
                    .HasColumnName("Team1_DNFCount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Team1Rank)
                    .HasColumnName("Team1_Rank")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Team1Score).HasColumnName("Team1_Score");

                entity.Property(e => e.Team2Company)
                    .HasColumnName("Team2_Company")
                    .HasColumnType("text");

                entity.Property(e => e.Team2Dnfcount)
                    .HasColumnName("Team2_DNFCount")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Team2Rank)
                    .HasColumnName("Team2_Rank")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.Team2Score).HasColumnName("Team2_Score");
            });

            modelBuilder.Entity<TClashmetadata>(entity =>
            {
                entity.ToTable("t_clashmetadata");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(16)
                    .HasDefaultValueSql("'active'");

                entity.Property(e => e.DataRefreshDate)
                    .HasColumnName("dataRefreshDate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<TCompanies>(entity =>
            {
                entity.HasKey(e => e.CompanyId);

                entity.ToTable("t_companies");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("company")
                    .IsUnique();

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasMaxLength(128);

                entity.Property(e => e.CompanyName)
                    .IsRequired()
                    .HasColumnName("companyName")
                    .HasMaxLength(128);

                entity.Property(e => e.Losses)
                    .HasColumnName("losses")
                    .HasColumnType("int(64)");

                entity.Property(e => e.TimesSearched)
                    .HasColumnName("times_searched")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.TotalMatches)
                    .HasColumnName("total_matches")
                    .HasColumnType("int(128)");

                entity.Property(e => e.WaypointLeaderBoardRank)
                    .HasColumnName("waypointLeaderBoardRank")
                    .HasColumnType("int(64)")
                    .HasDefaultValueSql("'-1'");

                entity.Property(e => e.WinPercent).HasColumnName("win_percent");

                entity.Property(e => e.Wins)
                    .HasColumnName("wins")
                    .HasColumnType("int(64)");
            });

            modelBuilder.Entity<TCompany2matches>(entity =>
            {
                entity.HasKey(e => new { e.MatchId, e.CompanyId });

                entity.ToTable("t_company2matches");

                entity.HasIndex(e => e.CompanyId)
                    .HasName("fk_company");

                entity.Property(e => e.MatchId)
                    .HasColumnName("matchId")
                    .HasMaxLength(64);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("companyId")
                    .HasMaxLength(128);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.TCompany2matches)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("fk_company");

                entity.HasOne(d => d.Match)
                    .WithMany(p => p.TCompany2matches)
                    .HasForeignKey(d => d.MatchId)
                    .HasConstraintName("fk_MatchId");
            });

            modelBuilder.Entity<TMapmetadata>(entity =>
            {
                entity.HasKey(e => e.MapId);

                entity.ToTable("t_mapmetadata");

                entity.HasIndex(e => e.MapId)
                    .HasName("mapName")
                    .IsUnique();

                entity.Property(e => e.MapId)
                    .HasColumnName("mapId")
                    .HasMaxLength(64);

                entity.Property(e => e.ImageUrl)
                    .HasColumnName("imageURL")
                    .HasMaxLength(256);

                entity.Property(e => e.PrintableName)
                    .HasColumnName("printableName")
                    .HasMaxLength(64);
            });

            modelBuilder.Entity<TMatchparticipants>(entity =>
            {
                entity.HasKey(e => e.MatchId);

                entity.ToTable("t_matchparticipants");

                entity.Property(e => e.MatchId)
                    .HasColumnName("matchId")
                    .HasMaxLength(64);

                entity.Property(e => e.DnfPlayers)
                    .HasColumnName("DNF_Players")
                    .HasMaxLength(4096);

                entity.Property(e => e.OtherPlayers)
                    .HasColumnName("other_Players")
                    .HasMaxLength(4096);

                entity.Property(e => e.Team1Players)
                    .HasColumnName("team1_Players")
                    .HasMaxLength(4096);

                entity.Property(e => e.Team2Players)
                    .HasColumnName("team2_Players")
                    .HasMaxLength(4096);

                entity.HasOne(d => d.Match)
                    .WithOne(p => p.TMatchparticipants)
                    .HasForeignKey<TMatchparticipants>(d => d.MatchId)
                    .HasConstraintName("fk_to_clashset");
            });
        }
    }
}
