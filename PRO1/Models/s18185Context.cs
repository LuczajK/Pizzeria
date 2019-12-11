using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1.Models
{
    public partial class s18185Context : DbContext
    {
        public s18185Context()
        {
        }

        public s18185Context(DbContextOptions<s18185Context> options)
            : base(options)
        {
        }

        public virtual DbSet<BazowePizze> BazowePizze { get; set; }
        public virtual DbSet<Lokale> Lokale { get; set; }
        public virtual DbSet<PizzaWlasna> PizzaWlasna { get; set; }
        public virtual DbSet<Promocje> Promocje { get; set; }
        public virtual DbSet<PromocjePizza> PromocjePizza { get; set; }
        public virtual DbSet<Rola> Rola { get; set; }
        public virtual DbSet<Skladnik> Skladnik { get; set; }
        public virtual DbSet<Stan> Stan { get; set; }
        public virtual DbSet<Użytkownik> Użytkownik { get; set; }
        public virtual DbSet<ZamowionePizze> ZamowionePizze { get; set; }
        public virtual DbSet<Zamówienie> Zamówienie { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=db-mssql;Initial Catalog=s18185;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<BazowePizze>(entity =>
            {
                entity.HasKey(e => e.IdGotowePizze)
                    .HasName("BazowePizze_pk");

                entity.Property(e => e.IdGotowePizze).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Lokale>(entity =>
            {
                entity.HasKey(e => e.IdLokalu)
                    .HasName("Lokale_pk");

                entity.Property(e => e.IdLokalu).ValueGeneratedNever();

                entity.Property(e => e.Adres)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Godzinyotwarcia)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Współrzędne)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PizzaWlasna>(entity =>
            {
                entity.HasKey(e => new { e.SkładnikIdSkladnik, e.IdWlasnejPizzy, e.GotowePizzeIdGotowePizze })
                    .HasName("PizzaWlasna_pk");

                entity.Property(e => e.SkładnikIdSkladnik).HasColumnName("Składnik_IdSkladnik");

                entity.Property(e => e.GotowePizzeIdGotowePizze).HasColumnName("GotowePizze_IdGotowePizze");

                entity.Property(e => e.Cena).HasColumnType("decimal(2, 2)");

                entity.HasOne(d => d.GotowePizzeIdGotowePizzeNavigation)
                    .WithMany(p => p.PizzaWlasna)
                    .HasForeignKey(d => d.GotowePizzeIdGotowePizze)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PizzaWlasna_GotowePizze");

                entity.HasOne(d => d.SkładnikIdSkladnikNavigation)
                    .WithMany(p => p.PizzaWlasna)
                    .HasForeignKey(d => d.SkładnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Table_19_Składnik");
            });

            modelBuilder.Entity<Promocje>(entity =>
            {
                entity.HasKey(e => e.IdPromocji)
                    .HasName("Promocje_pk");

                entity.Property(e => e.IdPromocji).ValueGeneratedNever();

                entity.Property(e => e.KodRabatowy)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PromocjePizza>(entity =>
            {
                entity.HasKey(e => new { e.PromocjeIdPromocji, e.GotowePizzeIdGotowePizze, e.SkladnikIdSkladnik })
                    .HasName("PromocjePizza_pk");

                entity.Property(e => e.PromocjeIdPromocji).HasColumnName("Promocje_IdPromocji");

                entity.Property(e => e.GotowePizzeIdGotowePizze).HasColumnName("GotowePizze_IdGotowePizze");

                entity.Property(e => e.SkladnikIdSkladnik).HasColumnName("Skladnik_IdSkladnik");

                entity.HasOne(d => d.GotowePizzeIdGotowePizzeNavigation)
                    .WithMany(p => p.PromocjePizza)
                    .HasForeignKey(d => d.GotowePizzeIdGotowePizze)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromocjePizza_GotowePizze");

                entity.HasOne(d => d.PromocjeIdPromocjiNavigation)
                    .WithMany(p => p.PromocjePizza)
                    .HasForeignKey(d => d.PromocjeIdPromocji)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromocjePizza_Promocje");

                entity.HasOne(d => d.SkladnikIdSkladnikNavigation)
                    .WithMany(p => p.PromocjePizza)
                    .HasForeignKey(d => d.SkladnikIdSkladnik)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PromocjePizza_Skladnik");
            });

            modelBuilder.Entity<Rola>(entity =>
            {
                entity.HasKey(e => e.IdRoli)
                    .HasName("Rola_pk");

                entity.Property(e => e.IdRoli).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Skladnik>(entity =>
            {
                entity.HasKey(e => e.IdSkladnik)
                    .HasName("Skladnik_pk");

                entity.Property(e => e.IdSkladnik).ValueGeneratedNever();

                entity.Property(e => e.Cena).HasColumnType("decimal(2, 2)");

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Opis)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Stan>(entity =>
            {
                entity.HasKey(e => e.IdStanu)
                    .HasName("Stan_pk");

                entity.Property(e => e.IdStanu).ValueGeneratedNever();

                entity.Property(e => e.Nazwa)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Użytkownik>(entity =>
            {
                entity.HasKey(e => e.IdUżytkownika)
                    .HasName("Użytkownik_pk");

                entity.Property(e => e.IdUżytkownika).ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Haslo)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Imie)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Miasto)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Nazwisko)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.NrDomu)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RolaIdRoli).HasColumnName("Rola_IdRoli");

                entity.Property(e => e.Ulica)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.RolaIdRoliNavigation)
                    .WithMany(p => p.Użytkownik)
                    .HasForeignKey(d => d.RolaIdRoli)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Użytkownik_Rola");
            });

            modelBuilder.Entity<ZamowionePizze>(entity =>
            {
                entity.HasKey(e => e.ZamówienieIdZamowienia)
                    .HasName("ZamowionePizze_pk");

                entity.Property(e => e.ZamówienieIdZamowienia)
                    .HasColumnName("Zamówienie_IdZamowienia")
                    .ValueGeneratedNever();

                entity.Property(e => e.PizzaWlasnaGotowePizzeIdGotowePizze).HasColumnName("PizzaWlasna_GotowePizze_IdGotowePizze");

                entity.Property(e => e.PizzaWlasnaIdWlasnejPizzy).HasColumnName("PizzaWlasna_IdWlasnejPizzy");

                entity.Property(e => e.PizzaWlasnaSkładnikIdSkladnik).HasColumnName("PizzaWlasna_Składnik_IdSkladnik");

                entity.HasOne(d => d.ZamówienieIdZamowieniaNavigation)
                    .WithOne(p => p.ZamowionePizze)
                    .HasForeignKey<ZamowionePizze>(d => d.ZamówienieIdZamowienia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZamowionePizze_Zamówienie");

                entity.HasOne(d => d.PizzaWlasna)
                    .WithMany(p => p.ZamowionePizze)
                    .HasForeignKey(d => new { d.PizzaWlasnaSkładnikIdSkladnik, d.PizzaWlasnaIdWlasnejPizzy, d.PizzaWlasnaGotowePizzeIdGotowePizze })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("ZamowionePizze_PizzaWlasna");
            });

            modelBuilder.Entity<Zamówienie>(entity =>
            {
                entity.HasKey(e => e.IdZamowienia)
                    .HasName("Zamówienie_pk");

                entity.Property(e => e.IdZamowienia).ValueGeneratedNever();

                entity.Property(e => e.Data).HasColumnType("datetime");

                entity.Property(e => e.LokaleIdLokalu).HasColumnName("Lokale_IdLokalu");

                entity.Property(e => e.PodsumowanieCeny).HasColumnType("decimal(20, 2)");

                entity.Property(e => e.StanIdStanu).HasColumnName("Stan_IdStanu");

                entity.Property(e => e.UżytkownikIdUżytkownika).HasColumnName("Użytkownik_IdUżytkownika");

                entity.HasOne(d => d.LokaleIdLokaluNavigation)
                    .WithMany(p => p.Zamówienie)
                    .HasForeignKey(d => d.LokaleIdLokalu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamówienie_Lokale");

                entity.HasOne(d => d.StanIdStanuNavigation)
                    .WithMany(p => p.Zamówienie)
                    .HasForeignKey(d => d.StanIdStanu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamówienie_Stan");

                entity.HasOne(d => d.UżytkownikIdUżytkownikaNavigation)
                    .WithMany(p => p.Zamówienie)
                    .HasForeignKey(d => d.UżytkownikIdUżytkownika)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Zamówienie_Użytkownik");
            });
        }
    }
}
